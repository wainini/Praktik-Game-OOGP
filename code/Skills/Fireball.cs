class Fireball : Skill
{
    public Fireball()
    {
        Name = "Fireball";
        Damage = 5;
        Buff = null;
        SelfCast = false;
    }

    public override Queue<string> Activate(Entity caster, Entity target)
    {
        Queue<string> turnReports = new();

        turnReports.Enqueue("A ball of fire starts to conjure in your palm. You hurl it towards the enemy..");

        int totalDamage = Damage + caster.Damage;

        target.TakeDamage(totalDamage);

        turnReports.Enqueue($"The fire engulf {target.Name}, dealing {totalDamage} damage");

        return turnReports;
    }
}