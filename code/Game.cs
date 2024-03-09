class Game
{
    public GameManager manager;
    private string turnReport;

    private bool switchTurn;

    public static void Main(String[] args)
    {
        _ = new Game();
    }

    private Game()
    {
        manager = new GameManager();
        manager.NewBattle();
        MainMenu();
        PlayerCreationMenu();

        GameLoop();
    }

    private void GameLoop()
    {
        while (manager.Player.CurrentHP != 0) //loop game until player dies
        {
            switchTurn = false;
            switch (manager.CurrentState)
            {
                case GameState.PlayerTurn:
                    BattleMenu();
                    break;
                case GameState.EnemyTurn:
                    EnemyTurn();
                    break;
                case GameState.BattleEnd:
                    manager.NewBattle();
                    Console.Clear();
                    WriteTurnReports();
                    continue;
                case GameState.InShop:
                    ShopMenu();
                    continue;
            }
            WriteTurnReports();

            if(switchTurn)
                manager.SwitchTurn();
        }
    }

    private void MainMenu()
    {
        int input = 0;
        do
        {
            Console.Clear();
            Console.WriteLine("Welcome to The Game");
            Console.WriteLine("====================");
            Console.WriteLine("1. New Game");
            Console.WriteLine("2. Exit");
            Console.Write("Choose an option: ");

            if (!int.TryParse(Console.ReadLine(), out input))
            {
                input = -1;
            }
        }
        while (input != 1 && input != 2);

        switch (input)
        {
            case 1:
                break;
            case 2:
                Environment.Exit(0);
                break;
        }
    }

    private void PlayerCreationMenu()
    {
        string name;

        do
        {
            Console.Clear();
            Console.Write("Choose a name for your character: ");
            name = Console.ReadLine();
        }
        while (name == null || name.Length < 3 || name.Length > 12);

        manager.NewPlayer(new Player(name, 10, 100));
    }

    private void BattleMenu()
    {
        int input = 0;
        do
        {
            #region Data Player & Enemy
            Console.Clear();
            Console.Write(manager.Enemy.Name.CenterString(20));
            Console.Write("|");
            Console.WriteLine(manager.Player.Name.CenterString(20));

            Console.WriteLine("".PadLeft(41, '='));

            Console.Write($"HP: {manager.Enemy.CurrentHP}/{manager.Enemy.MaxHP}".PadRight(20));
            Console.Write("|");
            Console.WriteLine($"HP: {manager.Player.CurrentHP}/{manager.Player.MaxHP}".PadRight(20));

            Console.Write($"ATK: {manager.Enemy.Damage}".PadRight(20));
            Console.Write("|");
            Console.WriteLine($"ATK: {manager.Player.Damage}".PadRight(20));
            #endregion

            Console.WriteLine("".PadLeft(41, '='));
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Skill");
            Console.WriteLine("3. Inventory");
            Console.Write("Choose an option: ");

            if (!int.TryParse(Console.ReadLine(), out input))
            {
                input = -1;
            }
        }
        while (input < 1 || input > 3);

        switch (input)
        {
            case 1:
                Console.Clear();
                manager.PlayerAttack();
                switchTurn = true;
                break;
            case 2:
                SkillMenu();
                break;
            case 3:
                InventoryMenu();
                break;
        }
    }

    private void InventoryMenu()
    {
        int input = 0;
        Dictionary<Item, int> playerInventory = manager.Player.Inventory;
        
        if(playerInventory.Count == 0){
            Console.Clear();
            Console.WriteLine("You have no item in your inventory");
            Console.ReadLine();
            return;
        }

        do //List semua item yang dimiliki player
        {
            Console.Clear();
            int number = 1;
            Console.WriteLine($"0. Cancel");
            foreach (KeyValuePair<Item, int> item in playerInventory)
            {
                Console.WriteLine($"{number}. {item.Key.Name} x{item.Value}");
                number++;
            }
            Console.Write("Choose an item: ");

            if (!int.TryParse(Console.ReadLine(), out input))
            {
                input = -1;
            }
        }
        while (input < 0 || input > playerInventory.Count);

        if (input == 0) return;

        playerInventory.Keys.ToList()[input - 1].Use(manager.Player);

        switchTurn = true;
    }

    private void SkillMenu()
    {
        int input = 0;
        List<Skill> playerSkills = manager.Player.GetSkills();
        do //List semua skill yang dimiliki player
        {
            Console.Clear();

            Console.WriteLine($"0. Cancel");
            for (int i = 0; i < playerSkills.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {playerSkills[i].Name}");
            }
            Console.Write("Choose a skill: ");

            if (!int.TryParse(Console.ReadLine(), out input))
            {
                input = -1;
            }
        }
        while (input < 0 || input > playerSkills.Count);

        if(input == 0) return;
        

        int targetInput = 0;
        do //List semua available target
        {
            Console.Clear();
            Console.WriteLine($"0. Cancel");
            Console.WriteLine($"1. {manager.Enemy.Name}(Enemy)");
            Console.WriteLine($"2. {manager.Player.Name}(Player)");
            Console.Write("Choose a target: ");

            if (!int.TryParse(Console.ReadLine(), out targetInput))
            {
                targetInput = -1;
            }
        }
        while (targetInput < 0 || targetInput > 2);

        if (targetInput == 0) return;

        Entity target = targetInput == 1 ? manager.Enemy : manager.Player;

        Console.Clear();
        manager.PlayerCastSkill(input, target);
        switchTurn = true;
    }

    private void EnemyTurn()
    {
        Console.Clear();
        manager.EnemyAttack();
        switchTurn = true;
    }

    private void ShopMenu(){
        int input = 0;
        do
        {
            Console.Clear();
            Console.WriteLine("Welcome to The Shop");
            Console.WriteLine($"You have {manager.Player.GetGold()}g");
            Console.WriteLine("====================");
            Console.WriteLine("0. Exit Shop");
            Console.WriteLine("1. Buy");
            Console.WriteLine("2. Sell");
            Console.WriteLine("3. Heal");
            Console.Write("Choose an option: ");

            if (!int.TryParse(Console.ReadLine(), out input))
            {
                input = -1;
            }
        }
        while (input < 0 && input > 3);

        switch (input)
        {
            case 0:
                manager.NewBattle();
                break;
            case 1:
                BuyMenu();
                break;
            case 2:
                SellMenu();
                break;
            case 3:
                HealMenu();
                break;
        }
    }

    private void BuyMenu(){
        int input = 0;
        do
        {
            Console.Clear();
            Console.WriteLine("You want to buy something?");
            Console.WriteLine($"You have {manager.Player.GetGold()}g");
            Console.WriteLine("====================");
            //randomize something
            Console.WriteLine("0. Cancel");
            Console.WriteLine("1. Dummy item 1");
            Console.WriteLine("2. Dummy item 2");
            Console.WriteLine("3. Dummy item 3");
            Console.Write("Choose an option: ");

            if (!int.TryParse(Console.ReadLine(), out input))
            {
                input = -1;
            }
        }
        while (input < 0 || input > 3);

        if (input == 0) return;
    }

    private void SellMenu(){
        int input = 0;

        Dictionary<Item, int> playerInventory = manager.Player.Inventory;

        KeyValuePair<Item, int> itemToSell;

        do
        {
            Console.Clear();
            Console.WriteLine("What do you have?");
            Console.WriteLine($"You have {manager.Player.GetGold()}g");
            Console.WriteLine("====================");
            Console.WriteLine("0. Cancel");

            int number = 1;
            foreach (KeyValuePair<Item, int> item in playerInventory)
            {               
                Console.WriteLine($"{number}. {item.Key.Name} x{item.Value}   {item.Key.SellPrice}g/ea");
                number++;
            }
            Console.Write("Choose an option: ");

            if (!int.TryParse(Console.ReadLine(), out input))
            {
                input = -1;
            }
        }
        while (input < 0 || input > 3);

        if (input == 0) return;
        else
            itemToSell = playerInventory.ElementAt(input-1);


        do
        {
            Console.Clear();
            Console.WriteLine($"[{itemToSell.Key.Name}] is {itemToSell.Key.SellPrice}g/ea");
            Console.WriteLine($"You have {itemToSell.Value} [{itemToSell.Key.Name}]");
            Console.WriteLine("====================");
            Console.WriteLine("0. Cancel");
            Console.Write("How many do you want to sell: ");

            if (!int.TryParse(Console.ReadLine(), out input))
            {
                input = -1;
            }
        }
        while (input < 0 || input > itemToSell.Value);

        if (input == 0) return;

        int totalGold = itemToSell.Key.SellPrice * input;
        manager.Player.AddGold(totalGold);
        manager.Player.RemoveItem(itemToSell.Key, input);

        Console.Clear();
        Console.WriteLine($"You've sold {input} [{itemToSell.Key.Name}] for {totalGold}g");
        Console.ReadLine();
    }

    private void HealMenu(){
        int input = 0;
        do
        {
            Console.Clear();
            Console.WriteLine("I can heal you to full for 50g");
            Console.WriteLine($"You have {manager.Player.GetGold()}g");
            Console.WriteLine("====================");
            Console.WriteLine("0. Cancel");
            Console.WriteLine("1. Okay, sure!");
            Console.Write("Choose an option: ");

            if (!int.TryParse(Console.ReadLine(), out input))
            {
                input = -1;
            }
        }
        while (input < 0 || input > 1);

        if (input == 0) return;

        if (manager.Player.TrySubtractGold(50))
        {
            manager.Player.TakeDamage(-manager.Player.MaxHP);
            Console.Clear();
            Console.WriteLine("I've healed you to full!");
        }
        else{
            Console.Clear();
            Console.WriteLine("I don't think you have enough Gold to afford that");
            Console.ReadLine();
        }
    }

    private void WriteTurnReports()
    {
        foreach (string s in manager.TurnReports.ToArray())
        {
            Console.WriteLine(manager.TurnReports.Dequeue());
            Console.ReadLine();
        }
        manager.TurnReports.Clear();
    }
}