using System;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    public class TestAnimatorTrigger : AnimatorTriggerBase
    {
        public float AnimationDuration;

        public override void StartAnimation(AnimatorRunMode animatorRunMode)
        {
            Debug.Log("Starting animation with trigger name : " + TriggerName + Environment.NewLine + 
                "With a duration of "+ AnimationDuration);
            OnAnimationStarting();
            Timer.Start(gameObject, AnimationDuration, EndAnimation);
        }

        public override void EndAnimation()
        {
            Debug.Log("Starting animation with trigger end name : " + TriggerEndName);
            OnAnimationEnded();
        }

        public override void CancelAnimation()
        {
            Debug.Log("Cancelling animation");
        }
    }
}