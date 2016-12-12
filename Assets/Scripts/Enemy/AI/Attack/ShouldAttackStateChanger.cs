using Assets.Scripts.Enemy.Attacks;
using Assets.Scripts.Enemy.Attacks.Abstract;

namespace Assets.Scripts.Enemy.AI.Attacks
{
    public class ShouldAttackStateChanger : StateChangerBase
    {
        public AiState AttackState;

        private CombatSet<AttackStats> _attackSet;
        private CombatActor<AttackStats> _attack;

        private void Start()
        {
            _attackSet = transform.root.GetComponentInChildren<CombatSet<AttackStats>>();
            _attack = _attackSet.GetCombat();
        }

        public override bool ShouldStateChange(State currentState, out State newState)
        {
            if (_attack.IsInRangeToAttack)
            {
                AttackState attackState = AttackState as AttackState;
                attackState.SetAttack(_attack);
                _attack = _attackSet.GetCombat();
                newState = AttackState;
                return true;
            }

            newState = null;
            return false;
        }
    }
}