using System;
using System.Threading.Tasks;
using dndChar.Database;
using dndCharApi;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace dndCharApi.Controllers
{
    [Route("CharacterSheet")]
    [ApiController]
    public class CharacterSheetController : Controller
    {
        public IMongoDatabase MongoDb { get; set; }

        public UserManager<IdentityUser> UserManager { get; set; }

        public CharacterSheetController(UserManager<IdentityUser> userManager, DocumentStoreHolder holder)
        {
            UserManager = userManager;
            MongoDb = holder.Store.GetDatabase("CharacterSheetDb");
        }

        /*
         * Someone please help
        [Action("[BASESTATS] update ability saving throw")]
        [HttpPost("{characterSheetId}")]
        public async Task<IActionResult> UpdateSavingThrow([FromRoute] Guid characterSheetId, [FromBody] UpdateAbilitySavingThrowAction payload)
        {
            var user = await this.UserManager.GetUserAsync(HttpContext.User);

            var collection = MongoDb.GetCollection<CharacterSheet>("CharacterSheets");
            await collection.FindOneAndUpdateAsync(filter => 
            filter.ServerState.appUserId == characterSheetId, sheet => sheet.BaseCharacterModelState.savingThrows[sheet.BaseCharacterModelState.savingThrows.FindIndex(e => e.ability.name == payload.Payload.ability.name)], payload.Payload );
            return Ok();
        }

        [Action("[ABILITYSCORE] update")]
        [HttpPost("{characterSheetId}")]
        public async Task<IActionResult> UpdateAbilityScore([FromRoute] Guid characterSheetId, [FromBody] UpdateAbilityScoreAction dynamic)
        {
            switch (dynamic.Payload.name)
            {
                case AbilityScoreName.strength:
                    return await UpdateCharacterSheetModel(characterSheetId, Builders<CharacterSheet>.Update.Set(sheet => sheet.BaseCharacterModelState.baseStats.strength, dynamic.Payload));
                case AbilityScoreName.dexterity:
                    return await UpdateCharacterSheetModel(characterSheetId, Builders<CharacterSheet>.Update.Set(sheet => sheet.BaseCharacterModelState.baseStats.dexterity, dynamic.Payload));
                case AbilityScoreName.constitution:
                    return await UpdateCharacterSheetModel(characterSheetId, Builders<CharacterSheet>.Update.Set(sheet => sheet.BaseCharacterModelState.baseStats.constitution, dynamic.Payload));
                case AbilityScoreName.intelligence:
                    return await UpdateCharacterSheetModel(characterSheetId, Builders<CharacterSheet>.Update.Set(sheet => sheet.BaseCharacterModelState.baseStats.intelligence, dynamic.Payload));
                case AbilityScoreName.wisdom:
                    return await UpdateCharacterSheetModel(characterSheetId, Builders<CharacterSheet>.Update.Set(sheet => sheet.BaseCharacterModelState.baseStats.wisdom, dynamic.Payload));
                case AbilityScoreName.charisma:
                    return await UpdateCharacterSheetModel(characterSheetId, Builders<CharacterSheet>.Update.Set(sheet => sheet.BaseCharacterModelState.baseStats.constitution, dynamic.Payload));
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        [Action("[BASESTATS] update character alignment")]
        [HttpPost("{characterSheetId}")]
        public async Task<IActionResult> UpdateCharacterAlignment([FromRoute] Guid characterSheetId,
                                                                  [FromBody] UpdateCharacterAlignmentAction dynamic)
        {
            return await UpdateCharacterSheetModel(characterSheetId, Builders<CharacterSheet>.Update.Set(sheet =>
                sheet.BaseCharacterModelState.baseStats.characterAlignment, dynamic.Payload));
        }


        

        [Action("[BASESTATS] update character level")]
        [HttpPost("{characterSheetId}")]
        public async Task<IActionResult> UpdateCharacterLevel([FromRoute] Guid characterSheetId,
                                                              [FromBody] UpdateCharacterLevelAction dynamic)
        {
            return await UpdateCharacterSheetModel(characterSheetId, Builders<CharacterSheet>.Update.Set(sheet =>
                sheet.BaseCharacterModelState.baseStats.level,dynamic.Payload));
        }

        [Action("[TREASURE] update currency")]
        [HttpPost("{characterSheetId}")]
        public async Task<IActionResult> UpdateCurrency([FromRoute] Guid characterSheetId, [FromBody] UpdateCurrencyAction dynamic)
        {
            switch (dynamic.Currency)
            {
                case Currency.copper:
                    return await UpdateCharacterSheetModel(characterSheetId, Builders<CharacterSheet>.Update.Set(sheet => sheet.CurrencyState.copper, dynamic.Payload));
                case Currency.silver:
                    return await UpdateCharacterSheetModel(characterSheetId, Builders<CharacterSheet>.Update.Set(sheet => sheet.CurrencyState.silver, dynamic.Payload));
                case Currency.electrum:
                    return await UpdateCharacterSheetModel(characterSheetId, Builders<CharacterSheet>.Update.Set(sheet => sheet.CurrencyState.electrum, dynamic.Payload));
                case Currency.gold:
                    return await UpdateCharacterSheetModel(characterSheetId, Builders<CharacterSheet>.Update.Set(sheet => sheet.CurrencyState.gold, dynamic.Payload));
                case Currency.platinum:
                    return await UpdateCharacterSheetModel(characterSheetId, Builders<CharacterSheet>.Update.Set(sheet => sheet.CurrencyState.platinum, dynamic.Payload));
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        [Action("[BASESTATS] update damage taken")]
        [HttpPost("{characterSheetId}")]
        public async Task<IActionResult> UpdateDamageTaken([FromRoute] Guid characterSheetId, [FromBody] UpdateDamageTakenAction dynamic)
        {
            return await UpdateCharacterSheetModel(characterSheetId, Builders<CharacterSheet>.Update.Set(sheet => sheet.BaseCharacterModelState.baseStats.damagedHitPoints, dynamic.Payload));
        }

        [Action("[BASESTATS] update health")]
        [HttpPost("{characterSheetId}")]
        public async Task<IActionResult> UpdateHealth([FromRoute] Guid characterSheetId, [FromBody] UpdateHealthAction dynamic)
        {
            if (dynamic.Payload.FullHeal)
                return await UpdateCharacterSheetModel(characterSheetId, Builders<CharacterSheet>.Update.Set(sheet => sheet.BaseCharacterModelState.baseStats.damagedHitPoints, 0));
            return await UpdateCharacterSheetModel(characterSheetId, Builders<CharacterSheet>.Update.Set(sheet => sheet.BaseCharacterModelState.baseStats.damagedHitPoints, dynamic.Payload.Value));
        }

        [Action("[BASESTATS] update inspiration")]
        [HttpPost("{characterSheetId}")]
        public async Task<IActionResult> UpdateInspiration([FromRoute] Guid characterSheetId, [FromBody] UpdateInspirationAction dynamic)
        {
            return await UpdateCharacterSheetModel(characterSheetId, Builders<CharacterSheet>.Update.Set(sheet => sheet.BaseCharacterModelState.baseStats.inspiration, dynamic.Payload));
        }

        [Action("[INVENTORY] update")]
        [HttpPost("{characterSheetId}")]
        public async Task<IActionResult> UpdateInventory([FromRoute] Guid characterSheetId, [FromBody] UpdateInventoryAction dynamic)
        {
            return await UpdateCharacterSheetModel(characterSheetId, Builders<CharacterSheet>.Update.Set(sheet =>
                    sheet.InventoryState[dynamic.InventoryName], dynamic.Payload));
        }

        [Action("[SKILLS] update")]
        [HttpPost("{characterSheetId}")]
        public async Task<IActionResult> UpdateSkills([FromRoute] Guid characterSheetId, [FromBody] UpdateSkillModelAction dynamic)
        {
            return await UpdateCharacterSheetModel(characterSheetId, Builders<CharacterSheet>.Update.Set(sheet =>
            sheet.BaseCharacterModelState.Skills[dynamic.Payload.Name], dynamic.Payload.ToSkillType()));
        }

        [Action("[BASESTATS] update temporary hit points")]
        [HttpPost("{characterSheetId}")]
        public async Task<IActionResult> UpdateTemporaryHitpoints([FromRoute] Guid characterSheetId,
                                                                  [FromBody] UpdateTemporaryHitPointsAction dynamic)
        {
            return await UpdateCharacterSheetModel(characterSheetId, Builders<CharacterSheet>.Update.Set(sheet => sheet.BaseCharacterModelState.baseStats.damagedHitPoints, dynamic.Payload));
        }

        [Action("[TREASURE] update treasure model")]
        [HttpPost("{characterSheetId}")]
        public async Task<IActionResult> UpdateTreasures([FromRoute] Guid characterSheetId, [FromBody] UpdateTreasureModelAction dynamic) => await UpdateCharacterSheetModel(characterSheetId, Builders<CharacterSheet>.Update.Set(e => e.CurrencyState.treasure[dynamic.Index], dynamic.Payload));


        public async Task<IActionResult> UpdateCharacterSheetModel(Guid characterSheetId, UpdateDefinition<CharacterSheet> updateMethod)
        {
            var user = await this.UserManager.GetUserAsync(HttpContext.User);
            
            var collection = MongoDb.GetCollection<CharacterSheet>("CharacterSheets");
            await collection.FindOneAndUpdateAsync(filter => filter.ServerState.appUserId == characterSheetId, updateMethod);
            return Ok();
        }
        */
    }
}
