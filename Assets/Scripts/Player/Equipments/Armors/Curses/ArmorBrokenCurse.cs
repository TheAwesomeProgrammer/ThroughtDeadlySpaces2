using Assets.Scripts.Combat.Defense;
using Assets.Scripts.Player.Armors.ArmorModifier;
using Assets.Scripts.Player.Equipments;

namespace Assets.Scripts.Player.Armors.Curses
{
    public class ArmorBrokenCurse : ArmorReduceModifier
    {
        public override DefenseData ReduceDefenseData(DefenseData defenseData)
        {
            defenseData.Defense = 0;
            return defenseData;
        }
    }
}