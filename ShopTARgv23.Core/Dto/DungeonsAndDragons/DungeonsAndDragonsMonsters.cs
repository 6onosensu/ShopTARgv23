namespace ShopTARgv23.Core.Dto.DungeonsAndDragons
{
    public class DungeonsAndDragonsMonsters
    {
        public string Index { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }
        public string Alignment { get; set; }
        public List<ArmorClass> ArmorClass { get; set; }
        public int HitPoints { get; set; }
        public string HitDice { get; set; }
        public string HitPointsRoll { get; set; }
        public List<Speed> Speed { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public List<Proficiencies> Proficiencies { get; set; }
        public List<int> DamageVulnerabilities { get; set; }
        public List<int> DamageResistances { get; set; }
        public List<string> DamageImmunities { get; set; }
        public List<int> ConditionImmunities { get; set; }
        public Senses Senses { get; set; }
        public string Languages { get; set; }
        public int ChallengeRating { get; set; }
        public int ProficiencyBonus { get; set; }
        public int XP { get; set; }
        public List<SpecialAbilities> SpecialAbilities { get; set; }
        public List<Actions> Actions { get; set; }
        public List<LegendaryActions> LegendaryActions { get; set;}
        public string Image { get; set; }
        public string Url { get; set; }
    }

    public class ArmorClass
    {
        public string Type { get; set; }
        public int Value { get; set; }
    }

    public class Speed 
    { 
        public string Walk { get; set; }
        public string Fly { get; set; }
        public string Swim { get; set; }
    }

    public class Proficiencies
    {
        public int Value { set; get; }
        public IndexedItem Proficiency { get; set; }
    }

    public class IndexedItem
    {
        public string Index {  get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class Senses
    {
        public string Blindsight { get; set; }
        public string Darkvision { get; set; }
        public int PassivePerception { get; set; }
    }

    public class SpecialAbilities
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public Usage Usage { get; set; }
    }

    public class Usage 
    { 
        public string Type {  get; set;  }
        public int Times { get; set; }
        public List<string> RestTypes { get; set; }
    }

    public class Actions
    {
        public string Name {  set; get; }
        public string MultiattackType { get; set; }
        public string Desc { get; set; }
        public List<Action> Action {  get; set; }
        public int AttackBonus  { get; set; }
        public List<Damage> Damage { get; set; }
        public Dc Dc { get; set; }
        public UsageA Usage { get; set; }
    }

    public class Action
    {
        public string ActionName { get; set; }
        public int Count { get; set; }
        public string Type { get; set; }
    }

    public class Damage
    {
        public IndexedItem DamageType { get; set; }
        public string DamageDice { get; set; }
    }

    public class Dc 
    {
        public IndexedItem DcType { get; set; }
        public int DcValue { get; set; }
        public bool SuccessType { get; set; }
    }

    public class UsageA 
    {
        public string Type { get; set; }
        public string Dice { get; set; }
        public int MinValue { get; set; }
    }

    public class LegendaryActions
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public Dc Dc { get; set; }
        public Damage Damage { get; set; }
    }
}
