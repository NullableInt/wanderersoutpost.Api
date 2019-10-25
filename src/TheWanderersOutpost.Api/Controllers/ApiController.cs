using System.Collections.Generic;
using System.Linq;
using TheWanderersOutpost.Api.Database;
using TheWanderersOutpost.Api.Models.RpgChar;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TheWanderersOutpost.Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = false, GroupName = nameof(ApiController))]
    [ApiController]
    [Route("[controller]")]
    public class ApiController : Controller
    {
        public IMongoDatabase MongoDb { get; set; }
        public MongoConfig MongoConfig { get; }

        public ApiController(DocumentStoreHolder holder, IOptions<MongoConfig> options)
        {
            MongoDb = holder.Store.GetDatabase("RpgCharModelDb");
            MongoConfig = options.Value;
        }

        /// <summary>
        /// Checks that the api is live
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("public")]
        public IActionResult Public()
        {
            return Json(new
            {
                Message = "Hello from a public endpoint! You don't need to be authenticated to see this."
            });
        }

        [HttpGet("private")]
        [Route("private")]
        [Authorize]
        public IActionResult Private()
        {
            return Json(new
            {
                Message = "Hello from a private endpoint! You need to be authenticated to see this."
            });
        }

        [HttpGet]
        [Route("private-scoped")]
        [Authorize("read:messages")]
        public IActionResult Scoped()
        {
            return Json(new
            {
                Message = "Hello from a private endpoint! You need to be authenticated and have a scope of read:messages to see this."
            });
        }


        /// <summary>
        /// This is a helper action. It allows you to easily view all the claims of the token
        /// </summary>
        /// <returns></returns>
        [HttpGet("claims")]
        public IActionResult Claims()
        {
            return Json(User.Claims.Select(c =>
                new
                {
                    c.Type,
                    c.Value
                }));
        }

        [HttpGet("Database")]
        public IActionResult Database()
        {
            return Json(System.Environment.GetEnvironmentVariable("MongodbUrl"));
        }

        [ProducesResponseType(typeof(FiveEModel), 200)]
        [HttpGet("mock")]
        public IActionResult Mock()
        {
            return Json(new FiveEModel
            {
                AbilityScores = new List<AbilityScore>
                {
                    new AbilityScore { Name = "cha", Value = 8},
                    new AbilityScore { Name = "con", Value = 7},
                    new AbilityScore { Name = "dex", Value = 6},
                    new AbilityScore { Name = "int", Value = 5},
                    new AbilityScore { Name = "str", Value = 4},
                    new AbilityScore { Name = "wis", Value = 3}
                },
                CharacterAppearance = new List<CharacterAppearance>
                {
                    new CharacterAppearance
                    {
                        EyeColor = "Eye",
                        HairColor = "Hair",
                        Height = "Height",
                        SkinColor = "Skin",
                        Weight = "Weight"
                    }
                },
                DeathSave = new List<DeathSave>
                {
                    new DeathSave
                    {
                        DeathSaveFailure = true
                    },
                    new DeathSave
                    {
                        DeathSaveSuccess = true
                    }
                },
                Equipment = new Equipment
                {
                    Armor = new List<Armor>
                    {
                        new Armor
                        {
                            Class = 11,
                            CurrencyDenomination = "What",
                            Description = "Desc",
                            MagicalModifier = 1,
                            Name = "Name",
                            Price = 1,
                            Stealth = "1",
                            Type = "Type",
                            Weight = 12,
                            IsAttuned = true,
                            IsEqupped = true
                        }
                    },
                    Weapons = new List<Weapon>
                    {
                        new Weapon
                        {
                            CurrencyDenomination = "d",
                            Weight = 1,
                            Type = "Type",
                            Price = 1,
                            Name = "Weapon",
                            DamageType = "Force",
                            Description = "Lightsaber",
                            Dmg = "2d6",
                            Handedness = "Left",
                            Hit = -1,
                            ProficiencyModifier = 0.5m,
                            Property = "Prop",
                            Quantity = 1,
                            Range = "5ft",
                            ToHitModifier = -1
                        }
                    }
                },
                Feats = new List<Feat>
                {
                    new Feat
                    {
                        Description = "Allows you to sneak past friends",
                        Name = "Halfling nibleness"
                    }
                },
                FeaturesTraits = new List<FeaturesTrait>
                {
                    new FeaturesTrait
                    {
                        Background = "Noble",
                        Bonds = "Bondy bond",
                        Flaws = "Very",
                        Ideals = "Few"
                    }
                },
                Health = new Health
                {
                    Damage = 1,
                    MaxHitpoints = 6,
                    TempHitpoints = 2
                },
                HitDice = new List<HitDice>
                {
                    new HitDice
                    {
                        ExtraHitDice = 0,
                        HitDiceUsed = 1
                    }
                },
                HitDiceType = new List<HitDiceTypeModel>
                {
                    new HitDiceTypeModel
                    {
                        HitDiceType = "d8"
                    }
                },
                Id = ObjectId.GenerateNewId().ToString(),
                Items = new List<Item>
                {
                    new Item
                    {
                        Cost =  14,
                        CurrencyDenomination = "SP",
                        Desc = "Oh no",
                        Name = "Woah",
                        Qty = 1,
                        Weight = 154
                    }
                },
                MagicItems = new List<MagicItem>
                {
                    new MagicItem
                    {
                        Weight = 14,
                        Attuned = true,
                        Charges = 0,
                        Description = "No ide",
                        MaxCharges = 1,
                        Name = "Boy",
                        Rarity = "Legendary",
                        RequiresAttunement = true,
                        Type = "Unknown"
                    }
                },
                Notes = new List<Note>
                {
                    new Note
                    {
                        IsSavedChatNotes = true,
                        Text = "Test text"
                    }
                },
                OwnerID = "Unique ID for owner from identity federation",
                Profile = new Profile
                {
                    Age = "23",
                    Alignment = "Truly evil",
                    Background = "Is this a duplicate from Features and traits?",
                    CharacterImage = "Url here",
                    CharacterName = "Testy testerson",
                    Diety = "Null",
                    Exp = "Milestone",
                    Gender = "No",
                    Level = 2,
                    PlayerName = "U+1F618",
                    Race = "U+1F364",
                    TypeClass = "God"
                },
                SavingThrows = new List<SavingThrow>
                {
                    new SavingThrow
                    {
                        Name = "Dex",
                        Proficiency = true
                    },
                    new SavingThrow
                    {
                        Name = "Int",
                        Proficiency = false
                    }
                },
                Skills = new List<Skill>
                {
                    new Skill
                    {
                        AbilityScore = "wis",
                        BonusModifier = 1,
                        ProficiencyModifier = 2,
                        Name = "Prospecting"
                    },
                    new Skill
                    {
                        AbilityScore = "dex",
                        BonusModifier = 4,
                        ProficiencyModifier = 0.5m,
                        Name = "Sneaking"
                    }
                },
                Spells = new Spells
                {
                    Cantrips = new List<Cantrip>
                    {
                        new Cantrip
                        {
                            CastingTime = "1 turn",
                            Components = "Verbal",
                            Description = "Tells a lie",
                            Dmg = "6d8",
                            DmgType = "Psycic",
                            Duration = "Lifetime",
                            isRitual = false,
                            MaterialComponents = "None",
                            Name = "Lie",
                            Range = "32ft",
                            SaveAttr = "Int",
                            School = "Godlike",
                            Type = "All"
                        }
                    },
                    CantripsKnown = 1,
                    InvocationsKnown = 1,
                    MaxPrepared = 13,
                    SpellAttackBonus = 42,
                    SpellcastingAbility = "All so fuck you",
                    SpellList = new List<SpellList>
                    {
                        new SpellList
                        {
                            CastingTime = "1 turn",
                            Components = "Verbal",
                            Description = "Tells a lie",
                            Dmg = "6d8",
                            DmgType = "Psycic",
                            Duration = "Lifetime",
                            isRitual = false,
                            MaterialComponents = "None",
                            Name = "Lie",
                            Range = "32ft",
                            SaveAttr = "Int",
                            School = "Godlike",
                            Type = "All",
                            AlwaysPrepared = true,
                            Level = 99,
                            Prepared = true
                        }
                    },
                    SpellSaveDc = 19,
                    SpellsKnown = 1,
                    SpellSlots = new List<SpellSlot>
                    {
                        new SpellSlot
                        {
                            AvailableSpellSlots = 0,
                            Level = 1,
                            ResetsOn = "Seconds",
                            UsedSpellSlots = 0
                        }
                    }
                },
                Status = new List<Status>
                {
                    new Status
                    {
                        Identifier = "Dead,y",
                        Name = "Unknown",
                        Type = "Forcy",
                        Value = 13
                    }
                },
                Traits = new List<Trait>
                {
                    new Trait
                    {
                        Description = "Trait",
                        Name = "Trait name",
                        Race = "Racism"
                    }
                },
                Treasure = new List<Treasure>
                {
                    new Treasure
                    {
                        Copper = 0,
                        Electrum = 4,
                        Gold = 0,
                        Platinum = 2,
                        Silver = 8
                    }
                },
                _created = new BsonDateTime(System.DateTime.UtcNow),
                _lastUpdated = new BsonDateTime(System.DateTime.UtcNow)
            });
        }

        [HttpPatch("publicPatch")]
        [HttpPost("publicPost")]
        public IActionResult testPublic([FromBody] object propertyValue)
        {
            return Json(propertyValue);
        }

        [HttpPatch("privatePatch")]
        [HttpPost("privatePost")]
        [Authorize]
        public IActionResult testPrivate([FromBody] object propertyValue)
        {
            return Json(propertyValue);
        }
    }
}
