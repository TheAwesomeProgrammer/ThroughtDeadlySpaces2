using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Player.Swords;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters
{
    public abstract class BossPauserBase : MonoBehaviour, BossStateExecuter
    {
        protected Dictionary<Enum, float> _waitTimeSet;
        protected int _bossId = 1;
        protected Enum _movementState;

        private AnimatorTrigger _animatorTrigger;

        protected virtual void Start()
        {
            _animatorTrigger = GetComponent<AnimatorTrigger>();
        }

        protected virtual void SetupWaitTimeSets()
        {
        }

        public IEnumerator WaitThenChangeStateToMove(BossStateMachine bossStateMachine, Enum newState)
        {
            yield return new WaitForSeconds(_waitTimeSet[bossStateMachine.PreviusState]);
            bossStateMachine.ChangeState(newState);
        }

        public virtual void StartState(BossStateMachine bossStateMachine)
        {
            _animatorTrigger.StartAnimation();
            StartCoroutine(WaitThenChangeStateToMove(bossStateMachine, _movementState));
        }

        public virtual void EndState(BossStateMachine bossStateMachine)
        {

        }
    }
}