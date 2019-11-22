using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using System;
using System.Threading.Tasks;

namespace TheWanderersOutpost.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ImageController : Controller
    {
        public CloudStorageAccount StorageAccount { get; set; }
        public string BlobContainerName { get; set; } = "imagescontainerblob";

        public ImageController()
        {
            string storageConnectionString = Environment.GetEnvironmentVariable("azureblobConnection");

            StorageAccount = CloudStorageAccount.Parse(storageConnectionString);
        }

        /// <summary>
        /// Stores an image and returns the url for it
        /// </summary>
        /// <param name="imageFile">The <seealso cref="IFormFile"/> file</param>
        /// <returns>The <seealso cref="Uri"/> of the image</returns>
        [ProducesResponseType(typeof(string), 201)]
        [ProducesResponseType(400)]
        [HttpPost("uploadImage")]
        public async Task<IActionResult> UploadImage(IFormFile imageFile)
        {
            if(imageFile == null)
            {
                return BadRequest();
            }
            CloudBlobClient blobClient = StorageAccount.CreateCloudBlobClient();
            CloudBlobContainer blobContainer = blobClient.GetContainerReference(BlobContainerName);
            CloudBlockBlob blob = blobContainer.GetBlockBlobReference($"{Guid.NewGuid()}/{imageFile.FileName}");

            await blob.UploadFromStreamAsync(imageFile.OpenReadStream());

            return Created(blob.Uri.ToString(), imageFile);            
        }
    }
}
