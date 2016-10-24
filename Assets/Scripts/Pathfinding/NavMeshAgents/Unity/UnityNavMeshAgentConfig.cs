using System;
using System.Collections.Generic;
using Assets.Scripts.Extensions;
using Assets.Scripts.Tests;
using UnityEngine;

namespace Assets.Scripts.Pathfinding
{
    [Serializable]
    public class UnityNavMeshAgentConfig : NavMeshAgentConfig
    {
        private UnityEngine.NavMeshAgent _unityNavMeshAgent;

        public override void Init(object navMeshAgentObject)
        {
            base.Init(navMeshAgentObject);
            _unityNavMeshAgent = _navMeshAgentObject as UnityEngine.NavMeshAgent;
            NullAsserter.Assert(_unityNavMeshAgent, "Unity nav mesh agent");
            AddPropertyChangeData(this.NameOf(() => Speed), (value) => _unityNavMeshAgent.speed = (float)value);
            AddPropertyChangeData(this.NameOf(() => AngularSpeed), (value) => _unityNavMeshAgent.angularSpeed = (float)value);
            AddPropertyChangeData(this.NameOf(() => Acceleration), (value) => _unityNavMeshAgent.acceleration = (float)value);
            AddPropertyChangeData(this.NameOf(() => StoppingDistance), (value) => _unityNavMeshAgent.stoppingDistance = (float)value);
            SetStats();
        }

        public override void SetStats()
        {
            _unityNavMeshAgent.speed = Speed;
            _unityNavMeshAgent.angularSpeed = AngularSpeed;
            _unityNavMeshAgent.acceleration = Acceleration;
            _unityNavMeshAgent.stoppingDistance = StoppingDistance;
        }
    }
}