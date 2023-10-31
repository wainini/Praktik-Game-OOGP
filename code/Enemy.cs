class Enemy
{
    public string Name { get; private set; }
    public int Damage { get; private set; }
    public int MaxHP { get; private set; }
    public int CurrentHP { get; private set; }

    public Enemy(string name, int damage, int maxHP)
    {
        Name = name;
        Damage = damage;
        MaxHP = CurrentHP = maxHP;
    }

    public string Attack(Player player)
    {
        player.TakeDamage(Damage);

        return $"{Name} did {Damage} damage to you!";
    }

    public void TakeDamage(int damage)
    {
        CurrentHP = Math.Clamp(CurrentHP - damage, 0, MaxHP);
    }
}