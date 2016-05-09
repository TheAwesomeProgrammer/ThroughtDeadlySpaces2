using UnityEngine;

namespace Assets.Scripts.Combat.Attack
{
    public class ContinuousPusher : RadiusPusher
    {
        private bool _continuousPushing;

        public void StartContinuousPushing()
        {
            _continuousPushing = true;
        }

        public void StopContinuousPushing()
        {
            _continuousPushing = false;
        }

        void Update()
        {
            if (_continuousPushing)
            {
                Push();
            }
        }
    }
}