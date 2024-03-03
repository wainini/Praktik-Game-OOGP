class Player : Entity
{
    public Dictionary<Item, int> Inventory { get; private set; }
    private int gold = 0;
    private List<Skill> skills = new List<Skill>()
    {
        new Fireball(),
        new Rage()
    };

    public Player(string name, int damage, int maxHP) : base(name, damage, maxHP)
    {
        Inventory = new();
    }

    public List<Skill> GetSkills(){
        return skills;
    }

    public Queue<string> CastSkill(int index, Entity target)
    {
        Skill s = skills[index-1];

        if (s == null)
        {
            Queue<string> turnReports = new();
            turnReports.Enqueue("Skill not found, you failed casting the skill");
            return turnReports;
        }
        else
        {
            return s.Activate(this, target);
        }
    }

    public void AddItem(Item item, int amount){
        if(Inventory.ContainsKey(item)){
            Inventory[item] += amount;
        }
        else{
            Inventory.Add(item, amount);
        }
    }

    public void RemoveItem(Item item, int amount){
        if (!Inventory.ContainsKey(item)) return; //guard clause

        if (Inventory[item] < amount) return;

        else if(Inventory[item] == amount){
            Inventory.Remove(item);
        }
        else{
            Inventory[item] -= amount;
        }
    }

    public int GetGold(){
        return gold;
    }

    public void AddGold(int amount){
        gold += amount;
    }

    public bool TrySubtractGold(int amount){
        if(gold < amount){
            return false;
        }
        else{
            gold -= amount;
            return true;
        }
    }
}