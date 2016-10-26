using System;
using Assets.Scripts.Enemy.AI.Mind.Abstact;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    [Serializable]
    public abstract class AiState :  MonoBehaviour, State
    {
        public virtual bool ExitOnReEntry
        {
            get { return false; }
        }

        public abstract StateType StateType { get; }

        public abstract void OnEnterState();
        public abstract void OnExitState();
    }
}