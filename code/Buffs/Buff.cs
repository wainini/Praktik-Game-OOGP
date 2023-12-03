class Buff
{
    public string Name { get; protected set; }
    public int Duration{ get; protected set; }

    public int RemainingDuration { get; protected set; }

    public virtual string Activate()
    {
        RemainingDuration--;
        return "";
    }
}