using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using TheWanderersOutpost.Api.Database;
using TheWanderersOutpost.Api.Models.RpgChar;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace TheWanderersOutpost.Api.Controllers
{
    [Route("characters")]
    [Route("5e")]
    [ApiController]
    [Authorize]
    public class FiveECharController : Controller
    {
        public IMongoDatabase MongoDb { get; set; }

        public FiveECharController(DocumentStoreHolder holder)
        {
            MongoDb = holder.GetDefaultDatabase();
        }


        [HttpGet("")]
        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                var userName = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var collection = MongoDb.GetCollection<FiveEModel>("RpgCharModels");
                var found = collection.Find(f => f.OwnerID == userName);
                if (found.Any())
                {
                    var list = await found.ToListAsync();
                    return Ok(list);
                }
                return NoContent();
            }
            catch (System.Exception e)
            {
                //This try catch with a throw is only here for debug.
                throw e;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllById([FromRoute] string id)
        {
            var collection = MongoDb.GetCollection<FiveEModel>("RpgCharModels");
            var stringId = id.ToString();
            var list = await collection.Find(f => f.Id == stringId).ToListAsync();
            if (list.Count > 0)
            {
                return Ok(list[0]);
            }
            return NotFound();
        }

        [HttpPost("{id?}")]
        public async Task<IActionResult> SetAll([FromBody] FiveEModel dynamic, [FromRoute] string id = null)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            dynamic.OwnerID = userId;
            if (string.IsNullOrEmpty(id) || !ObjectId.TryParse(id, out _))
            {
                id = ObjectId.GenerateNewId().ToString();
            }
            dynamic.Id = id.ToString();
            dynamic._created = new BsonDateTime(System.DateTime.UtcNow);
            dynamic._lastUpdated = new BsonDateTime(System.DateTime.UtcNow);

            var collection = MongoDb.GetCollection<FiveEModel>("RpgCharModels");
            await collection.InsertOneAsync(dynamic);
            return new JsonResult(dynamic.Id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChar([FromRoute] string id)
        {
            var collection = MongoDb.GetCollection<FiveEModel>("RpgCharModels");
            var deleteCollection = MongoDb.GetCollection<FiveEModel>("RpgCharModelsDeleted");
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var stringId = id.ToString();

            var list = await collection.FindAsync(f => f.Id == stringId && f.OwnerID == userId);

            await deleteCollection.InsertManyAsync(list.ToEnumerable());
            var deleteResult = collection.DeleteMany(f => f.Id == stringId && f.OwnerID == userId);

            return Ok(id);
        }

        [HttpGet("newChar/{id?}")]
        public async Task<string> NewChar([FromRoute] string id = null)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (string.IsNullOrEmpty(id) || !ObjectId.TryParse(id, out _))
            {
                id = ObjectId.GenerateNewId().ToString();
            }

            var newChar = new FiveEModel
            {
                AbilityScores = new List<AbilityScore>(),
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

            var collection = MongoDb.GetCollection<FiveEModel>("RpgCharModels");
            await collection.InsertOneAsync(newChar);
            return id;
        }

        [HttpPost("newChar/{id?}")]
        public Task<string> NewCharPost([FromRoute] string id = null)
        {
            return NewChar(id);
        }

        [HttpGet("{id}/Profile")]
        public async Task<IActionResult> GetProfile([FromRoute] string id) => await GetRpgModelPart(id, Builders<FiveEModel>.Projection.Include(e => e.Profile).Exclude(e => e.Id));

        [HttpPatch("{id}/Profile")]
        public async Task<IActionResult> UpdateProfile([FromRoute] string id, [FromBody] Profile newProfile) => await UpdateRpgModel(id, Builders<FiveEModel>.Update.Set(sheet => sheet.Profile, newProfile), newProfile);

        [HttpGet("{id}/Traits")]
        public async Task<IActionResult> GetTraits([FromRoute] string id) => await GetRpgModelPart(id, Builders<FiveEModel>.Projection.Include(e => e.Traits).Exclude(e => e.Id));

        [HttpPatch("{id}/Traits")]
        public async Task<IActionResult> UpdateTraits([FromRoute] string id, [FromBody] List<Trait> traits) => await UpdateRpgModel(id, Builders<FiveEModel>.Update.Set(sheet => sheet.Traits, traits), traits);

        [HttpGet("{id}/Items")]
        public async Task<IActionResult> GetItems([FromRoute] string id) => await GetRpgModelPart(id, Builders<FiveEModel>.Projection.Include(e => e.Items).Exclude(e => e.Id));

        [HttpPatch("{id}/Items")]
        public async Task<IActionResult> UpdateItems([FromRoute] string id, [FromBody] List<Item> items) => await UpdateRpgModel(id, Builders<FiveEModel>.Update.Set(sheet => sheet.Items, items), items);

        [HttpGet("{id}/AbilityScores")]
        public async Task<IActionResult> GetAbilityScores([FromRoute] string id) => await GetRpgModelPart(id, Builders<FiveEModel>.Projection.Include(e => e.AbilityScores).Exclude(e => e.Id));

        [HttpPatch("{id}/AbilityScores")]
        public async Task<IActionResult> UpdateAbilityScores([FromRoute] string id, [FromBody] List<AbilityScore> abilityScores) => await UpdateRpgModel(id, Builders<FiveEModel>.Update.Set(sheet => sheet.AbilityScores, abilityScores), abilityScores);

        [HttpGet("{id}/Status")]
        public async Task<IActionResult> GetStatus([FromRoute] string id) => await GetRpgModelPart(id, Builders<FiveEModel>.Projection.Include(e => e.Status).Exclude(e => e.Id));

        [HttpPatch("{id}/Status")]
        public async Task<IActionResult> UpdateStatus([FromRoute] string id, [FromBody] List<Status> statuses) => await UpdateRpgModel(id, Builders<FiveEModel>.Update.Set(sheet => sheet.Status, statuses), statuses);

        [HttpGet("{id}/HitDice")]
        public async Task<IActionResult> GetHitDice([FromRoute] string id) => await GetRpgModelPart(id, Builders<FiveEModel>.Projection.Include(e => e.HitDice).Exclude(e => e.Id));

        [HttpPatch("{id}/HitDice")]
        public async Task<IActionResult> UpdateHitDice([FromRoute] string id, [FromBody] List<HitDice> dice) => await UpdateRpgModel(id, Builders<FiveEModel>.Update.Set(sheet => sheet.HitDice, dice), dice);

        [HttpGet("{id}/Health")]
        public async Task<IActionResult> GetHealth([FromRoute] string id) => await GetRpgModelPart(id, Builders<FiveEModel>.Projection.Include(e => e.Health).Exclude(e => e.Id));

        [HttpPatch("{id}/Health")]
        public async Task<IActionResult> UpdateHealth([FromRoute] string id, [FromBody] Health health) => await UpdateRpgModel(id, Builders<FiveEModel>.Update.Set(sheet => sheet.Health, health), health);

        [HttpGet("{id}/SavingThrows")]
        public async Task<IActionResult> GetSavingThrows([FromRoute] string id) => await GetRpgModelPart(id, Builders<FiveEModel>.Projection.Include(e => e.SavingThrows).Exclude(e => e.Id));

        [HttpPatch("{id}/SavingThrows")]
        public async Task<IActionResult> UpdateSavingThrows([FromRoute] string id, [FromBody] List<SavingThrow> savingThrows) => await UpdateRpgModel(id, Builders<FiveEModel>.Update.Set(sheet => sheet.SavingThrows, savingThrows), savingThrows);

        [HttpGet("{id}/Skills")]
        public async Task<IActionResult> GetSkills([FromRoute] string id) => await GetRpgModelPart(id, Builders<FiveEModel>.Projection.Include(e => e.Skills).Exclude(e => e.Id));

        [HttpPatch("{id}/Skills")]
        public async Task<IActionResult> UpdateSkills([FromRoute] string id, [FromBody] List<Skill> skills) => await UpdateRpgModel(id, Builders<FiveEModel>.Update.Set(sheet => sheet.Skills, skills), skills);

        [HttpGet("{id}/HitDiceType")]
        public async Task<IActionResult> GetHitDiceType([FromRoute] string id) => await GetRpgModelPart(id, Builders<FiveEModel>.Projection.Include(e => e.HitDiceType).Exclude(e => e.Id));

        [HttpPatch("{id}/HitDiceType")]
        public async Task<IActionResult> UpdateHitDiceType([FromRoute] string id, [FromBody] List<HitDiceTypeModel> hitDices) => await UpdateRpgModel(id, Builders<FiveEModel>.Update.Set(sheet => sheet.HitDiceType, hitDices), hitDices);

        [HttpGet("{id}/DeathSave")]
        public async Task<IActionResult> GetDeathSave([FromRoute] string id) => await GetRpgModelPart(id, Builders<FiveEModel>.Projection.Include(e => e.DeathSave).Exclude(e => e.Id));

        [HttpPatch("{id}/DeathSave")]
        public async Task<IActionResult> UpdateDeathSave([FromRoute] string id, [FromBody] List<DeathSave> deathSaves) => await UpdateRpgModel(id, Builders<FiveEModel>.Update.Set(sheet => sheet.DeathSave, deathSaves), deathSaves);

        [HttpGet("{id}/Treasure")]
        public async Task<IActionResult> GetTreasure([FromRoute] string id) => await GetRpgModelPart(id, Builders<FiveEModel>.Projection.Include(e => e.Treasure).Exclude(e => e.Id));

        [HttpPatch("{id}/Treasure")]
        public async Task<IActionResult> UpdateTreasure([FromRoute] string id, [FromBody] List<Treasure> treasures) => await UpdateRpgModel(id, Builders<FiveEModel>.Update.Set(sheet => sheet.Treasure, treasures), treasures);

        [HttpGet("{id}/CharacterAppearance")]
        public async Task<IActionResult> GetCharacterAppearance([FromRoute] string id) => await GetRpgModelPart(id, Builders<FiveEModel>.Projection.Include(e => e.CharacterAppearance).Exclude(e => e.Id));

        [HttpPatch("{id}/CharacterAppearance")]
        public async Task<IActionResult> UpdateCharacterAppearance([FromRoute] string id, [FromBody] List<CharacterAppearance> characterAppearances) => await UpdateRpgModel(id, Builders<FiveEModel>.Update.Set(sheet => sheet.CharacterAppearance, characterAppearances), characterAppearances);

        [HttpGet("{id}/FeaturesTraits")]
        public async Task<IActionResult> GetFeaturesTraits([FromRoute] string id) => await GetRpgModelPart(id, Builders<FiveEModel>.Projection.Include(e => e.FeaturesTraits).Exclude(e => e.Id));

        [HttpPatch("{id}/FeaturesTraits")]
        public async Task<IActionResult> UpdateFeaturesTraits([FromRoute] string id, [FromBody] List<FeaturesTrait> featuresTraits) => await UpdateRpgModel(id, Builders<FiveEModel>.Update.Set(sheet => sheet.FeaturesTraits, featuresTraits), featuresTraits);

        [HttpGet("{id}/Equipment")]
        public async Task<IActionResult> GetEquipment([FromRoute] string id) => await GetRpgModelPart(id, Builders<FiveEModel>.Projection.Include(e => e.Equipment).Exclude(e => e.Id));

        [HttpPatch("{id}/Equipment")]
        public async Task<IActionResult> UpdateEquipment([FromRoute] string id, [FromBody] Equipment equipment) => await UpdateRpgModel(id, Builders<FiveEModel>.Update.Set(sheet => sheet.Equipment, equipment), equipment);

        [HttpGet("{id}/MagicItems")]
        public async Task<IActionResult> GetMagicItems([FromRoute] string id) => await GetRpgModelPart(id, Builders<FiveEModel>.Projection.Include(e => e.MagicItems).Exclude(e => e.Id));

        [HttpPatch("{id}/MagicItems")]
        public async Task<IActionResult> UpdateMagicItems([FromRoute] string id, [FromBody] List<MagicItem> magicItems) => await UpdateRpgModel(id, Builders<FiveEModel>.Update.Set(sheet => sheet.MagicItems, magicItems), magicItems);

        [HttpGet("{id}/Notes")]
        public async Task<IActionResult> GetNotes([FromRoute] string id) => await GetRpgModelPart(id, Builders<FiveEModel>.Projection.Include(e => e.Notes).Exclude(e => e.Id));

        [HttpPatch("{id}/Notes")]
        public async Task<IActionResult> UpdateNotes([FromRoute] string id, [FromBody] List<Note> notes) => await UpdateRpgModel(id, Builders<FiveEModel>.Update.Set(sheet => sheet.Notes, notes), notes);

        [HttpGet("{id}/Spells")]
        public async Task<IActionResult> GetSpells([FromRoute] string id) => await GetRpgModelPart(id, Builders<FiveEModel>.Projection.Include(e => e.Spells).Exclude(e => e.Id));

        [HttpPatch("{id}/Spells")]
        public async Task<IActionResult> UpdateSpells([FromRoute] string id, [FromBody] Spells spells) => await UpdateRpgModel(id, Builders<FiveEModel>.Update.Set(sheet => sheet.Spells, spells), spells);

        [HttpGet("{id}/Feats")]
        public async Task<IActionResult> GetFeats([FromRoute] string id) => await GetRpgModelPart(id, Builders<FiveEModel>.Projection.Include(e => e.Feats).Exclude(e => e.Id));

        [HttpPatch("{id}/Feats")]
        public async Task<IActionResult> UpdateFeats([FromRoute] string id, [FromBody] List<Feat> feats) => await UpdateRpgModel(id, Builders<FiveEModel>.Update.Set(sheet => sheet.Feats, feats), feats);

        [HttpPost("{id}/Items")]
        public async Task<IActionResult> InsertOneItem([FromRoute] string charId, [FromBody] Item item)
        {
            var collection = MongoDb.GetCollection<FiveEModel>("RpgCharModels");
            var deleteCollection = MongoDb.GetCollection<FiveEModel>("RpgCharModelsDeleted");
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var filter = Builders<FiveEModel>.Filter.And(
                Builders<FiveEModel>.Filter.Eq(x => x.Id, charId),
                Builders<FiveEModel>.Filter.Eq(x => x.OwnerID, userId));

            var update = Builders<FiveEModel>.Update.Push(x => x.Items, item);

            var result = await collection.FindOneAndUpdateAsync(filter, update);

            return Ok();
        }

        [HttpPatch("{characterId}/Items/{itemId}")]
        public async Task<IActionResult> UpdateSingleItem([FromRoute] string characterId, [FromRoute] string itemId, [FromBody] Item item)
        {
            var collection = MongoDb.GetCollection<FiveEModel>("RpgCharModels");
            var deleteCollection = MongoDb.GetCollection<FiveEModel>("RpgCharModelsDeleted");
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var filter = Builders<FiveEModel>.Filter.And(
                Builders<FiveEModel>.Filter.Eq(x => x.Id, characterId),
                Builders<FiveEModel>.Filter.Eq(x => x.OwnerID, userId),
                Builders<FiveEModel>.Filter.ElemMatch(x => x.Items, x=> x.Id == itemId));

            var update = Builders<FiveEModel>.Update.Set(x => x.Items[-1], item);

            var result = await collection.UpdateOneAsync(filter, update, new UpdateOptions { IsUpsert = true });

            return result.IsAcknowledged ? Ok() : (IActionResult)BadRequest();
        }

        [HttpDelete("{characterId}/Items/{itemId}")]
        public async Task<IActionResult> DeleteSingleItem([FromRoute] string characterId, [FromRoute] string itemId)
        {
            var collection = MongoDb.GetCollection<FiveEModel>("RpgCharModels");
            var deleteCollection = MongoDb.GetCollection<FiveEModel>("RpgCharModelsDeleted");
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var filter = Builders<FiveEModel>.Filter.And(
                Builders<FiveEModel>.Filter.Eq(x => x.Id, characterId),
                Builders<FiveEModel>.Filter.Eq(x => x.OwnerID, userId),
                Builders<FiveEModel>.Filter.ElemMatch(x => x.Items, x => x.Id == itemId));

            var update = Builders<FiveEModel>.Update.PullFilter(x => x.Items, i => i.Id == itemId);

            var result = await collection.UpdateOneAsync(filter, update);

            return result.IsAcknowledged ? Ok() : (IActionResult)BadRequest();
        }

        private async Task<IActionResult> UpdateRpgModel(string id, UpdateDefinition<FiveEModel> updateMethod, dynamic returnData)
        {
            var collection = MongoDb.GetCollection<FiveEModel>("RpgCharModels");
            var stringId = id.ToString();
            updateMethod = updateMethod.CurrentDate(s => s._lastUpdated);
            try
            {
                await collection.UpdateOneAsync(filter => filter.Id == stringId, updateMethod);
            }
            catch (System.Exception e)
            {
                throw e;
            }
            
            return Ok(returnData);
        }

        private async Task<IActionResult> GetRpgModelPart(string id, ProjectionDefinition<FiveEModel, dynamic> projectionDefinition)
        {
            try
            {
                var collection = MongoDb.GetCollection<FiveEModel>("RpgCharModels");
                var stringId = id.ToString();
                var list = await collection.Find(f => f.Id == stringId).Project(projectionDefinition).ToListAsync();
                if(list.Count > 0)
                {
                    return Ok(list[0]);
                }
                return NoContent();
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
    }
}