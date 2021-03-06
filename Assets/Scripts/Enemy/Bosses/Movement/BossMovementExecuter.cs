﻿using System;
using Assets.Scripts.Bosses.Abstract;
using Assets.Scripts.Movement;
using UnityEngine;

namespace Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters
{
    public abstract class BossMovementExecuter : MonoBehaviour, BossStateExecuter
    {
        private float _timeToFollow;

        private MoveForward _moveForward;
        private BossStateMachine _bossStateMachine;
        protected EnemySpecsLoader EnemySpecsLoader;
        protected Enum _attackState;

        protected virtual void Start()
        {
            _moveForward = GetComponentInParent<MoveForward>();
            EnemySpecsLoader = GetComponentInParent<EnemySpecsLoader>();
            LoadSpecs();
        }

        public void LoadSpecs()
        {
            float[] specs = EnemySpecsLoader.EnemySpecs.MovementSpecs;
            _moveForward.Speed = specs[0];
            _timeToFollow = specs[1];
        }

        public void StartState(BossStateMachine bossStateMachine)
        {
            _bossStateMachine = bossStateMachine;
            _moveForward.StartMoving();
            Timer.Start(gameObject, _timeToFollow, SwitchToAttacking);
        }

        protected virtual void SwitchToAttacking()
        {
            _moveForward.StopMoving();
            _bossStateMachine.ChangeState(_attackState);
        }

        public void EndState(BossStateMachine bossStateMachine)
        {
            _moveForward.StopMoving();
        }
    }
}