using Assets.Scripts.Player.Swords;
using Assets.Scripts.Player.Swords.Abstract.Movement;
using UnityEngine;

namespace Assets.Scripts.Enemy.Attacks.Abstract
{
    public abstract class CombatAction : MonoBehaviour
    {
        protected AnimatorTriggerBase _animatorTrigger;
        protected AbillityTiming _abillityTimming;

        private void Start()
        {
            _animatorTrigger = GetComponent<AnimatorTriggerBase>();
            _abillityTimming = GetComponent<AbillityTiming>();
            _abillityTimming.AbillityStart += OnCombatInit;
            _abillityTimming.AbillityUpdate += OnCombatUpdate;
            _abillityTimming.AbillityEnd += OnCombatEnd;
        }

        protected virtual void OnCombatInit()
        {
            _animatorTrigger.StartAnimation(AnimatorRunMode.AlwaysRun);
        }

        protected virtual void OnCombatUpdate(){ }

        protected virtual void OnCombatEnd()
        {
            _animatorTrigger.EndAnimation();
        }
    }
}