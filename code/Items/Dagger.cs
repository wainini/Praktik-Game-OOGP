class Dagger : Equipables{

    private int damage = 8;
    public Dagger() : base("Dagger", 8, EquipType.MainHand)
    {
        Buffs.Add(new DaggerBuff(damage));
    }
}

class DaggerBuff : DamageBonus{
    public DaggerBuff(int damage) : base(-1, damage)
    {

    }
}