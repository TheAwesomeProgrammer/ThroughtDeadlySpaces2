using UnityEngine;

namespace Assets.Scripts.Extensions
{
    public static class AnimatorExtensions
    {
        public static bool HasParameter(this Animator animator, string paramName)
        {
            foreach (AnimatorControllerParameter param in animator.parameters)
            {
                if (param.name == paramName)
                    return true;
            }
            return false;
        }

        public static float GetDurationOfAnimation(this Animator animator, string animationName)
        {
            float animationDuration = 0;

            RuntimeAnimatorController animatorController = animator.runtimeAnimatorController;    //Get Animator controller
            for (int i = 0; i < animatorController.animationClips.Length; i++)                 //For all animations
            {
                if (animatorController.animationClips[i].name == animationName)        //If it has the same name as your clip
                {
                    animationDuration = animatorController.animationClips[i].length;
                }
            }

            return animationDuration;
        }

    }
}