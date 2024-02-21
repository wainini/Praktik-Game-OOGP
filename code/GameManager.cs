public enum GameState
{
    PlayerTurn,
    EnemyTurn
}

class GameManager
{
    public Player Player { get; private set; }
    public Enemy Enemy { get; private set; }
    public GameState CurrentState { get; private set; }
    public Queue<string> TurnReports { get; private set; } = new();

    private int firstEnemyDamage = 7;
    private int firstEnemyHP = 35;



    public GameManager()
    {

    }

    public void NewPlayer(Player player)
    {
        if (Player != null) return;
        Player = player;
    }

    public void NewBattle()
    {
        CurrentState = GameState.PlayerTurn;
        NewEnemy();
    }

    public void NewEnemy()
    {
        if (Enemy == null) //null apabila ini adalah enemy pertama
        {
            Enemy = new Enemy("Bob", firstEnemyDamage, firstEnemyHP);
        }
        else
        {
            Enemy = new Enemy("Bob", Enemy.Damage + 1, Enemy.MaxHP + 5);
        }
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
        if(Enemy.CurrentHP == 0){
            NewBattle();
        }
        if(Player.CurrentHP == 0){
            Environment.Exit(0);
        }
    }

    public void EnemyAttack()
    {
        TurnReports.Enqueue($"{Enemy.Name} readies an attack..");
        TurnReports.Enqueue(Enemy.Attack(Player));
    }

    public void PlayerAttack(){
        TurnReports.Enqueue("You ready an attack..");
        TurnReports.Enqueue(Player.Attack(Player));
    }

    public void PlayerCastSkill(int index, Entity target)
    {
        TurnReports = Player.CastSkill(index, target);
    }
}