public class DeadState : State
{
    public DeadState(Enemy enemy) : base(enemy)
    {
    }

    public override void UpdateState()
    {
        _enemy.Destroy();
    }
}
