using System;
using System.Collections.Generic;
using Assets.Scripts.Extensions;
using UnityEngine;

namespace Assets.Scripts.Enemy.AI.Vision
{
    public class ChooseBehaviourTypeStateChanger : MonoBehaviour, StateChanger
    {
        public List<MonoBehaviour> Behaviours;

        private EnemyVision _enemyVision;

        private void Start()
        {
            _enemyVision = GetComponentInParent<EnemyVision>();
        }

        public bool ShouldStateChange(State currentState, out Type newStateType)
        {
            if (_enemyVision.CanSeePlayer())
            {
                MonoBehaviour randomBehaviour = Behaviours.Random();
                newStateType = randomBehaviour.GetType();
                return true;
            }

            newStateType = null;
            return false;
        }
    }
}