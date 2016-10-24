using RAIN.Core;
using RAIN.Motion;
using RAIN.Navigation;
using RAIN.Navigation.Pathfinding;
using RAIN.Serialization;
using UnityEngine;

namespace Assets.Scripts.Pathfinding
{
    public class MoveToTarget : MonoBehaviour
    {
        public Transform Target;

        private NavMeshAgent _navMeshAgent;

        private void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _navMeshAgent.MoveTo(Target);
        }
    }
}