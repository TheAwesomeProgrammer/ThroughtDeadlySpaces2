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

        private const int EnemiesThatCanAttackAtSameTime = 2;

        private Group _group;

        protected override void Start()
        {
            base.Start();
            _group = GetComponentInParent<Group>();
        }

        public override State GetState()
        {
            if (IsEnemyClosestToPlayer(EnemiesThatCanAttackAtSameTime))
            {
                Debug.Log("Enemy "+ gameObject.name + " is closest to player and will agressively move to player");
                return _states.Find(item => item.BehaviourType == BehaviourType.Agressive).State;
            }
            Debug.Log("Enemy " + gameObject.name + " is  not closest to player and will defensively move to player");
            return _states.Find(item => item.BehaviourType == BehaviourType.Defensive).State;
        }

        private bool IsEnemyClosestToPlayer(int numberOfClosestEnemies)
        {
            List<EnemyMind> enemiesMinds = _group.Enemies;
            Debug.Assert(enemiesMinds.Count > 0, "Enemies count is less or equal to zero, which shouldn't happen, when the group is big.");
            List<Transform> enemiesTransforms = enemiesMinds.Select(item => item.transform).ToList();

            Transform player = GameObject.FindGameObjectWithTag(Tag.PlayerCollision).transform;
            List<Transform> enemiesCloseToPlayer = enemiesTransforms.FindClosestToTarget(player.position, numberOfClosestEnemies);
            EnemyMind myEnemyMind = GetComponentInParent<EnemyMind>();

            return enemiesCloseToPlayer.Exists(item => item.GetComponent<EnemyMind>() == myEnemyMind);
        }
    }
}