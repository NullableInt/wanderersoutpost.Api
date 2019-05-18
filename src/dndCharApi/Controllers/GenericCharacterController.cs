using dndChar.Database;
using dndCharApi.Models;
using dndCharApi.Models.CallOfCthulu;
using dndCharApi.Models.RpgChar;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dndCharApi.Controllers
{
    [Route("")]
    public class GenericCharacterController : Controller
    {
        public IMongoDatabase MongoDb { get; set; }

        public GenericCharacterController(DocumentStoreHolder holder) => MongoDb = holder.Store.GetDatabase("RpgCharModelDb");

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllById([FromRoute] string id)
        {
            var collection = MongoDb.GetCollection<dynamic>("RpgCharModels");
            var stringId = id.ToString();
            var filter = Builders<dynamic>.Filter.Eq("_id", ObjectId.Parse(stringId));
            var list = await (await collection.FindAsync(filter)).ToListAsync();

            if (list.Count > 0)
            {
                var theOne = list[0];
                return Ok(theOne);
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
            return BadRequest();
        }

        [HttpPatch("{id}/{property}")]
        public async Task<IActionResult> SetBySomePropertyIfItHasIt([FromRoute] string id, [FromRoute] string property, [FromBody] string propertyValue)
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
                    var theValueType = thePropertyIfFound.DeclaringType;

                    try
                    {
                        var value = Convert.ChangeType(propertyValue, thePropertyIfFound.PropertyType);
                        thePropertyIfFound.SetValue(theOne, value);

                        await collection.UpdateOneAsync(filter, Builders<dynamic>.Update.Set(property, value).CurrentDate("_lastUpdated"));
                        return Ok(propertyValue);
                    }
                    catch (Exception)
                    {
                        return BadRequest("fuck");
                    }
                    
                }
            }
            return BadRequest();
        }

        #region mock construciton

        [HttpGet("newChar/{id?}")]
        public async Task<IActionResult> NewChar([FromRoute] string id = null)
        {
            var userId = "google-oauth2|102912685359589454387";

            if (string.IsNullOrEmpty(id) || !ObjectId.TryParse(id, out var objectId))
            {
                id = ObjectId.GenerateNewId().ToString();
            }

            var newChar = new RpgCharModel
            {
                AbilityScores = new AbilityScores(),
                CharacterAppearance = new List<CharacterAppearance>(),
                DeathSave = new List<DeathSave>(),
                Equipment = new Equipment(),
                Feats = new List<Feat>(),
                FeaturesTraits = new List<FeaturesTrait>(),
                Health = new Health(),
                HitDice = new List<HitDice>(),
                HitDiceType = new List<HitDiceTypeModel>(),
                Id = id.ToString(),
                Items = new List<Item>(),
                MagicItems = new List<MagicItem>(),
                Notes = new List<Note>(),
                OwnerID = userId,
                Profile = new Profile(),
                SavingThrows = new List<SavingThrow>(),
                Skills = new List<Skill>(),
                Spells = new Spells(),
                Status = new List<Status>(),
                Traits = new List<Trait>(),
                Treasure = new List<Treasure>(),
                _created = new BsonDateTime(System.DateTime.UtcNow),
                _lastUpdated = new BsonDateTime(System.DateTime.UtcNow)
            };

            var collection = MongoDb.GetCollection<BaseCharacterSheet>("RpgCharModels");
            await collection.InsertOneAsync(newChar);

            var cthulu = new CallOfCthulu
            {
                OwnerID = userId,
                Sanity = new Random().Next(0, 100),
                _created = new BsonDateTime(System.DateTime.UtcNow),
                _lastUpdated = new BsonDateTime(System.DateTime.UtcNow)
            };
            await collection.InsertOneAsync(cthulu);
            return new JsonResult(id);
        }
        #endregion
    }
}
