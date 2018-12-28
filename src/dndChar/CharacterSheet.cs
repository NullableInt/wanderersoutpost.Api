using System;
using System.Collections.Generic;

using dndChar.Models.BaseStats;
using dndChar.Models.Currency;
using dndChar.Models.Inventory;
using dndChar.Models.ServerState;

namespace dndChar
{
    public class CharacterSheet
    {
        public string Id { get; set; }

        public ServerStateModel ServerState { get; set; }

        public CurrencyStateModel CurrencyState { get; set; }

        public Dictionary<string, InventoryModel[]> InventoryState { get; set; }

        public BaseCharacterModel BaseCharacterModelState { get; set; }

        public static CharacterSheet CreateCharacterSheet(Guid appUserId, bool isReadOnly)
        {
            var baseCharacerModelState = new BaseCharacterModel
            {
                baseStats = new BaseStats
                {
                    Class = CharacterClass.barbarian,
                    Experience = 0,
                    MaxHitPoints = 0,
                    background = "none",
                    characterAlignment = CharacterAlignment.TN,
                    charisma = new AbilityScore
                    {
                        _coreStat = 8,
                        _statBonus = 0,
                        name = AbilityScoreName.charisma
                    },
                    name = "new character",
                    constitution = new AbilityScore
                    {
                        name = AbilityScoreName.constitution,
                        _statBonus = 8,
                        _coreStat = 8
                    },
                    damagedHitPoints = 0,
                    dexterity = new AbilityScore
                    {
                        name = AbilityScoreName.dexterity,
                        _statBonus = 8,
                        _coreStat = 8
                    },
                    inspiration = 0,
                    intelligence = new AbilityScore
                    {
                        name = AbilityScoreName.intelligence,
                        _statBonus = 8,
                        _coreStat = 8
                    },
                    level = 0,
                    race = "human",
                    speed = 30,
                    strength = new AbilityScore
                    {
                        name = AbilityScoreName.strength,
                        _statBonus = 8,
                        _coreStat = 8
                    },
                    tempHitPoints = 0,
                    wisdom = new AbilityScore
                    {
                        name = AbilityScoreName.wisdom,
                        _statBonus = 8,
                        _coreStat = 8
                    }
                }
            };
            var currencyState = new CurrencyStateModel
            {
                copper = 0,
                electrum = 0,
                gold = 0,
                platinum = 0,
                silver = 0,
                totals = new CurrencyModel
                {
                    platinum = 0,
                    silver = 0,
                    gold = 0,
                    electrum = 0,
                    copper = 0
                },
                treasure = new[] {new TreasureModel() }
            };
            var inventorystate = new Dictionary<string, InventoryModel[]>
            {
                { "bonds", new[] { new InventoryModel() { item = string.Empty } } },
                { "equipment", new[] { new InventoryModel() { item = string.Empty } } },
                { "featuresAndTraits", new[] { new InventoryModel() { item = string.Empty } } },
                { "flaws", new[] { new InventoryModel() { item = string.Empty } } },
                { "ideals", new[] { new InventoryModel() { item = string.Empty } } },
                { "otherProficienciesAndLanguages", new[] { new InventoryModel() { item = string.Empty } } },
                { "personalityTraits", new[] { new InventoryModel() { item = string.Empty } } }
            };
            var serverState = new ServerStateModel
            {
                Readonly = isReadOnly,
                appUserId = appUserId
            };
            return new CharacterSheet
            {
                BaseCharacterModelState = baseCharacerModelState,
                CurrencyState = currencyState,
                InventoryState = inventorystate,
                ServerState = serverState
            };
        }

    }
}
