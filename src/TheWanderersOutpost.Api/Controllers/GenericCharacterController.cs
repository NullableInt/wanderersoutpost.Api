using TheWanderersOutpost.Api.Database;
using TheWanderersOutpost.Api.Extensions;
using TheWanderersOutpost.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TheWanderersOutpost.Api.Controllers
{
    [Route("")]
    [Authorize]
    public class GenericCharacterController : Controller
    {
        private readonly IEnumerable<ICharacterSheet> characterSheetTypes;

        public IMongoDatabase MongoDb { get; set; }

        public GenericCharacterController(DocumentStoreHolder holder, IEnumerable<ICharacterSheet> characterSheetTypes)
        {
            MongoDb = holder.GetDefaultDatabase();
            this.characterSheetTypes = characterSheetTypes;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var filter = Builders<dynamic>.Filter.Eq("ownerID", userId);
            var collection = MongoDb.GetCollection<dynamic>("RpgCharModels");
            var list = await (await collection.FindAsync(filter)).ToListAsync();

            if(list.Count == 0)
            {
                return Ok();
            }

            var listOfIds = new List<string>();
            foreach (var item in list)
            {
                var upScaled = item as BaseCharacterSheet;
                listOfIds.Add(upScaled.Id);
            }

            return Ok(listOfIds);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllById([FromRoute] string id)
        {
            var collection = MongoDb.GetCollection<dynamic>("RpgCharModels");
            var stringId = id.ToString();
            var filter = Builders<dynamic>.Filter.Eq("_id", ObjectId.Parse(stringId));
            var list = await (await collection.FindAsync(filter)).ToListAsync();

            if (list.Count > 0)
            {
                var listOfProps = new Dictionary<string, string>();
                var theOne = list[0] as BaseCharacterSheet;

                var props = theOne.GetType().GetProperties().Where(p => p.DeclaringType != typeof(BaseCharacterSheet));
                foreach (var prop in props)
                {
                    listOfProps.Add(prop.Name.ToCamelCase(), $"/{stringId}/{prop.Name.ToCamelCase()}");
                }
                return Json(listOfProps);
            }
            return NotFound();
        }

        [HttpGet("{id}/{property}")]
        public async Task<IActionResult> GetBySomePropertyIfItHasIt([FromRoute] string id, [FromRoute] string property)
        {
            var collection = MongoDb.GetCollection<dynamic>("RpgCharModels");
            var stringId = id.ToString();
            var filter = Builders<dynamic>.Filter.Eq("_id", ObjectId.Parse(stringId));
            var list = await (await collection.FindAsync(filter)).ToListAsync();

            if (list.Count > 0)
            {
                var theOne = list[0] as BaseCharacterSheet;
                var props = theOne.GetType().GetProperties();
                var thePropertyIfFound = props.FirstOrDefault(e => e.Name.Equals(property, StringComparison.OrdinalIgnoreCase));
                if (thePropertyIfFound != null)
                {
                    return Json(thePropertyIfFound.GetValue(theOne));
                }
            }
            return NotFound();
        }

        [HttpPatch("{id}/{property}")]
        public async Task<IActionResult> SetBySomePropertyIfItHasIt([FromRoute] string id,
                                                                    [FromRoute] string property,
                                                                    [FromBody] string propertyValue)
        {
            var collection = MongoDb.GetCollection<dynamic>("RpgCharModels");
            var stringId = id.ToString();
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var filter = Builders<dynamic>.Filter.And(
                            Builders<dynamic>.Filter.Eq("_id", ObjectId.Parse(stringId)),
                            Builders<dynamic>.Filter.Eq("ownerID", userId));
            var list = await (await collection.FindAsync(filter)).ToListAsync();

            if (list.Count > 0)
            {
                var theOne = list[0] as BaseCharacterSheet;
                var props = theOne.GetType().GetProperties();
                var thePropertyIfFound = props.FirstOrDefault(e => e.Name.Equals(property, StringComparison.OrdinalIgnoreCase));
                if (thePropertyIfFound != null)
                {
                    try
                    {
                        var value = Convert.ChangeType(propertyValue, thePropertyIfFound.PropertyType);
                        thePropertyIfFound.SetValue(theOne, value);

                        await collection.UpdateOneAsync(filter, Builders<dynamic>.Update.Set(property, value).CurrentDate("_lastUpdated"));
                        return Ok(propertyValue);
                    }
                    catch (Exception)
                    {
                        return BadRequest($"An error occured when updating {stringId}'s {property}.");
                    }
                    
                }
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] string id)
        {
            var collection = MongoDb.GetCollection<dynamic>("RpgCharModels");
            var deleteCollection = MongoDb.GetCollection<dynamic>("RpgCharModelsDeleted");
            var stringId = id.ToString();
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var filter = Builders<dynamic>.Filter.And(
                            Builders<dynamic>.Filter.Eq("_id", ObjectId.Parse(stringId)),
                            Builders<dynamic>.Filter.Eq("ownerID", userId));
            var list = await (await collection.FindAsync(filter)).ToListAsync();

            await deleteCollection.InsertManyAsync(list);
            await deleteCollection.UpdateManyAsync(filter, Builders<dynamic>.Update.CurrentDate("_lastUpdated"));
            await collection.DeleteManyAsync(filter);
            return Json(id);
        }


        [HttpPost("create/{gameSystem}")]
        public async Task<IActionResult> CreateSomeCharacterIfYouCanBoi([FromRoute] string gameSystem, [FromBody] dynamic body)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var type = characterSheetTypes.FirstOrDefault(s => s.GetType().Name.Equals(gameSystem, StringComparison.OrdinalIgnoreCase));
            if (type == null)
            {
                return BadRequest($"{gameSystem} is not a valid type, go fuck yourself and come back with the right type.");
            }   

            var deserializedGenericGoo = Newtonsoft.Json.JsonConvert.DeserializeObject(body.ToString(), type.GetType());
            if (deserializedGenericGoo == null)
            {
                return BadRequest($"The request could not be made into a {gameSystem} entity, you have failed");
            }
            
            var firmlyShapedGoo = deserializedGenericGoo as BaseCharacterSheet;
            firmlyShapedGoo.Id = ObjectId.GenerateNewId().ToString();
            firmlyShapedGoo.OwnerID = userId;
            firmlyShapedGoo._created = new BsonDateTime(System.DateTime.UtcNow);
            firmlyShapedGoo._lastUpdated = new BsonDateTime(System.DateTime.UtcNow);

            await MongoDb.GetCollection<dynamic>("RpgCharModels").InsertOneAsync(deserializedGenericGoo);

            return Created(firmlyShapedGoo.Id, firmlyShapedGoo);
        }
    }
}
