class Game
{
    public GameManager manager;
    private string turnReport;


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

        while (manager.Player.CurrentHP != 0) //loop game until player dies
        {
            BattleMenu(); //PlayerTurn
            WriteTurnReport();
            Console.ReadLine();
            manager.SwitchTurn();

            EnemyTurn();
            WriteTurnReport();
            Console.ReadLine();
            manager.SwitchTurn();

            if (manager.Enemy.CurrentHP == 0)
            {
                manager.NewBattle();
            }
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
                Console.WriteLine("You readies an attack..");
                Console.ReadLine();
                turnReport = manager.Player.Attack(manager.Enemy);
                break;
            case 2:
                SkillMenu();
                break;
            case 3:
                break;
        }
    }

    private void SkillMenu()
    {
        int input = 0;
        List<Skill> playerSkills = manager.Player.GetSkills();
        do //List semua skill yang dimiliki player
        {
            Console.Clear();

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
        while (input < 1 || input > playerSkills.Count);

        int targetInput = 0;
        do //List semua available target
        {
            Console.Clear();
            Console.WriteLine($"1. {manager.Enemy.Name}(Enemy)");
            Console.WriteLine($"2. {manager.Player.Name}(Player)");
            Console.Write("Choose a target: ");

            if (!int.TryParse(Console.ReadLine(), out targetInput))
            {
                targetInput = -1;
            }
        }
        while (targetInput < 1 || targetInput > 2);

        Entity target = targetInput == 1 ? manager.Enemy : manager.Player;

        turnReport = manager.Player.CastSkill(input, target);
    }

    private void EnemyTurn()
    {
        Console.Clear();
        Console.WriteLine($"{manager.Enemy.Name} readies an attack..");
        Console.ReadLine();
        turnReport = manager.Enemy.Attack(manager.Player);
    }

    private void WriteTurnReport()
    {
        Console.WriteLine(turnReport);
    }

}