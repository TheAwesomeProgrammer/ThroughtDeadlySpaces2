using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    public class AnimatorTriggerWithLayer : AnimatorTrigger
    {
        public int LayerNumber;

        protected override AnimatorStateInfo GetNextAnimatorStateInfo()
        {
            return Animator.GetNextAnimatorStateInfo(LayerNumber);
        }
    }
}