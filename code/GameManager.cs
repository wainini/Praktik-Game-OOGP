public enum GameState
{
    PlayerTurn,
    EnemyTurn
}

class GameManager
{
    public Player Player { get; private set; }
    public Enemy Enemy { get; private set; }

    private int firstEnemyDamage = 7;
    private int firstEnemyHP = 35;

    public GameState CurrentState { get; private set; }

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
    }
}