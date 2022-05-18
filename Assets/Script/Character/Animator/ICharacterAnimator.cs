public interface ICharacterAnimator
{
    public void Idle();
    public void Run(float speedAnimation);
    public void SimpleAttack();
    public void PowerAttack();
    public void HitDamage();
    public void Dead();
}
