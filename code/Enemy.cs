class Enemy
{
    private string name;
    public int atkDamage;
    private int maxHP;
    private int currentHP;

    public Enemy(string pName, int pAtkDamage, int pMaxHP)
    {
        name = pName;
        atkDamage = pAtkDamage;
        maxHP = pMaxHP;

        currentHP = maxHP;
    }
}