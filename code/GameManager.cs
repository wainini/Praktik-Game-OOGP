public enum GameState
{
    PlayerTurn,
    EnemyTurn,
    BattleEnd,
    InShop
}

class GameManager
{
    public Player Player { get; private set; }
    public Enemy Enemy { get; private set; }
    public GameState CurrentState { get; private set; }
    public Queue<string> TurnReports { get; private set; } = new();

    private int baseNumOfBattle = 2;
    private int currentNumOfBattle;

    private int enemyStatPool = 45;
    private int enemyStatIncrease = 10;

    public GameManager()
    {
        currentNumOfBattle = baseNumOfBattle;
    }

    public void NewPlayer(Player player)
    {
        if (Player != null) return;
        Player = player;
    }

    public void NewBattle()
    {
        if(currentNumOfBattle == 0){
            CurrentState = GameState.InShop;
            currentNumOfBattle = baseNumOfBattle;
        }
        else{
            CurrentState = GameState.PlayerTurn;
            NewEnemy();
        }
    }

    private void NewEnemy()
    {
        Random rand = new Random();

        int randomHP = rand.Next((int)Math.Floor(enemyStatPool * 0.20f), (int)Math.Floor(enemyStatPool * 0.75f));
        int damage = enemyStatPool - randomHP;

        Enemy = new Enemy("Bob", damage, randomHP);
    }

    public void SwitchTurn()
    {
        if (CurrentState == GameState.PlayerTurn) //start of enemy Turn
        {
            Enemy.CheckBuffs();
            CurrentState = GameState.EnemyTurn;
        }
        else //start of player Turn
        {
            Player.CheckBuffs();
            CurrentState = GameState.PlayerTurn;
        }
        CheckAlive();
    }

    private void CheckAlive(){
        if(Enemy.CurrentHP <= 0){
            EndBattle();
        }
        if(Player.CurrentHP <= 0){
            Environment.Exit(0);
        }
    }

    private void EndBattle(){
        CurrentState = GameState.BattleEnd;
        TurnReports.Enqueue($"You've slain {Enemy.Name}");
        GetEnemyDrop();

        currentNumOfBattle--;
        enemyStatPool += enemyStatIncrease;
    }

    public void EnemyAttack()
    {
        TurnReports.Enqueue($"{Enemy.Name} readies an attack..");
        TurnReports.Enqueue(Enemy.Attack(Player));
    }

    public void PlayerAttack(){
        TurnReports.Enqueue("You ready an attack..");
        TurnReports.Enqueue(Player.Attack(Enemy));
    }

    public void PlayerCastSkill(int index, Entity target)
    {
        TurnReports = Player.CastSkill(index, target);
    }

    private void GetEnemyDrop(){
        Random rand = new Random();

        bool doesItemDrop = false;

        foreach(KeyValuePair<Item, int> item in Enemy.ItemDropPool){
            int randomNum = rand.Next(1, 101);
            if(randomNum <= item.Value){
                TurnReports.Enqueue($"You've obtained {item.Key.Name}!");
                Player.AddItem(item.Key, 1);
                doesItemDrop = true;
            }
        }

        if(!doesItemDrop){
            TurnReports.Enqueue($"There's nothing worth taking from {Enemy.Name}'s corpse");
        }
    }

    
}