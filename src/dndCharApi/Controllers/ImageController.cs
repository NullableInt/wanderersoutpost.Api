using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using System;
using System.Threading.Tasks;

namespace dndCharApi.Controllers
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

        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [HttpPost("uploadImage")]
        public async Task<IActionResult> UploadImage(IFormFile imageFile)
        {
            if(imageFile == null)
            {
                return BadRequest();
            }
            try
            {
                CloudBlobClient blobClient = StorageAccount.CreateCloudBlobClient();
                CloudBlobContainer blobContainer = blobClient.GetContainerReference(BlobContainerName);
                CloudBlockBlob blob = blobContainer.GetBlockBlobReference($"{Guid.NewGuid()}/{imageFile.FileName}");

                await blob.UploadFromStreamAsync(imageFile.OpenReadStream());

                return Created(blob.Uri.ToString(), imageFile);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
