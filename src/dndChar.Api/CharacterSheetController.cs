using System;
using System.Threading.Tasks;
using dndChar.ActionModels;
using dndChar.Api.Util;
using Microsoft.AspNetCore.Mvc;

namespace dndChar.Api
{
    [Route("CharacterSheet")]
    [ApiController]
    public class CharacterSheetController : Controller
    {
        [Action("[BASESTATS] update ability saving throw")]
        [HttpPost("{characterSheetId}")]
        public async Task<IActionResult> UpdateSavingThrow([FromRoute] Guid characterSheetId, [FromBody] UpdateAbilitySavingThrowAction payload)
        {
            await Task.CompletedTask;
            return new OkResult();
        }

        [Action("[ABILITYSCORE] update")]
        [HttpPost("{characterSheetId}")]
        public async Task<IActionResult> UpdateAbilityScore(UpdateAbilityScoreAction dynamic)
        {
            await Task.CompletedTask;
            return new OkResult();
        }

        [Action("[BASESTATS] update")]
        [HttpPost("{characterSheetId}")]
        public async Task<IActionResult> UpdateBaseStats(UpdateBaseStatsModelAction dynamic)
        {
            await Task.CompletedTask;
            return new OkResult();
        }

        [Action("[BASESTATS] update character alignment")]
        [HttpPost("{characterSheetId}")]
        public async Task<IActionResult> UpdateCharacterAlignment(UpdateCharacterAlignmentAction dynamic)
        {
            await Task.CompletedTask;
            return new OkResult();
        }

        [Action("[BASESTATS] update character level")]
        [HttpPost("{characterSheetId}")]
        public async Task<IActionResult> UpdateCharacterLevel(UpdateCharacterLevelAction dynamic)
        {
            await Task.CompletedTask;
            return new OkResult();
        }

        [Action("[TREASURE] update currency")]
        [HttpPost("{characterSheetId}")]
        public async Task<IActionResult> UpdateCurrency(UpdateCurrencyAction dynamic)
        {
            await Task.CompletedTask;
            return new OkResult();
        }

        [Action("[TREASURE] update total currency")]
        [HttpPost("{characterSheetId}")]
        public async Task<IActionResult> UpdateTotalCurrency(UpdateCurrencyTotalsActions dynamic)
        {
            await Task.CompletedTask;
            return new OkResult();
        }

        [Action("[BASESTATS] update damage taken")]
        [HttpPost("{characterSheetId}")]
        public async Task<IActionResult> UpdateDamageTaken(UpdateDamageTakenAction dynamic)
        {
            await Task.CompletedTask;
            return new OkResult();
        }

        [Action("[BASESTATS] update health")]
        [HttpPost("{characterSheetId}")]
        public async Task<IActionResult> UpdateHealth(UpdateHealthAction dynamic)
        {
            await Task.CompletedTask;
            return new OkResult();
        }

        [Action("[BASESTATS] update inspiration")]
        [HttpPost("{characterSheetId}")]
        public async Task<IActionResult> UpdateInspiration(UpdateInspirationAction dynamic)
        {
            await Task.CompletedTask;
            return new OkResult();
        }

        [Action("[INVENTORY] update")]
        [HttpPost("{characterSheetId}")]
        public async Task<IActionResult> UpdateInventory(UpdateInventoryAction dynamic)
        {
            await Task.CompletedTask;
            return new OkResult();
        }

        [Action("[SKILLS] update")]
        [HttpPost("{characterSheetId}")]
        public async Task<IActionResult> UpdateSkills(UpdateSkillModelAction dynamic)
        {
            await Task.CompletedTask;
            return new OkResult();
        }

        [Action("[BASESTATS] update temporary hit points")]
        [HttpPost("{characterSheetId}")]
        public async Task<IActionResult> UpdateTemporaryHitpoints(UpdateTemporaryHitPointsAction dynamic)
        {
            await Task.CompletedTask;
            return new OkResult();
        }

        [Action("[TREASURE] update treasure model")]
        [HttpPost("{characterSheetId}")]
        public async Task<IActionResult> UpdateTreasures(UpdateTreasureModelAction dynamic)
        {
            await Task.CompletedTask;
            return new OkResult();
        }
    }
}
