using Assets.Scripts.Combat;
using Assets.Scripts.Combat.Attack;

namespace Assets.Scripts.Player.Swords
{
    public interface SwordDamageModifier
    {
        DamageData GetModifiedDamageData(DamageData damageData);
        DamageData ModifydamageData(DamageData damageData);
    }
}