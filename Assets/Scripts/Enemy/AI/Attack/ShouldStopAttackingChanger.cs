using Assets.Scripts.Enemy.AI.Behaviours.GroupBehaviours.Abstract;
using Assets.Scripts.Enemy.AI.Factories;
using Assets.Scripts.Enemy.AI.Mind.Abstact;
using Assets.Scripts.Enemy.Attacks;
using Assets.Scripts.Enemy.Attacks.Abstract;

namespace Assets.Scripts.Enemy.AI.Attacks
{
    public class ShouldStopAttackingChanger : StateChangerBase
    {
        public override bool ShouldStateChange(State currentState, out State newState)
        {
            AttackState attackState = currentState as AttackState;
            CombatActor<AttackStats> currentAttack = attackState.CurrentAttack;
            if (!currentAttack.IsInRangeToAttack)
            {
                newState = _groupBehaviourManager.GetState(StateType.Movement);
                return true;
            }
            newState = null;
            return false;
        }
    }
}