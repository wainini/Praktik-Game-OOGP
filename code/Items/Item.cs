class Item{
    public string Name { get; protected set; }
    public int SellPrice { get; protected set; }

    public Item(string name, int sellPrice){
        Name = name;
        SellPrice = sellPrice;
    }

    public static List<Item> ItemDatabase = new(
        new Item[]{
            new Item("Sword", 10),
            new Item("Shield", 8)
        }
    );
}

