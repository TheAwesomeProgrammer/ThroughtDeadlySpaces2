namespace Assets.Scripts.Player.Swords
{
    public interface Attackable
    {
        void DeativateAttack();
        void EnableAttack();
        void StartAttack();
        void EndAttack();
        void IsAttacking();
    }
}