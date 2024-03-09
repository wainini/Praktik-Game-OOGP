class Item{
    public string Name { get; protected set; }
    public int SellPrice { get; protected set; }

    public Item(string name, int sellPrice){
        Name = name;
        SellPrice = sellPrice;
    }

    public virtual void Use(Entity target){

    }

    public static List<Item> ItemDatabase = new(
        new Item[]{
            new Sword(),
            new Dagger()
        }
    );
}

