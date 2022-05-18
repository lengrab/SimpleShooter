using UnityEngine;

public class WalkState : State
{
    private float _minDistanceToTarget = 0.25f;

    public WalkState(Enemy enemy) : base(enemy) { }

    public override void UpdateState()
    {
        if (_enemy != null && _enemy.Target != null)
        {
            if (Vector3.Distance(_enemy.transform.position, _enemy.Target.transform.position) > _minDistanceToTarget)
            {
                Vector3 direction = Vector3.Normalize(_enemy.Target.transform.position - _enemy.transform.position);
                _enemy.MoveToTarget();
            }
            else
            {
                _enemy.DoIdle();//TODO А где логика когда дошли?
            }
        }
    }
}
