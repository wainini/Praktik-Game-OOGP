class Fireball : Skill
{
    public Fireball()
    {
        Name = "Fireball";
        Damage = 5;
        Buff = null;
        SelfCast = false;
    }

    public override string Activate(Entity caster, Entity target)
    {
        int totalDamage = Damage + caster.Damage;

        target.TakeDamage(totalDamage);

        return $"The fire engulf {target.Name}, dealing {totalDamage} damage";
    }
}