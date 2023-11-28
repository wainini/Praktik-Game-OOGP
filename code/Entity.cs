class Entity
{
    public string Name { get; private set; }
    public int Damage { get; private set; }
    public int MaxHP { get; private set; }
    public int CurrentHP { get; private set; }

    public Entity(string name, int damage, int maxHP)
    {
        Name = name;
        Damage = damage;
        MaxHP = CurrentHP = maxHP;
    }

    public virtual string Attack(Entity target)
    {
        target.TakeDamage(Damage);

        return $"You did {Damage} damage to {target.Name}!";
    }

    public void TakeDamage(int damage)
    {
        CurrentHP = Math.Clamp(CurrentHP - damage, 0, MaxHP);
    }
}