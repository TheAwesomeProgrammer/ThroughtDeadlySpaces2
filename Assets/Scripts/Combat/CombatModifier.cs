using Assets.Scripts.Combat;

namespace Assets.Scripts.Player.Swords
{
    public interface CombatModifier
    {
        CombatData GetModifiedCombatData(CombatData combatData);
    }
}