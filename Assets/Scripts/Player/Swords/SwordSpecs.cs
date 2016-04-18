namespace Assets.Scripts.Player.Swords
{
    public class SwordSpecs
    {
        public int BaseDamage;
        public int CombatType1Damage;
        public int CombatType2Damage;
        public int CombatType3Damage;
        public int CombatType4Damage;

        public SwordSpecs(int baseDamage, int combatType1Damage, int combatType2Damage, int combatType3Damage,
            int combatType4Damage)
        {
            BaseDamage = baseDamage;
            CombatType1Damage = combatType1Damage;
            CombatType2Damage = combatType2Damage;
            CombatType3Damage = combatType3Damage;
            CombatType4Damage = combatType4Damage;
        }
    }
}