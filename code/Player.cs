class Player : Entity
{
    public List<Skill> skills = new List<Skill>()
    {
        new Skill("Haste", "You cast haste on "),
        new Skill("Fireball", "You cast fireball towards ")
    };

    public Player(string name, int damage, int maxHP) : base(name, damage, maxHP)
    {

    }

    public string CastSkill(string skillName, Entity target)
    {
        Skill s = skills.Find((x) => x.Name == skillName);

        if (s == null)
        {
            return "Skill not found, you failed casting the skill";
        }
        else
        {
            return s.TextWhenSkillCasted + target.Name;
        }
    }
}