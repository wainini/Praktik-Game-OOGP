class Sword : Equipables{

    private int damage = 10;
    public Sword() : base("Sword", 10, EquipType.MainHand)
    {
        Buffs.Add(new SwordBuff(damage));
    }
}

class SwordBuff : DamageBonus{
    public SwordBuff(int damage) : base(-1, damage)
    {

    }
}