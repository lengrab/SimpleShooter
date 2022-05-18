using UnityEngine;

public abstract class State
{
    protected Enemy _enemy;

    protected State(Enemy enemy)
    {
        _enemy = enemy;
    }
    
    public abstract void UpdateState();
}
