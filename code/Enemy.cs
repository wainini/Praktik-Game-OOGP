class Enemy : Entity
{
    public Dictionary<Item, int> ItemDropPool  { get; private set; }

    public Enemy(string name, int damage, int maxHP) : base(name, damage, maxHP)
    {
        RandomizeDropPool();
    }

    public override string Attack(Entity target)
    {
        target.TakeDamage(Damage);

        return $"{this.Name} did {Damage} damage to you!";
    }

    private void RandomizeDropPool(){
        ItemDropPool = new();
        ItemDropPool.Add(Item.ItemDatabase.Find((i) => i.Name == "Sword"), 50);
        ItemDropPool.Add(Item.ItemDatabase.Find((i) => i.Name == "Shield"), 50);
    }
}