using System.Collections.Generic;
using Assets.Scripts.Enemy;
using Assets.Scripts.Enemy.AI;
using Assets.Scripts.Enemy.AI.Factories;
using Assets.Scripts.Tests.Helper;
using UnityEngine;

namespace Assets.Scripts.Tests.Enemy
{
    public class GroupMovementTest : MonoBehaviour
    {
        private Group _group;
        private EnemyClosest _enemyClosest;

        private void Start()
        {
            _group = GetComponentInChildren<Group>();
            _enemyClosest = GetComponentInChildren<EnemyClosest>();
            Timer.Start(gameObject, 3.5f, DeleteEnemyAndCheckThatMovementBehavioursUpdate);
        }

        private void CheckMovementBehaviours()
        {
            List<EnemyMind> aggressiveMinds = _group.GetEnemiesBy(BehaviourType.Agressive);
            List<EnemyMind> defensiveMinds = _group.GetEnemiesBy(BehaviourType.Defensive);

            foreach (var enemyMind in _group.Enemies)
            {
                Debug.Log("Enemy mind behaviour state "+ enemyMind.CurrentStateData.BehaviourType);
            }

            IntegrationAssert.Equals(aggressiveMinds.Count, _enemyClosest.EnemiesThatCanAttackAtSameTime);
            IntegrationAssert.Equals(defensiveMinds.Count, _group.EnemiesCount() - _enemyClosest.EnemiesThatCanAttackAtSameTime);
        }

        private void DeleteEnemyAndCheckThatMovementBehavioursUpdate()
        {
            GameObject enemyGameObject = _group.Enemies[0].gameObject;
            Destroy(enemyGameObject);
            Timer.Start(gameObject, 1, CheckMovementBehaviours);
        }
    }
}