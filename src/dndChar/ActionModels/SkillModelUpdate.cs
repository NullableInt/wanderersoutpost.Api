using dndChar.Models.BaseStats;
using dndChar.Models.Skills;

namespace dndChar.ActionModels
{
    public class SkillModelUpdate
    {
        public AbilityScore coreStat;

        public SkillProficiencyBonus proficiencyBonus;
        public string Name { get; set; }


        public SkillModel[] ToSkillType()
        {
            return new SkillModel[]
            {
                new SkillModel {coreStat = coreStat, proficiencyBonus = proficiencyBonus}
            };
        }
    }
}