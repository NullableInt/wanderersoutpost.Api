using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dndChar.Database;
using dndChar.mvc.Models.RpgChar;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Raven.Client.Documents;

namespace dndChar.mvc.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class RpgCharController : Controller
    {
        public IDocumentStore Store { get; set; }

        public RpgCharController(DocumentStoreHolder holder)
        {
            Store = holder.Store;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return Ok("Wow it works");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll([FromRoute] Guid id)
        {
            using (var session = Store.OpenAsyncSession())
            {
                var character = await session.LoadAsync<RpgCharModel>($"RpgChar/{id}");
                if (character != null && character.Profile != null)
                {
                    return Ok(character);
                }
                return BadRequest();
            }
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> SetAll([FromRoute] Guid id, [FromBody] RpgCharModel dynamic)
        {
            dynamic.Profile.CharacterId = id;
            using (var session = Store.OpenAsyncSession())
            {
                await session.StoreAsync(dynamic, $"RpgChar/{id}");

                await session.SaveChangesAsync();
            }
            return Ok();
        }

        [HttpGet("{id}/Profile")]
        public async Task<IActionResult> GetProfile([FromRoute] Guid id)
        {
            using (var session = Store.OpenAsyncSession())
            {
                var character = await session.LoadAsync<RpgCharModel>($"RpgChar/{id}");
                if (character != null && character.Profile != null)
                {
                    return Ok(character.Profile);
                }
                return BadRequest();
            }
        }

        [HttpPatch("{id}/Profile")]
        public async Task<IActionResult> UpdateProfile([FromRoute] Guid id, [FromBody] Profile newProfile)
        {
            return await UpdateRpgModel(id, (sheet) =>
            {
                return sheet.Profile = newProfile;
            });
        }

        [HttpGet("{id}/Traits")]
        public async Task<IActionResult> GetTraits([FromRoute] Guid id)
        {
            using (var session = Store.OpenAsyncSession())
            {
                var character = await session.LoadAsync<RpgCharModel>($"RpgChar/{id}");
                if (character != null && character.Traits != null)
                {
                    return Ok(character.Traits);
                }
                return BadRequest();
            }
        }

        [HttpPatch("{id}/Traits")]
        public async Task<IActionResult> UpdateTraits([FromRoute] Guid id, [FromBody] List<Trait> traits)
        {
            return await UpdateRpgModel(id, (sheet) =>
            {
                return sheet.Traits = traits;
            });
        }

        [HttpGet("{id}/Items")]
        public async Task<IActionResult> GetItems([FromRoute] Guid id)
        {
            using (var session = Store.OpenAsyncSession())
            {
                var character = await session.LoadAsync<RpgCharModel>($"RpgChar/{id}");
                if (character != null && character.Items != null)
                {
                    return Ok(character.Items);
                }
                return BadRequest();
            }
        }

        [HttpPatch("{id}/Items")]
        public async Task<IActionResult> UpdateItems([FromRoute] Guid id, [FromBody] List<Item> items)
        {
            return await UpdateRpgModel(id, (sheet) =>
            {
                return sheet.Items = items;
            });
        }

        [HttpGet("{id}/AbilityScores")]
        public async Task<IActionResult> GetAbilityScores([FromRoute] Guid id)
        {
            using (var session = Store.OpenAsyncSession())
            {
                var character = await session.LoadAsync<RpgCharModel>($"RpgChar/{id}");
                if (character != null && character.AbilityScores != null)
                {
                    return Ok(character.AbilityScores);
                }
                return BadRequest();
            }
        }

        [HttpPatch("{id}/AbilityScores")]
        public async Task<IActionResult> UpdateAbilityScores([FromRoute] Guid id, [FromBody] AbilityScores abilityScores)
        {
            return await UpdateRpgModel(id, (sheet) =>
            {
                return sheet.AbilityScores = abilityScores;
            });
        }

        [HttpGet("{id}/Status")]
        public async Task<IActionResult> GetStatus([FromRoute] Guid id)
        {
            using (var session = Store.OpenAsyncSession())
            {
                var character = await session.LoadAsync<RpgCharModel>($"RpgChar/{id}");
                if (character != null && character.Status != null)
                {
                    return Ok(character.Status);
                }
                return BadRequest();
            }
        }

        [HttpPatch("{id}/Status")]
        public async Task<IActionResult> UpdateStatus([FromRoute] Guid id, [FromBody] List<Status> statuses)
        {
            return await UpdateRpgModel(id, (sheet) =>
            {
                return sheet.Status = statuses;
            });
        }

        [HttpGet("{id}/HitDice")]
        public async Task<IActionResult> GetHitDice([FromRoute] Guid id)
        {
            using (var session = Store.OpenAsyncSession())
            {
                var character = await session.LoadAsync<RpgCharModel>($"RpgChar/{id}");
                if (character != null && character.HitDice != null)
                {
                    return Ok(character.HitDice);
                }
                return BadRequest();
            }
        }

        [HttpPatch("{id}/HitDice")]
        public async Task<IActionResult> UpdateHitDice([FromRoute] Guid id, [FromBody] List<HitDice> dice)
        {
            return await UpdateRpgModel(id, (sheet) =>
            {
                return sheet.HitDice = dice;
            });
        }

        [HttpGet("{id}/Health")]
        public async Task<IActionResult> GetHealth([FromRoute] Guid id)
        {
            using (var session = Store.OpenAsyncSession())
            {
                var character = await session.LoadAsync<RpgCharModel>($"RpgChar/{id}");
                if (character != null && character.Health != null)
                {
                    return Ok(character.Health);
                }
                return BadRequest();
            }
        }

        [HttpPatch("{id}/Health")]
        public async Task<IActionResult> UpdateHealth([FromRoute] Guid id, [FromBody] Health health)
        {
            return await UpdateRpgModel(id, (sheet) =>
            {
                return sheet.Health = health;
            });
        }

        [HttpGet("{id}/SavingThrows")]
        public async Task<IActionResult> GetSavingThrows([FromRoute] Guid id)
        {
            using (var session = Store.OpenAsyncSession())
            {
                var character = await session.LoadAsync<RpgCharModel>($"RpgChar/{id}");
                if (character != null && character.SavingThrows != null)
                {
                    return Ok(character.SavingThrows);
                }
                return BadRequest();
            }
        }

        [HttpPatch("{id}/SavingThrows")]
        public async Task<IActionResult> UpdateSavingThrows([FromRoute] Guid id, [FromBody] List<SavingThrow> savingThrows)
        {
            return await UpdateRpgModel(id, (sheet) =>
            {
                return sheet.SavingThrows = savingThrows;
            });
        }

        [HttpGet("{id}/Skills")]
        public async Task<IActionResult> GetSkills([FromRoute] Guid id)
        {
            using (var session = Store.OpenAsyncSession())
            {
                var character = await session.LoadAsync<RpgCharModel>($"RpgChar/{id}");
                if (character != null && character.Skills != null)
                {
                    return Ok(character.Skills);
                }
                return BadRequest();
            }
        }

        [HttpPatch("{id}/Skills")]
        public async Task<IActionResult> UpdateSkills([FromRoute] Guid id, [FromBody] List<Skill> skills)
        {
            return await UpdateRpgModel(id, (sheet) =>
            {
                return sheet.Skills = skills;
            });
        }

        [HttpGet("{id}/HitDiceType")]
        public async Task<IActionResult> GetHitDiceType([FromRoute] Guid id)
        {
            using (var session = Store.OpenAsyncSession())
            {
                var character = await session.LoadAsync<RpgCharModel>($"RpgChar/{id}");
                if (character != null && character.HitDiceType != null)
                {
                    return Ok(character.HitDiceType);
                }
                return BadRequest();
            }
        }

        [HttpPatch("{id}/HitDiceType")]
        public async Task<IActionResult> UpdateHitDiceType([FromRoute] Guid id, [FromBody] List<HitDiceTypeModel> hitDices)
        {
            return await UpdateRpgModel(id, (sheet) =>
            {
                return sheet.HitDiceType = hitDices;
            });
        }

        [HttpGet("{id}/DeathSave")]
        public async Task<IActionResult> GetDeathSave([FromRoute] Guid id)
        {
            using (var session = Store.OpenAsyncSession())
            {
                var character = await session.LoadAsync<RpgCharModel>($"RpgChar/{id}");
                if (character != null && character.DeathSave != null)
                {
                    return Ok(character.DeathSave);
                }
                return BadRequest();
            }
        }

        [HttpPatch("{id}/DeathSave")]
        public async Task<IActionResult> UpdateDeathSave([FromRoute] Guid id, [FromBody] List<DeathSave> deathSaves)
        {
            return await UpdateRpgModel(id, (sheet) =>
            {
                return sheet.DeathSave = deathSaves;
            });
        }

        [HttpGet("{id}/Treasure")]
        public async Task<IActionResult> GetTreasure([FromRoute] Guid id)
        {
            using (var session = Store.OpenAsyncSession())
            {
                var character = await session.LoadAsync<RpgCharModel>($"RpgChar/{id}");
                if (character != null && character.Treasure != null)
                {
                    return Ok(character.Treasure);
                }
                return BadRequest();
            }
        }

        [HttpPatch("{id}/Treasure")]
        public async Task<IActionResult> UpdateTreasure([FromRoute] Guid id, [FromBody] List<Treasure> treasures)
        {
            return await UpdateRpgModel(id, (sheet) =>
            {
                return sheet.Treasure = treasures;                
            });
        }

        [HttpGet("{id}/CharacterAppearance")]
        public async Task<IActionResult> GetCharacterAppearance([FromRoute] Guid id)
        {
            using (var session = Store.OpenAsyncSession())
            {
                var character = await session.LoadAsync<RpgCharModel>($"RpgChar/{id}");
                if (character != null && character.CharacterAppearance != null)
                {
                    return Ok(character.CharacterAppearance);
                }
                return BadRequest();
            }
        }

        [HttpPatch("{id}/CharacterAppearance")]
        public async Task<IActionResult> UpdateCharacterAppearance([FromRoute] Guid id, [FromBody] List<CharacterAppearance> characterAppearances)
        {
            return await UpdateRpgModel(id, (sheet) =>
            {
                return sheet.CharacterAppearance = characterAppearances;
            });
        }

        [HttpGet("{id}/FeaturesTraits")]
        public async Task<IActionResult> GetFeaturesTraits([FromRoute] Guid id)
        {
            using (var session = Store.OpenAsyncSession())
            {
                var character = await session.LoadAsync<RpgCharModel>($"RpgChar/{id}");
                if (character != null && character.FeaturesTraits != null)
                {
                    return Ok(character.FeaturesTraits);
                }
                return BadRequest();
            }
        }

        [HttpPatch("{id}/FeaturesTraits")]
        public async Task<IActionResult> UpdateFeaturesTraits([FromRoute] Guid id, [FromBody] List<FeaturesTrait> featuresTraits)
        {
            return await UpdateRpgModel(id, (sheet) =>
            {
                return sheet.FeaturesTraits = featuresTraits;
            });
        }

        [HttpGet("{id}/Equipment")]
        public async Task<IActionResult> GetEquipment([FromRoute] Guid id)
        {
            using (var session = Store.OpenAsyncSession())
            {
                var character = await session.LoadAsync<RpgCharModel>($"RpgChar/{id}");
                if (character != null && character.Equipment != null)
                {
                    return Ok(character.Equipment);
                }
                return BadRequest();
            }
        }

        [HttpPatch("{id}/Equipment")]
        public async Task<IActionResult> UpdateEquipment([FromRoute] Guid id, [FromBody] Equipment equipment)
        {
            return await UpdateRpgModel(id, (sheet) =>
            {
                return sheet.Equipment = equipment;
            });
        }

        [HttpGet("{id}/MagicItems")]
        public async Task<IActionResult> GetMagicItems([FromRoute] Guid id)
        {
            using (var session = Store.OpenAsyncSession())
            {
                var character = await session.LoadAsync<RpgCharModel>($"RpgChar/{id}");
                if (character != null && character.MagicItems != null)
                {
                    return Ok(character.MagicItems);
                }
                return BadRequest();
            }
        }

        [HttpPatch("{id}/MagicItems")]
        public async Task<IActionResult> UpdateMagicItems([FromRoute] Guid id, [FromBody] List<MagicItem> magicItems)
        {
            return await UpdateRpgModel(id, (sheet) =>
            {
                return sheet.MagicItems = magicItems;
            });
        }

        [HttpGet("{id}/Notes")]
        public async Task<IActionResult> GetNotes([FromRoute] Guid id)
        {
            using (var session = Store.OpenAsyncSession())
            {
                var character = await session.LoadAsync<RpgCharModel>($"RpgChar/{id}");
                if (character != null && character.Notes != null)
                {
                    return Ok(character.Notes);
                }
                return BadRequest();
            }
        }

        [HttpPatch("{id}/Notes")]
        public async Task<IActionResult> UpdateNotes([FromRoute] Guid id, [FromBody] List<Note> notes)
        {
            return await UpdateRpgModel(id, (sheet) =>
            {
                return sheet.Notes = notes;
            });
        }
        [HttpGet("{id}/Spells")]
        public async Task<IActionResult> GetSpells([FromRoute] Guid id)
        {
            using (var session = Store.OpenAsyncSession())
            {
                var character = await session.LoadAsync<RpgCharModel>($"RpgChar/{id}");
                if (character != null && character.Spells != null)
                {
                    return Ok(character.Spells);
                }
                return BadRequest();
            }
        }

        [HttpPatch("{id}/Spells")]
        public async Task<IActionResult> UpdateSpells([FromRoute] Guid id, [FromBody] Spells spells)
        {
            return await UpdateRpgModel(id, (sheet) =>
            {
                return sheet.Spells = spells;
            });
        }
        [HttpGet("{id}/Feats")]
        public async Task<IActionResult> GetFeats([FromRoute] Guid id)
        {
            using (var session = Store.OpenAsyncSession())
            {
                var character = await session.LoadAsync<RpgCharModel>($"RpgChar/{id}");
                if (character != null && character.Feats != null)
                {
                    return Ok(character.Feats);
                }
                return BadRequest();
            }
        }

        [HttpPatch("{id}/Feats")]
        public async Task<IActionResult> UpdateFeats([FromRoute] Guid id, [FromBody] List<Feat> feats)
        {
            return await UpdateRpgModel(id, (sheet) =>
            {
                return sheet.Feats = feats;
            });
        }

        public async Task<IActionResult> UpdateRpgModel(Guid id, Func<RpgCharModel, dynamic> updateMethod)
        {
            using (var session = Store.OpenAsyncSession())
            {
                var characterSheet = await session.LoadAsync<RpgCharModel>($"RpgChar/{id}");
                if (characterSheet.Profile.CharacterId != id)
                {
                    return new ForbidResult();
                }

                var result = updateMethod(characterSheet);

                await session.SaveChangesAsync();

                return Ok(result);
            }            
        }
    }
}