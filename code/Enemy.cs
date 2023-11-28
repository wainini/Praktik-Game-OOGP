class Enemy : Entity
{
    public Enemy(string name, int damage, int maxHP) : base(name, damage, maxHP)
    {        
        
    }

    public override string Attack(Entity target)
    {
        target.TakeDamage(Damage);

        return $"{this.Name} did {Damage} damage to you!";
    }
}