using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TheWanderersOutpost.Api.Database;
using TheWanderersOutpost.Api.Models;
using TheWanderersOutpost.Api.Models.Session;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace TheWanderersOutpost.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class CampaignController : Controller
    {
        public IMongoDatabase MongoDb { get; set; }
        public IMongoCollection<Campaign> CampaignCollection {get;}
        public IMongoCollection<dynamic> CharacterCollection { get; }
        public IEnumerable<ICharacterSheet> CharacterSheetTypes { get; }

        public CampaignController(DocumentStoreHolder holder, IEnumerable<ICharacterSheet> characterSheetTypes)
        {
            MongoDb = holder.GetDefaultDatabase();
            CampaignCollection = MongoDb.GetCollection<Campaign>("CampaignCollection");
            CharacterCollection = MongoDb.GetCollection<dynamic>("RpgCharModels");
            CharacterSheetTypes = characterSheetTypes;
        }

        [HttpPost("create/{gameSystem}")]
        public async Task<IActionResult> CreateSomeCharacterIfYouCanBoi([FromRoute] string gameSystem)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var type = CharacterSheetTypes.FirstOrDefault(s => s.GetType().Name.Equals(gameSystem, StringComparison.OrdinalIgnoreCase));
            if (type == null)
            {
                return BadRequest($"{gameSystem} is not a valid type");
            }

            var newCampagin = new Campaign
            {
                Id = ObjectId.GenerateNewId().ToString(),
                OwnerID = userId,
                _created = new BsonDateTime(DateTime.UtcNow),
                _lastUpdated = new BsonDateTime(DateTime.UtcNow),
                CampaignType = gameSystem,
                CampaignImage = "",
                Characters = new List<string>(),
                Session = new List<Session>()
            };
            
            await CampaignCollection.InsertOneAsync(newCampagin);

            return Ok(newCampagin.Id);
        }

        /// <summary>
        /// Adds a character to a campaign
        /// </summary>
        /// <param name="campaignId">The ID of the campaign</param>
        /// <param name="characterId">The ID of the character</param>
        /// <returns></returns>
        [HttpPost("{campaignId}/add/{characterId}")]
        public async Task<IActionResult> AddCharacter([FromRoute] string campaignId, [FromRoute] string characterId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var findCampaginFilter = Builders<Campaign>.Filter.And(
                            Builders<Campaign>.Filter.Eq("_id", ObjectId.Parse(campaignId)),
                            Builders<Campaign>.Filter.Eq("ownerID", userId));

            var foundCampaigns = await (await CampaignCollection.FindAsync(findCampaginFilter)).ToListAsync();
            if(foundCampaigns == null || foundCampaigns.Count != 1)
            {
                return BadRequest("Campagin null or not unique");
            }

            if (foundCampaigns[0].OwnerID != userId)
            {
                return Unauthorized();
            }

            var findCharacterFilter = Builders<dynamic>.Filter.Eq("_id", ObjectId.Parse(characterId));
            var foundCharacters = await (await CharacterCollection.FindAsync(findCharacterFilter)).ToListAsync();
            
            if (foundCharacters == null || foundCharacters.Count != 1)
            {
                return BadRequest("Character null or not unique");
            }

            var foundCampaign = foundCampaigns[0];
            var foundCharacter = foundCharacters[0] as BaseCharacterSheet;

            if (foundCharacter.GameSystem != foundCampaign.CampaignType)
            {
                return BadRequest($"Why are you adding a {foundCharacter.GameSystem} character to a {foundCampaign.CampaignType} campaign?");
            }

            CampaignCollection.UpdateOne(c => c.Id == campaignId, Builders<Campaign>.Update.AddToSet("characters", foundCharacter.Id));
            return Json(campaignId);
        }
    }
}