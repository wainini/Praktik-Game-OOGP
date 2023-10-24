class Game
{
    int angka;

    static void Main(String[] args)
    {
        _ = new Game();
    }

    public Game()
    {
        //kita bikin game RPG dimana ada Player dan Enemy

        //Player
        string playerName;
        int playerAtkDamage;
        int playerMaxHP;
        int playerCurrentHP;

        //Enemy
        string enemyName;
        int enemyAtkDamage;
        int enemyMaxHP;
        int enemyCurrentHp;

        //Enemy 2
        string enemy2Name;
        int enemy2AtkDamage;


        Player myPlayer = new Player("Wainini", 100, 1000);
        Enemy enemy1 = new Enemy("Bob", 10, 200);
        Enemy enemy2 = new Enemy("Bill", 20, 150);


        //Console.WriteLine($"{myPlayer.Name}: {myPlayer.GetCurrentHP()} / {myPlayer.GetMaxHP()}");


        myPlayer.atkDamage = 1;
        //myPlayer.AtkDamage = 10;
        Console.WriteLine(myPlayer.atkDamage);
        //Console.WriteLine(myPlayer.AtkDamage);

        //Wainini: 1000/1000
    }
}