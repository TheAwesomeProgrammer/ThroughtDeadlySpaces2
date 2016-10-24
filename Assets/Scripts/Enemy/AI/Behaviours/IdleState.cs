using UnityEngine;

namespace Assets.Scripts.Enemy.AI.Abstact
{
    public class IdleState : MonoBehaviour, State
    {
        public bool ExitOnReEntry
        {
            get { return false; }
        }

        public void OnEnterState()
        {
            Debug.Log("Entering idle state");
        }

        public void OnExitState()
        {
            Debug.Log("Exiting idle state");
        }
    }
}