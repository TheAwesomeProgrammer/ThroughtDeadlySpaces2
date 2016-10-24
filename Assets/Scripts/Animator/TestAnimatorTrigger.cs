using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    public class TestAnimatorTrigger : AnimatorTriggerBase
    {
        public override void StartAnimation(AnimatorRunMode animatorRunMode)
        {
            Debug.Log("Starting animation with trigger name : " + TriggerName);
        }

        public override void End()
        {
            Debug.Log("Starting animation with trigger end name : " + TriggerEndName);
        }

        public override void Cancel()
        {
            Debug.Log("Cancelling animation");
        }
    }
}