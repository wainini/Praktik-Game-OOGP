class Equipables : Item
{
    public EquipType EquipType { get;}

    public List<Buff> Buffs { get; private set; } = new();

    public Equipables(string name, int sellPrice, EquipType type) : base(name, sellPrice)
    {
        EquipType = type;
    }

    public override void Use(Entity target)
    {
        Equip(target);
    }

    public void Equip(Entity target)
    {
        target.equipments.Equip(this);
        target.AddBuffs(Buffs);
    }

    public void UnEquip(Entity target)
    {
        target.equipments.UnEquip(this);
        target.RemoveBuffs(Buffs);
    }
}

public enum EquipType{
    MainHand,
    OffHand,
    Helm,
    Armor,
    Boots,
    Ring,
    Necklace
}