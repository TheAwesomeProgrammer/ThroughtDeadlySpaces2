using System;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    public class AnimationEventListener : MonoBehaviour
    {
        public bool StartAttackOnAnimation = true;
        public bool EndAttackOnAnimation = true;
        
        private AnimatorTrigger _animatorTrigger;

        void Start()
        {
            _animatorTrigger = GetComponent<AnimatorTrigger>();
        }

        public void SetupAnimatorTriggerEnd( Action onEndAttackAction)
        {
            SetupAnimatorTrigger(null, onEndAttackAction);
        }

        public void SetupAnimatorTriggerStart(Action onStartAttackAction)
        {
            SetupAnimatorTrigger(onStartAttackAction, null);
        }

        public void SetupAnimatorTrigger(Action onStartAttackAction, Action onEndAttackAction)
        {
            if (_animatorTrigger != null)
            {
                if (onStartAttackAction != null && StartAttackOnAnimation)
                {
                    _animatorTrigger.AnimationStarting += onStartAttackAction;
                }
                if (onEndAttackAction != null && EndAttackOnAnimation)
                {
                    _animatorTrigger.AnimationEnded += onEndAttackAction;
                }
            }
        }
    }
}