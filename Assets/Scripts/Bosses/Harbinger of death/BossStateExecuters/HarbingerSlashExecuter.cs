using Assets.Scripts.Player.Swords;
using UnityEngine;

namespace Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters
{
    public class HarbingerSlashExecuter : MonoBehaviour, BossStateExecuter
    {
        private AnimatorTrigger _animatorTrigger;
        private HarbingerOfDeath _harbingerOfDeath;

        void Start()
        {
            _animatorTrigger = GetComponent<AnimatorTrigger>();
            _animatorTrigger.AnimationEnded += OnAnimationEnd;
        }

        public void StartState(HarbingerOfDeath harbingerOfDeath)
        {
            _harbingerOfDeath = harbingerOfDeath;
            _animatorTrigger.StartAnimation();
        }

        void OnAnimationEnd()
        {
            _harbingerOfDeath.ChangeState(HarbingerOfDeathState.Idle);
        }

        public void EndState(HarbingerOfDeath harbingerOfDeath)
        {

        }
    }
}