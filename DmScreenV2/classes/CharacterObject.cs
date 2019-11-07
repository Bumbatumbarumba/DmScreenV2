using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DmScreenV2.classes
{
    public class CharacterObject
    {
        public string PlayerName { get; set; }
        public string CharacterName { get; set; }
        public string CharacterImage { get; set; }
        public string Class { get; set; }
        public int Level { get; set; }
        public string Race { get; set; }
        public string Background { get; set; }
        public string Alignment { get; set; }
        public string PersonalityTraits { get; set; }
        public string Ideals { get; set; }
        public string Bonds { get; set; }
        public string Flaws { get; set; }
        public int Exp { get; set; }
        public int Inspiration { get; set; }
        public int ProficiencyBonus { get; set; }
        public int ArmorClass { get; set; }
        public int InitiativeBonus { get; set; }
        public int Speed { get; set; }
        public int MaxHp { get; set; }
        public int CurrentHp { get; set; }
        public int TempHp { get; set; }
        public int TotalHitDie { get; set; }
        public int RemainingHitDie { get; set; }
        public string HitDiceType { get; set; }
        public int SuccessfulSavingThrows { get; set; }
        public int FailedSavingThrows { get; set; }
        public Dictionary<string, int> Abilities = new Dictionary<string, int>();
        public Dictionary<string, int> Skills = new Dictionary<string, int>();
        public string[] ProficientSkills { get; set; }
    }
}
