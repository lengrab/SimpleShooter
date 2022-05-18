using UnityEngine;

public interface ICharacter
{
    public void Idle();
    public void Move(Vector3 direction);
    public void Rotate(float angle);
    public void SimpleAttack();
    public void PowerAttack();
    public void TakeHit(int damage);
    public void Dead();
}
