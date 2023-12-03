class Player : Entity
{
    private List<Skill> skills = new List<Skill>()
    {
        new Fireball(),
        new Rage()
    };

    public Player(string name, int damage, int maxHP) : base(name, damage, maxHP)
    {

    }

    public List<Skill> GetSkills(){
        return skills;
    }

    public string CastSkill(int index, Entity target)
    {
        Skill s = skills[index-1];

        if (s == null)
        {
            return "Skill not found, you failed casting the skill";
        }
        else
        {
            return s.Activate(this, target);
        }
    }
}