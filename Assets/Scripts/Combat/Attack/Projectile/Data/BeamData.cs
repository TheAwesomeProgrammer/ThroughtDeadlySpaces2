namespace Assets.Scripts.Combat.Attack.Projectile.Data
{
    public class BeamData : ProjectileData
    {
        public float StartDelay;

        public BeamData(int damage, float startDelay) : base(damage)
        {
            StartDelay = startDelay;
        }
    }
}