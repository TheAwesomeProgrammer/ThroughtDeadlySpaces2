using System;
using Assets.Scripts.Vision;
using UnityEngine;

namespace Assets.Scripts.Enemy.AI.Vision
{
    public class IdleVisonStateChanger : MonoBehaviour, StateChanger
    {
        public MonoBehaviour StateOnVision;

        private EnemyVision _enemyVision;

        private void Start()
        {
            _enemyVision = GetComponentInParent<EnemyVision>();
        }

        public bool ShouldStateChange(State currentState, out Type newStateType)
        {
            if (_enemyVision.CanSeePlayer())
            {
                newStateType = StateOnVision.GetType();
                return true;
            }

            newStateType = null;
            return false;
        }
    }
}