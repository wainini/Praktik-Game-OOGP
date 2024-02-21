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

    public Queue<string> CastSkill(int index, Entity target)
    {
        Skill s = skills[index-1];

        if (s == null)
        {
            Queue<string> turnReports = new();
            turnReports.Enqueue("Skill not found, you failed casting the skill");
            return turnReports;
        }
        else
        {
            return s.Activate(this, target);
        }
    }
}