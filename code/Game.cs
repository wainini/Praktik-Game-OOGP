class Game
{
    private Player player;
    private Enemy enemy;
    private string turnReport;


    public static void Main(String[] args)
    {
        _ = new Game();
    }

    private Game()
    {
        enemy = new Enemy("Bob", 7, 35);
        MainMenu();
        PlayerCreationMenu();


        while (player.CurrentHP != 0) //loop game until player dies
        {
            BattleMenu(); //PlayerTurn
            WriteTurnReport();
            Console.ReadLine();

            EnemyTurn();
            WriteTurnReport();
            Console.ReadLine();

            if(enemy.CurrentHP == 0){
                enemy = new("Bob", enemy.Damage+1, enemy.MaxHP+5);
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

        player = new Player(name, 10, 100);
    }

    private void BattleMenu()
    {
        int input = 0;
        do
        {
            #region Data Player & Enemy
            Console.Clear();
            Console.Write(enemy.Name.CenterString(20));
            Console.Write("|");
            Console.WriteLine(player.Name.CenterString(20));

            Console.WriteLine("".PadLeft(41, '='));

            Console.Write($"HP: {enemy.CurrentHP}/{enemy.MaxHP}".PadRight(20));
            Console.Write("|");
            Console.WriteLine($"HP: {player.CurrentHP}/{player.MaxHP}".PadRight(20));

            Console.Write($"ATK: {enemy.Damage}".PadRight(20));
            Console.Write("|");
            Console.WriteLine($"ATK: {player.Damage}".PadRight(20));
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
                turnReport = player.Attack(enemy);
                break;
            case 2:
                break;
            case 3:
                break;
        }


    }

    private void EnemyTurn()
    {
        Console.Clear();
        Console.WriteLine($"{enemy.Name} readies an attack..");
        Console.ReadLine();
        turnReport = enemy.Attack(player);
    }

    private void WriteTurnReport(){
        Console.WriteLine(turnReport);
    }
}