using System.Collections.Generic;
using Assets.Scripts.Enemy.AI.Mind.Abstact;

namespace Assets.Scripts.Enemy.AI.Factories.StateChangers
{
    public class GroupMovementChanger : StateChangerBase
    {
        private Group _group;
        private EnemyClosest _enemyClosest;

        protected override void Start()
        {
            base.Start();
            _group = GetComponentInParent<Group>();
            _enemyClosest = GetComponentInParent<EnemyClosest>();
        }

        public override bool ShouldStateChange(State currentState, out State newState)
        {
            List<EnemyMind> currentlyAggressiveMinds = _group.GetEnemiesBy(BehaviourType.Agressive);
            if (currentlyAggressiveMinds.Count < _enemyClosest.EnemiesThatCanAttackAtSameTime && 
                currentState.BehaviourType != BehaviourType.Agressive &&
                _group.Size == GroupSize.Big &&
                _enemyClosest.IsEnemyClosestToPlayer())
            {
                newState = GetState(StateType.Movement);
                return true;
            }

            newState = null;
            return false;
        }
    }
}