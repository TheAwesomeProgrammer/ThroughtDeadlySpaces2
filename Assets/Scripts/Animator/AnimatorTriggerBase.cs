using System;
using Assets.Scripts.Extensions;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    public abstract class AnimatorTriggerBase : MonoBehaviour
    {
        public string TriggerName
        {
            get { return _triggerName; }
        }

        public string TriggerEndName
        {
            get { return _triggerEndName; }
        }

        public event Action AnimationEnded;
        public event Action AnimationStarting;

        [SerializeField]
        private string _triggerName;
        [SerializeField]
        private string _triggerEndName;

        public abstract void StartAnimation(AnimatorRunMode animatorRunMode);
        public abstract void EndAnimation();
        public abstract void CancelAnimation();

        protected void OnAnimationStarting()
        {
            AnimationStarting.InvokeIfNotNull();
        }

        protected void OnAnimationEnded()
        {
            AnimationEnded.InvokeIfNotNull();
        }
    }
}