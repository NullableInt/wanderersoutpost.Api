using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using dndChar.Database;
using dndChar.mvc.Models.RpgChar;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace dndChar.mvc.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class RpgCharController : Controller
    {
        public IMongoDatabase MongoDb { get; set; }

        public RpgCharController(DocumentStoreHolder holder)
        {
            MongoDb = holder.Store.GetDatabase("RpgCharModelDb");
        }

        [HttpGet("")]
        public async Task<IActionResult> IndexAsync()
        {
            var guidAsString = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var collection = MongoDb.GetCollection<RpgCharModel>("RpgCharModels");
            return Ok(await collection.Find(f => f.OwnerID == guidAsString).ToListAsync());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllById([FromRoute] Guid id)
        {
            return await GetRpgModelPart(id, Builders<RpgCharModel>.Projection.Include(e => e));
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> SetAll([FromRoute] Guid id, [FromBody] RpgCharModel dynamic)
        {
            var nameClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            var claims = User.Claims;
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            dynamic.OwnerID = userId;
            dynamic.Profile.CharacterId = id;
            var collection = MongoDb.GetCollection<RpgCharModel>("RpgCharModels");
            await collection.InsertOneAsync(dynamic);
            return Ok();
        }

        [HttpGet("{id}/Profile")]
        public async Task<IActionResult> GetProfile([FromRoute] Guid id) => await GetRpgModelPart(id, Builders<RpgCharModel>.Projection.Include(e => e.Profile));

        [HttpPatch("{id}/Profile")]
        public async Task<IActionResult> UpdateProfile([FromRoute] Guid id, [FromBody] Profile newProfile) => await UpdateRpgModel(id, Builders<RpgCharModel>.Update.Set(sheet => sheet.Profile, newProfile), newProfile);

        [HttpGet("{id}/Traits")]
        public async Task<IActionResult> GetTraits([FromRoute] Guid id) => await GetRpgModelPart(id, Builders<RpgCharModel>.Projection.Include(e => e.Traits));

        [HttpPatch("{id}/Traits")]
        public async Task<IActionResult> UpdateTraits([FromRoute] Guid id, [FromBody] List<Trait> traits) => await UpdateRpgModel(id, Builders<RpgCharModel>.Update.Set(sheet => sheet.Traits, traits), traits);

        [HttpGet("{id}/Items")]
        public async Task<IActionResult> GetItems([FromRoute] Guid id) => await GetRpgModelPart(id, Builders<RpgCharModel>.Projection.Include(e => e.Items));

        [HttpPatch("{id}/Items")]
        public async Task<IActionResult> UpdateItems([FromRoute] Guid id, [FromBody] List<Item> items) => await UpdateRpgModel(id, Builders<RpgCharModel>.Update.Set(sheet => sheet.Items, items), items);

        [HttpGet("{id}/AbilityScores")]
        public async Task<IActionResult> GetAbilityScores([FromRoute] Guid id) => await GetRpgModelPart(id, Builders<RpgCharModel>.Projection.Include(e => e.AbilityScores));

        [HttpPatch("{id}/AbilityScores")]
        public async Task<IActionResult> UpdateAbilityScores([FromRoute] Guid id, [FromBody] AbilityScores abilityScores) => await UpdateRpgModel(id, Builders<RpgCharModel>.Update.Set(sheet => sheet.AbilityScores, abilityScores), abilityScores);

        [HttpGet("{id}/Status")]
        public async Task<IActionResult> GetStatus([FromRoute] Guid id) => await GetRpgModelPart(id, Builders<RpgCharModel>.Projection.Include(e => e.Status));

        [HttpPatch("{id}/Status")]
        public async Task<IActionResult> UpdateStatus([FromRoute] Guid id, [FromBody] List<Status> statuses) => await UpdateRpgModel(id, Builders<RpgCharModel>.Update.Set(sheet => sheet.Status, statuses), statuses);

        [HttpGet("{id}/HitDice")]
        public async Task<IActionResult> GetHitDice([FromRoute] Guid id) => await GetRpgModelPart(id, Builders<RpgCharModel>.Projection.Include(e => e.HitDice));

        [HttpPatch("{id}/HitDice")]
        public async Task<IActionResult> UpdateHitDice([FromRoute] Guid id, [FromBody] List<HitDice> dice) => await UpdateRpgModel(id, Builders<RpgCharModel>.Update.Set(sheet => sheet.HitDice, dice), dice);

        [HttpGet("{id}/Health")]
        public async Task<IActionResult> GetHealth([FromRoute] Guid id) => await GetRpgModelPart(id, Builders<RpgCharModel>.Projection.Include(e => e.Health));

        [HttpPatch("{id}/Health")]
        public async Task<IActionResult> UpdateHealth([FromRoute] Guid id, [FromBody] Health health) => await UpdateRpgModel(id, Builders<RpgCharModel>.Update.Set(sheet => sheet.Health, health), health);

        [HttpGet("{id}/SavingThrows")]
        public async Task<IActionResult> GetSavingThrows([FromRoute] Guid id) => await GetRpgModelPart(id, Builders<RpgCharModel>.Projection.Include(e => e.SavingThrows));

        [HttpPatch("{id}/SavingThrows")]
        public async Task<IActionResult> UpdateSavingThrows([FromRoute] Guid id, [FromBody] List<SavingThrow> savingThrows) => await UpdateRpgModel(id, Builders<RpgCharModel>.Update.Set(sheet => sheet.SavingThrows, savingThrows), savingThrows);

        [HttpGet("{id}/Skills")]
        public async Task<IActionResult> GetSkills([FromRoute] Guid id) => await GetRpgModelPart(id, Builders<RpgCharModel>.Projection.Include(e => e.Skills));

        [HttpPatch("{id}/Skills")]
        public async Task<IActionResult> UpdateSkills([FromRoute] Guid id, [FromBody] List<Skill> skills) => await UpdateRpgModel(id, Builders<RpgCharModel>.Update.Set(sheet => sheet.Skills, skills), skills);

        [HttpGet("{id}/HitDiceType")]
        public async Task<IActionResult> GetHitDiceType([FromRoute] Guid id) => await GetRpgModelPart(id, Builders<RpgCharModel>.Projection.Include(e => e.HitDiceType));

        [HttpPatch("{id}/HitDiceType")]
        public async Task<IActionResult> UpdateHitDiceType([FromRoute] Guid id, [FromBody] List<HitDiceTypeModel> hitDices) => await UpdateRpgModel(id, Builders<RpgCharModel>.Update.Set(sheet => sheet.HitDiceType, hitDices), hitDices);

        [HttpGet("{id}/DeathSave")]
        public async Task<IActionResult> GetDeathSave([FromRoute] Guid id) => await GetRpgModelPart(id, Builders<RpgCharModel>.Projection.Include(e => e.DeathSave));

        [HttpPatch("{id}/DeathSave")]
        public async Task<IActionResult> UpdateDeathSave([FromRoute] Guid id, [FromBody] List<DeathSave> deathSaves) => await UpdateRpgModel(id, Builders<RpgCharModel>.Update.Set(sheet => sheet.DeathSave, deathSaves), deathSaves);

        [HttpGet("{id}/Treasure")]
        public async Task<IActionResult> GetTreasure([FromRoute] Guid id) => await GetRpgModelPart(id, Builders<RpgCharModel>.Projection.Include(e => e.Treasure));

        [HttpPatch("{id}/Treasure")]
        public async Task<IActionResult> UpdateTreasure([FromRoute] Guid id, [FromBody] List<Treasure> treasures) => await UpdateRpgModel(id, Builders<RpgCharModel>.Update.Set(sheet => sheet.Treasure, treasures), treasures);

        [HttpGet("{id}/CharacterAppearance")]
        public async Task<IActionResult> GetCharacterAppearance([FromRoute] Guid id) => await GetRpgModelPart(id, Builders<RpgCharModel>.Projection.Include(e => e.CharacterAppearance));

        [HttpPatch("{id}/CharacterAppearance")]
        public async Task<IActionResult> UpdateCharacterAppearance([FromRoute] Guid id, [FromBody] List<CharacterAppearance> characterAppearances) => await UpdateRpgModel(id, Builders<RpgCharModel>.Update.Set(sheet => sheet.CharacterAppearance, characterAppearances), characterAppearances);

        [HttpGet("{id}/FeaturesTraits")]
        public async Task<IActionResult> GetFeaturesTraits([FromRoute] Guid id) => await GetRpgModelPart(id, Builders<RpgCharModel>.Projection.Include(e => e.FeaturesTraits));

        [HttpPatch("{id}/FeaturesTraits")]
        public async Task<IActionResult> UpdateFeaturesTraits([FromRoute] Guid id, [FromBody] List<FeaturesTrait> featuresTraits) => await UpdateRpgModel(id, Builders<RpgCharModel>.Update.Set(sheet => sheet.FeaturesTraits, featuresTraits), featuresTraits);

        [HttpGet("{id}/Equipment")]
        public async Task<IActionResult> GetEquipment([FromRoute] Guid id) => await GetRpgModelPart(id, Builders<RpgCharModel>.Projection.Include(e => e.Equipment));

        [HttpPatch("{id}/Equipment")]
        public async Task<IActionResult> UpdateEquipment([FromRoute] Guid id, [FromBody] Equipment equipment) => await UpdateRpgModel(id, Builders<RpgCharModel>.Update.Set(sheet => sheet.Equipment, equipment), equipment);

        [HttpGet("{id}/MagicItems")]
        public async Task<IActionResult> GetMagicItems([FromRoute] Guid id) => await GetRpgModelPart(id, Builders<RpgCharModel>.Projection.Include(e => e.MagicItems));

        [HttpPatch("{id}/MagicItems")]
        public async Task<IActionResult> UpdateMagicItems([FromRoute] Guid id, [FromBody] List<MagicItem> magicItems) => await UpdateRpgModel(id, Builders<RpgCharModel>.Update.Set(sheet => sheet.MagicItems, magicItems), magicItems);

        [HttpGet("{id}/Notes")]
        public async Task<IActionResult> GetNotes([FromRoute] Guid id) => await GetRpgModelPart(id, Builders<RpgCharModel>.Projection.Include(e => e.Notes));

        [HttpPatch("{id}/Notes")]
        public async Task<IActionResult> UpdateNotes([FromRoute] Guid id, [FromBody] List<Note> notes) => await UpdateRpgModel(id, Builders<RpgCharModel>.Update.Set(sheet => sheet.Notes, notes), notes);

        [HttpGet("{id}/Spells")]
        public async Task<IActionResult> GetSpells([FromRoute] Guid id) => await GetRpgModelPart(id, Builders<RpgCharModel>.Projection.Include(e => e.Spells));

        [HttpPatch("{id}/Spells")]
        public async Task<IActionResult> UpdateSpells([FromRoute] Guid id, [FromBody] Spells spells) => await UpdateRpgModel(id, Builders<RpgCharModel>.Update.Set(sheet => sheet.Spells, spells), spells);

        [HttpGet("{id}/Feats")]
        public async Task<IActionResult> GetFeats([FromRoute] Guid id) => await GetRpgModelPart(id, Builders<RpgCharModel>.Projection.Include(e => e.Feats));

        [HttpPatch("{id}/Feats")]
        public async Task<IActionResult> UpdateFeats([FromRoute] Guid id, [FromBody] List<Feat> feats) => await UpdateRpgModel(id, Builders<RpgCharModel>.Update.Set(sheet => sheet.Feats, feats), feats);

        public async Task<IActionResult> UpdateRpgModel(Guid id, UpdateDefinition<RpgCharModel> updateMethod, dynamic returnData)
        {
            var collection = MongoDb.GetCollection<RpgCharModel>("RpgCharModels");

            await collection.FindOneAndUpdateAsync(filter => filter.Profile.CharacterId == id, updateMethod);
            return Ok(returnData);
        }

        public async Task<IActionResult> GetRpgModelPart(Guid id, ProjectionDefinition<RpgCharModel, dynamic> projectionDefinition)
        {
            var guidAsString = id.ToString();
            var collection = MongoDb.GetCollection<RpgCharModel>("RpgCharModels");
            return Ok(await collection.Find(f => f.OwnerID == guidAsString).Project(projectionDefinition).ToListAsync());
        }
    }
}