class DamageBonus : Buff
{
    private int bonusDamage;

    public DamageBonus(int duration, int bonusDamage)
    {
        Name = "DamageBonus";
        Duration = duration;
        RemainingDuration = duration;
        this.bonusDamage = bonusDamage;
    }

    public int GetBonusDamage()
    {
        return bonusDamage;
    }
}