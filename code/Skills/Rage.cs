class Rage : Skill
{
    public Rage()
    {
        Name = "Rage";
        Damage = 0;
        Buff = new DamageBonus(3, 4);
    }

    public override string Activate(Entity caster, Entity target)
    {
        target.AddBuff(Buff);

        return $"{target.Name} is angry, it's attack increases";
    }
}