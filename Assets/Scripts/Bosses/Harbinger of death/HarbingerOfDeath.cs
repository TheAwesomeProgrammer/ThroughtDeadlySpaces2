using UnityEngine;

namespace Assets.Scripts.Bosses.Harbinger_of_death
{
    public class HarbingerOfDeath : MonoBehaviour
    {
        public HarbingerOfDeathState CurrentState;
        public HarbingerOfDeathState PreviusState;
        private BossStateExecuter _currentStateExecuter;
        private HarbingerStateExecuterFactory _bossStateExecuterFactory;

        void Start()
        {
            _bossStateExecuterFactory = GetComponentInChildren<HarbingerStateExecuterFactory>();
            Invoke("DelayedStart", 0.1f);
        }

        void DelayedStart()
        {
            ChangeState(HarbingerOfDeathState.Movement);
        }

        public void ChangeState(HarbingerOfDeathState newState)
        {
            PreviusState = CurrentState;
            CurrentState = newState;
            if (_currentStateExecuter != null)
            {
                _currentStateExecuter.EndState(this);
            }
            _currentStateExecuter = _bossStateExecuterFactory.GetBossStateExecuter(newState);
            _currentStateExecuter.StartState(this);
            
        }
    }
}