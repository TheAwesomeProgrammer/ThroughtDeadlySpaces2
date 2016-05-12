using System;
using System.Collections.Generic;
using Assets.Scripts.Bosses.Abstract;
using Assets.Scripts.Player.Swords;
using Assets.Scripts.Player.Swords.Abstract.Bosses.Attack;
using Assets.Scripts.Xml;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters
{
    public abstract class BossAttackBase : MonoBehaviour, BossStateExecuter
    {
        protected AnimatorTrigger _animatorTrigger;
        protected BossStateMachine _bossStateMachine;
        protected BossAttack _bossAttack;
        protected List<Enum> _possiblePauseStates;
        protected int _baseDamage;
        protected int _baseDamageXmlId = 1;
        protected int _attackDelay;
        protected BossSpecsLoader _bossSpecsLoader;
        private AnimationEventListener _animationEventListener;

        protected virtual void Start()
        {
            _possiblePauseStates = new List<Enum>();
            _animatorTrigger = GetComponent<AnimatorTrigger>();
            _bossSpecsLoader = GetComponentInParent<BossSpecsLoader>();
            _bossAttack = transform.root.GetComponentInChildren<BossAttack>();
            _animationEventListener = GetComponent<AnimationEventListener>();
            _animationEventListener.SetupAnimatorTrigger(onEndAttackAction:  OnAnimationEnded);
            _baseDamage = _bossSpecsLoader.BossSpecs.DamageSpecs[_baseDamageXmlId];
        }

        protected void OnAnimationEnded()
        {
            SwitchState();
        }

        public virtual void SwitchState()
        {
            _bossStateMachine.ChangeState(GetRandomPauseState());
            if (_bossAttack != null)
            {
                _bossAttack.EndAttack();
            }
        }

        protected virtual Enum GetRandomPauseState()
        {
            return _possiblePauseStates[Random.Range(0, _possiblePauseStates.Count)];
        }

        public virtual void StartState(BossStateMachine bossStateMachine)
        {
            _bossStateMachine = bossStateMachine;
            ShouldDelayAttack();
        }

        protected virtual void ShouldDelayAttack()
        {
            if (_attackDelay <= 0)
            {
                Attack();
            }
            else if (_attackDelay > 0)
            {
                Timer.Start(_attackDelay, DelayedAttack);
            }
        }

        protected virtual void Attack()
        {
            if (_bossAttack != null)
            {
                _bossAttack.StartAttack();
                _bossAttack.SetExtraBaseDamage(_baseDamage);
            }
            StartAnimation();
        }

        protected virtual void DelayedAttack()
        {
            StartAnimation();
        }

        protected void StartAnimation()
        {
            _animatorTrigger.StartAnimation(AnimatorRunMode.AlwaysRun);
        }

        public void EndState(BossStateMachine bossStateMachine)
        {

        }
    }
}