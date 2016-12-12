using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Enemy.AI;
using Assets.Scripts.Extensions;
using Assets.Scripts.Player.Swords.Abstract;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyClosest : MonoBehaviour
    {
        public readonly int EnemiesThatCanAttackAtSameTime = 2;

        private Group _group;

        protected void Start()
        {
            _group = GetComponentInParent<Group>();
        }

        public bool IsEnemyClosestToPlayer()
        {
            List<EnemyMind> enemiesMinds = _group.Enemies;
            Debug.Assert(enemiesMinds.Count > 0, "Enemies count is less or equal to zero, which shouldn't happen, when the group is big.");
            List<Transform> enemiesTransforms = enemiesMinds.Select(item => item.transform).ToList();

            Transform player = GameObject.FindGameObjectWithTag(Tag.PlayerCollision).transform;
            List<Transform> enemiesCloseToPlayer = enemiesTransforms.FindClosestToTarget(player.position, EnemiesThatCanAttackAtSameTime);
            EnemyMind myEnemyMind = GetComponentInParent<EnemyMind>();

            return enemiesCloseToPlayer.Exists(item => item.GetComponent<EnemyMind>() == myEnemyMind);
        }
    }
}