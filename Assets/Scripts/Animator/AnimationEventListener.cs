using System;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    public class AnimationEventListener : MonoBehaviour
    {
        public bool StartAttackOnAnimation = true;
        public bool EndAttackOnAnimation = true;
        
        private AnimatorTrigger _animatorTrigger;

        void Awake()
        {
            _animatorTrigger = GetComponent<AnimatorTrigger>();
        }

        public void SetupAnimatorTrigger(Action onStartAttackAction = null, Action onEndAttackAction = null)
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