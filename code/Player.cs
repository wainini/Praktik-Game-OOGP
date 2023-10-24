class Player
{
    private string name;
    public int atkDamage;
    private int maxHP;
    private int currentHP;

    //auto-properties
    //public int AtkDamage{ get; }

    //properties
    public string Name
    {
        get { return name; }
    }

    public int MaxHP
    {
        get { return maxHP; }
        set 
        { 
            if (value > 0)
            {
                maxHP = value;
            }
            else
            {
                maxHP = 1;
            } 

            if(currentHP > maxHP){
                currentHP = maxHP;
            }
        }
    }

    public Player(string pName, int pAtkDamage, int pMaxHP)
    {
        name = pName;
        atkDamage = pAtkDamage;
        maxHP = pMaxHP;

        currentHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        currentHP = Math.Clamp(currentHP - damage, 0, int.MaxValue);
    }
    public void Attack()
    {
        Console.WriteLine($"My damage is {atkDamage}");
    }
}