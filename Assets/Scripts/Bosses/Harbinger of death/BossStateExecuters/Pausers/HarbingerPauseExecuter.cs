using Assets.Scripts.Player.Swords;
using UnityEngine;

namespace Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters
{
    public class HarbingerPauseExecuter : MonoBehaviour, BossStateExecuter
    {
        private HarbingerPauser _harbingerPauser;
        private AnimatorTrigger _animatorTrigger;

        private void Start()
        {
            _harbingerPauser = new HarbingerPauser();
            _animatorTrigger = GetComponent<AnimatorTrigger>();
        }

        public void StartState(HarbingerOfDeath harbingerOfDeath)
        {
            _animatorTrigger.StartAnimation();
            StartCoroutine(_harbingerPauser.WaitThenChangeStateToMove(harbingerOfDeath));
        }

        public void EndState(HarbingerOfDeath harbingerOfDeath)
        {

        }
    }
}