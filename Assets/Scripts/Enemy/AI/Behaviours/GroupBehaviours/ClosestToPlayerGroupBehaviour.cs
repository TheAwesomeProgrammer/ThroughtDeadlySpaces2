using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Enemy.AI.Behaviours.GroupBehaviours.Abstract;
using Assets.Scripts.Enemy.AI.Mind.Abstact;
using Assets.Scripts.Extensions;
using Assets.Scripts.Player.Swords.Abstract;
using UnityEngine;

namespace Assets.Scripts.Enemy.AI.Factories
{
    public class ClosestToPlayerGroupBehaviour : GroupBehaviourBase
    {
        public override GroupSize GroupSize
        {
            get { return GroupSize.Big; }
        }

        public override StateType StateType
        {
            get { return StateType.Movement; }
        }
        private EnemyClosest _enemyClosest;

        protected override void Start()
        {
            base.Start();
            _enemyClosest = GetComponentInParent<EnemyClosest>();
        }

        public override State GetState()
        {
            if (_enemyClosest.IsEnemyClosestToPlayer())
            {
                Debug.Log("Enemy "+ gameObject.name + " is closest to player and will agressively move to player");
                return _states.Find(item => item.BehaviourType == BehaviourType.Agressive);
            }
            Debug.Log("Enemy " + gameObject.name + " is not closest to player and will defensively move to player");
            return _states.Find(item => item.BehaviourType == BehaviourType.Defensive);
        }
    }
}