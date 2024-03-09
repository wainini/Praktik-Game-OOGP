class Entity
{
    private int damage;
    public Equipments equipments { get; private set; } = new();
    public string Name { get; private set; }
    public int Damage
    {
        get
        {
            int totalDamage = damage;

            foreach (Buff b in buffList)
            {
                if (b is DamageBonus)
                {
                    DamageBonus buffDmgBonus = (DamageBonus)b;
                    totalDamage += buffDmgBonus.GetBonusDamage();
                }
            }

            return totalDamage;
        }
        private set
        {
            damage = value;
        }
    }
    
    public int MaxHP { get; private set; }
    public int CurrentHP { get; private set; }

    protected List<Buff> buffList = new List<Buff>();

    public Entity(string name, int damage, int maxHP)
    {
        Name = name;
        Damage = damage;
        MaxHP = CurrentHP = maxHP;
        equipments.entity = this;
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

    public void AddBuffs(List<Buff> buffs)
    {
        foreach(Buff b in buffs){
            AddBuff(b);
        }
    }

    public void AddBuff(Buff buff)
    {
        buffList.Add(buff);
    }

    public void RemoveBuffs(List<Buff> buffs)
    {
        foreach(Buff b in buffs){
            RemoveBuff(b);
        }
    }

    public void RemoveBuff(Buff buff)
    {
        buffList.Remove(buff);
    }

    public void CheckBuffs()
    {
        foreach (Buff b in buffList.ToArray())
        {
            b.Activate();

            if (b.RemainingDuration == 0)
            {
                RemoveBuff(b);
            }
        }
    }
}