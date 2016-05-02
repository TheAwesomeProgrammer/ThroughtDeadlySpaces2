using Assets.Scripts.Player.Swords;
using UnityEngine;

namespace Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters
{
    public class HarbingerPauseExecuter : MonoBehaviour, BossStateExecuter
    {
        private HarbingerPauser _harbingerPauser;
        private AnimatorTrigger _animatorTrigger;

        protected virtual void Start()
        {
            _harbingerPauser = new HarbingerPauser();
            _animatorTrigger = GetComponent<AnimatorTrigger>();
        }

        public virtual void StartState(HarbingerOfDeath harbingerOfDeath)
        {
            _animatorTrigger.StartAnimation();
            StartCoroutine(_harbingerPauser.WaitThenChangeStateToMove(harbingerOfDeath));
        }

        public virtual void EndState(HarbingerOfDeath harbingerOfDeath)
        {

        }
    }
}