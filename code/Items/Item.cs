class Item{
    public string Name { get; protected set; }

    public Item(string name){
        Name = name;
    }

    public static List<Item> ItemDatabase = new(
        new Item[]{
            new Item("Sword"),
            new Item("Shield")
        }
    );
}

