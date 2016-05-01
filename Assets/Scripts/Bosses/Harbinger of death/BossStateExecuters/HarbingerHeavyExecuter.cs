using Assets.Scripts.Player.Swords;
using UnityEngine;

namespace Assets.Scripts.Bosses.Harbinger_of_death.BossStateExecuters
{
    public class HarbingerHeavyExecuter : MonoBehaviour, BossStateExecuter
    {
        private AnimatorTrigger _animatorTrigger;
        private HarbingerOfDeath _harbingerOfDeath;
        private int[] _possiblePauseStates;

        void Start()
        {
            _possiblePauseStates = new int[2]
            {
                8,10
            };
            _animatorTrigger = GetComponent<AnimatorTrigger>();
            _animatorTrigger.AnimationEnded += OnAnimationEnded;
        }

        void OnAnimationEnded()
        {
            _harbingerOfDeath.ChangeState(GetRandomPauseState());
        }

        private HarbingerOfDeathState GetRandomPauseState()
        {
            return (HarbingerOfDeathState)Random.Range(0, _possiblePauseStates.Length);
        }

        public void StartState(HarbingerOfDeath harbingerOfDeath)
        {
            _animatorTrigger.StartAnimation();
            _harbingerOfDeath = harbingerOfDeath;
        }

        public void EndState(HarbingerOfDeath harbingerOfDeath)
        {
            throw new System.NotImplementedException();
        }
    }
}