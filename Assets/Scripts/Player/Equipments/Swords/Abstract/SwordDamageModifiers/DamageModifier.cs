using Assets.Scripts.Combat;
using Assets.Scripts.Combat.Attack;

namespace Assets.Scripts.Player.Swords
{
    public abstract class DamageModifier : SwordComponent,CombatModifier
    {
        protected DamageData _damageData;

        public virtual CombatData GetModifiedCombatData(CombatData combatData)
        {
            _damageData = (DamageData) combatData;
            return _damageData;
        }

        public abstract DamageData ModifydamageData(DamageData damageData);
    }
}