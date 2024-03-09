class Rage : Skill
{
    public Rage()
    {
        Name = "Rage";
        Damage = 0;
        Buffs.Add(new RageBuff(3, 4));
        SelfCast = true;
    }

    public override Queue<string> Activate(Entity caster, Entity target)
    {
        Queue<string> turnReports = new(new string[]{"You starts to chant an ancient spell [Rage]..", 
                                $"{target.Name} is angry, it's attack increases"}) ;

        target.AddBuffs(Buffs);
        return turnReports;
    }
}

class RageBuff : DamageBonus
{
    public RageBuff(int duration, int bonusDamage) : base(duration, bonusDamage)
    {

    }

}