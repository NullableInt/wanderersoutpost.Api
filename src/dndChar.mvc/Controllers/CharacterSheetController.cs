using System;
using System.Threading.Tasks;

using dndChar.ActionModels;
using dndChar.Api.Util;
using dndChar.Database;
using dndChar.Models.BaseStats;
using dndChar.Models.Currency;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Raven.Client.Documents;

namespace dndChar.mvc.Controllers
{
    [Route("CharacterSheet")]
    [ApiController]
    public class CharacterSheetController : Controller
    {
        public IDocumentStore Store { get; set; }

        public UserManager<IdentityUser> UserManager { get; set; }

        public CharacterSheetController(UserManager<IdentityUser> userManager, DocumentStoreHolder holder)
        {
            UserManager = userManager;
            Store = holder.Store;
        }

        [Action("[BASESTATS] update ability saving throw")]
        [HttpPost("{characterSheetId}")]
        public async Task<IActionResult> UpdateSavingThrow([FromRoute] string characterSheetId, [FromBody] UpdateAbilitySavingThrowAction payload)
        {
            return await UpdateCharacterSheetModel(characterSheetId, sheet =>
            {
                for (var index = 0; index < sheet.BaseCharacterModelState.savingThrows.Length; index++)
                {
                    var abilitySavingThrow = sheet.BaseCharacterModelState.savingThrows[index];
                    if (abilitySavingThrow.ability.name.Equals(payload.Payload.ability.name))
                    {
                        sheet.BaseCharacterModelState.savingThrows[index] = payload.Payload;
                        return;
                    }
                }
            });
        }

        [Action("[ABILITYSCORE] update")]
        [HttpPost("{characterSheetId}")]
        public async Task<IActionResult> UpdateAbilityScore([FromRoute] string characterSheetId, [FromBody] UpdateAbilityScoreAction dynamic)
        {
            return await UpdateCharacterSheetModel(characterSheetId, sheet =>
            {
                switch (dynamic.Payload.name)
                {
                    case AbilityScoreName.strength:
                        sheet.BaseCharacterModelState.baseStats.strength = dynamic.Payload;
                        break;
                    case AbilityScoreName.dexterity:
                        sheet.BaseCharacterModelState.baseStats.dexterity = dynamic.Payload;
                        break;
                    case AbilityScoreName.constitution:
                        sheet.BaseCharacterModelState.baseStats.constitution = dynamic.Payload;
                        break;
                    case AbilityScoreName.intelligence:
                        sheet.BaseCharacterModelState.baseStats.intelligence = dynamic.Payload;
                        break;
                    case AbilityScoreName.wisdom:
                        sheet.BaseCharacterModelState.baseStats.wisdom = dynamic.Payload;
                        break;
                    case AbilityScoreName.charisma:
                        sheet.BaseCharacterModelState.baseStats.constitution= dynamic.Payload;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            });
        }
        
        [Action("[BASESTATS] update character alignment")]
        [HttpPost("{characterSheetId}")]
        public async Task<IActionResult> UpdateCharacterAlignment([FromRoute] string characterSheetId,
                                                                  [FromBody] UpdateCharacterAlignmentAction dynamic)
        {
            return await UpdateCharacterSheetModel(characterSheetId, sheet =>
            {
                sheet.BaseCharacterModelState.baseStats.characterAlignment = dynamic.Payload;
            });
        }


        

        [Action("[BASESTATS] update character level")]
        [HttpPost("{characterSheetId}")]
        public async Task<IActionResult> UpdateCharacterLevel([FromRoute] string characterSheetId,
                                                              [FromBody] UpdateCharacterLevelAction dynamic)
        {
            return await UpdateCharacterSheetModel(characterSheetId, sheet =>
            {
                sheet.BaseCharacterModelState.baseStats.level = dynamic.Payload;
            });
        }

        [Action("[TREASURE] update currency")]
        [HttpPost("{characterSheetId}")]
        public async Task<IActionResult> UpdateCurrency([FromRoute] string characterSheetId, [FromBody] UpdateCurrencyAction dynamic)
        {
            return await UpdateCharacterSheetModel(characterSheetId, sheet =>
            {
                switch (dynamic.Currency)
                {
                    case Currency.copper:
                        sheet.CurrencyState.copper = dynamic.Payload;
                        break;
                    case Currency.silver:
                        sheet.CurrencyState.silver = dynamic.Payload;
                        break;
                    case Currency.electrum:
                        sheet.CurrencyState.electrum = dynamic.Payload;
                        break;
                    case Currency.gold:
                        sheet.CurrencyState.gold = dynamic.Payload;
                        break;
                    case Currency.platinum:
                        sheet.CurrencyState.platinum = dynamic.Payload;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            });
        }

        [Action("[BASESTATS] update damage taken")]
        [HttpPost("{characterSheetId}")]
        public async Task<IActionResult> UpdateDamageTaken([FromRoute] string characterSheetId, [FromBody] UpdateDamageTakenAction dynamic)
        {
            return await UpdateCharacterSheetModel(characterSheetId, sheet =>
            {
                sheet.BaseCharacterModelState.baseStats.damagedHitPoints = dynamic.Payload;
            });
        }

        [Action("[BASESTATS] update health")]
        [HttpPost("{characterSheetId}")]
        public async Task<IActionResult> UpdateHealth([FromRoute] string characterSheetId, [FromBody] UpdateHealthAction dynamic)
        {
            return await UpdateCharacterSheetModel(characterSheetId, sheet =>
            {
                sheet.BaseCharacterModelState.baseStats.MaxHitPoints = dynamic.Payload.Value;
                if (dynamic.Payload.FullHeal)
                {
                    sheet.BaseCharacterModelState.baseStats.damagedHitPoints = 0;
                }
            });
        }

        [Action("[BASESTATS] update inspiration")]
        [HttpPost("{characterSheetId}")]
        public async Task<IActionResult> UpdateInspiration([FromRoute] string characterSheetId, [FromBody] UpdateInspirationAction dynamic)
        {
            return await UpdateCharacterSheetModel(characterSheetId, sheet =>
            {
                sheet.BaseCharacterModelState.baseStats.inspiration = dynamic.Payload;
            });
        }

        [Action("[INVENTORY] update")]
        [HttpPost("{characterSheetId}")]
        public async Task<IActionResult> UpdateInventory([FromRoute] string characterSheetId, [FromBody] UpdateInventoryAction dynamic)
        {
            return await UpdateCharacterSheetModel(characterSheetId, sheet =>
            {
                if (sheet.InventoryState.ContainsKey(dynamic.InventoryName))
                {
                    sheet.InventoryState[dynamic.InventoryName] = dynamic.Payload;
                }
                else
                {
                    sheet.InventoryState.Add(dynamic.InventoryName, dynamic.Payload);
                }
            });
        }

        [Action("[SKILLS] update")]
        [HttpPost("{characterSheetId}")]
        public async Task<IActionResult> UpdateSkills([FromRoute] string characterSheetId, [FromBody] UpdateSkillModelAction dynamic)
        {
            return await UpdateCharacterSheetModel(characterSheetId, sheet =>
            {
                if (sheet.BaseCharacterModelState.Skills.ContainsKey(dynamic.Payload.Name))
                {
                    sheet.BaseCharacterModelState.Skills[dynamic.Payload.Name] = dynamic.Payload.ToSkillType();
                }
                else
                {
                    sheet.BaseCharacterModelState.Skills.Add(dynamic.Payload.Name, dynamic.Payload.ToSkillType());
                }
            });
        }

        [Action("[BASESTATS] update temporary hit points")]
        [HttpPost("{characterSheetId}")]
        public async Task<IActionResult> UpdateTemporaryHitpoints([FromRoute] string characterSheetId,
                                                                  [FromBody] UpdateTemporaryHitPointsAction dynamic)
        {
            return await UpdateCharacterSheetModel(characterSheetId, sheet =>
            {
                sheet.BaseCharacterModelState.baseStats.damagedHitPoints = dynamic.Payload;
            });
        }

        [Action("[TREASURE] update treasure model")]
        [HttpPost("{characterSheetId}")]
        public async Task<IActionResult> UpdateTreasures([FromRoute] string characterSheetId, [FromBody] UpdateTreasureModelAction dynamic)
        {
            return await UpdateCharacterSheetModel(characterSheetId, sheet =>
            {
                sheet.CurrencyState.treasure[dynamic.Index] = dynamic.Payload;
            });
        }
        
        public delegate void UpdateMethod(CharacterSheet characterSheet);
        
        public async Task<IActionResult> UpdateCharacterSheetModel(string characterSheetId, UpdateMethod updateMethod)
        {
            var user = await this.UserManager.GetUserAsync(HttpContext.User);
            using (var session = Store.OpenAsyncSession())
            {
                var characterSheet = await session.LoadAsync<CharacterSheet>("CharacterSheets/" + characterSheetId);
                if (characterSheet.ServerState.appUserId != Guid.Parse(user.Id))
                {
                    return new ForbidResult();
                }
                updateMethod(characterSheet);

                await session.SaveChangesAsync();
            }
            return Ok();
        }
    }
}
