class Skill
{
    public string Name { get; protected set; }
    public int Damage { get; protected set; }
    public List<Buff> Buffs { get; protected set; } = new();
    public bool SelfCast { get; protected set;}

    public virtual Queue<string> Activate(Entity caster, Entity target)
    {
        Queue<string> turnReports = new(new string[]{ "", "" }) ;
        return turnReports;
    }
}
