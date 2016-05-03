using System;
using Assets.Scripts.Bosses.Harbinger_of_death;
using UnityEngine;

namespace Assets.Scripts.Bosses
{
    public class BossStateMachine : MonoBehaviour
    {
        public Enum CurrentState;
        public Enum PreviusState;
        protected BossStateExecuter _currentStateExecuter;
        protected BossFactoryable _bossStateExecuterFactory;

        protected virtual void Start()
        {
            Invoke("DelayedStart", 0.1f);
        }

        protected virtual void DelayedStart()
        {

        }

        public virtual void ChangeState(Enum newState)
        {
            SetStates(newState);
            if (_currentStateExecuter != null)
            {
                _currentStateExecuter.EndState(this);
            }
            _currentStateExecuter = _bossStateExecuterFactory.GetBossStateExecuter(newState);
            _currentStateExecuter.StartState(this);
        }

        protected virtual void SetStates(Enum newState)
        {
            PreviusState = CurrentState;
            CurrentState = newState;
            print("new current state" + newState + " previous state" + PreviusState);
        }
    }
}