using System;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    public class AnimationEventListener : MonoBehaviour
    {
        public bool ListenToStartAnimation = true;
        public bool ListenToEndAnimation = true;
        
        private AnimatorTriggerBase _animatorTrigger;

        void Awake()
        {
            _animatorTrigger = GetComponent<AnimatorTriggerBase>();
        }

        public void SetupAnimatorTrigger(Action onStartAttackAction = null, Action onEndAttackAction = null)
        {
            if (_animatorTrigger != null)
            {
                if (onStartAttackAction != null && ListenToStartAnimation)
                {
                    _animatorTrigger.AnimationStarting += onStartAttackAction;
                }
                if (onEndAttackAction != null && ListenToEndAnimation)
                {
                    _animatorTrigger.AnimationEnded += onEndAttackAction;
                }
            }
        }
    }
}