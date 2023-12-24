class Skill
{
    public string Name { get; protected set; }
    public int Damage { get; protected set; }
    public Buff Buff { get; protected set; }
    public bool SelfCast { get; protected set;}

    public virtual string Activate(Entity caster, Entity target)
    {
        return "";
    }
}
