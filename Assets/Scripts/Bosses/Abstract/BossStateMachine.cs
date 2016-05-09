using System;
using Assets.Scripts.Bosses.Harbinger_of_death;
using UnityEngine;

namespace Assets.Scripts.Bosses
{
    public class BossStateMachine : MonoBehaviour
    {
        public Enum CurrentState;
        public Enum PreviusState;
        public event Action<Enum,Enum> ChangingState;

        protected BossStateExecuter _currentStateExecuter;
        protected BossFactoryable _bossStateExecuterFactory;
        protected bool _canChange;

        protected virtual void Start()
        {
            _bossStateExecuterFactory = GetComponentInChildren<BossFactoryable>();
            Timer.Start(0.1f, DelayedStart);
        }

        protected virtual void DelayedStart()
        {

        }

        public virtual void ChangeState(Enum newState)
        {
            ShouldChangeState(CurrentState, newState);
            if (_canChange)
            {
                SetStates(newState);
                if (_currentStateExecuter != null)
                {
                    _currentStateExecuter.EndState(this);
                }
                _currentStateExecuter = _bossStateExecuterFactory.GetBossStateExecuter(newState);
                _currentStateExecuter.StartState(this);
            }
        }

        private void ShouldChangeState(Enum previusState, Enum newState)
        {
            _canChange = true;
            if (ChangingState != null)
            {
                ChangingState(previusState, newState);
            }
        }

        public void CancelStateChanging()
        {
            _canChange = false;
        }

        protected virtual void SetStates(Enum newState)
        {
            PreviusState = CurrentState;
            CurrentState = newState;
            print("new current state" + newState + " previous state" + PreviusState);
        }
    }
}