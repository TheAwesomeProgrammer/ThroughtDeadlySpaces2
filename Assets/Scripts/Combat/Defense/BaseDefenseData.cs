using Assets.Scripts.Combat.Attack;

namespace Assets.Scripts.Combat.Defense
{
    public class BaseDefenseData : DefenseData
    {
        public BaseDefenseData(int defense) : base(CombatType.BaseType, defense)
        {

        }
    }
}