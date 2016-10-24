using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Tests;
using UnityEngine;

namespace Assets.Scripts.Pathfinding
{
    public sealed class UnityNavMeshAgent : MonoBehaviour, NavMeshAgent
    {
        public Transform Target
        {
            get { return _target; }
        }

        public UnityNavMeshAgentConfig Config
        {
            get { return _config; }
            set { _config = value; }
        }

        public event EventHandler ReachedTarget;

        [HideInInspector]
        NavMeshAgentConfig NavMeshAgent.Config
        {
            get { return _config; }
            set { _config = (UnityNavMeshAgentConfig)value; }
        }

        private UnityEngine.NavMeshAgent _unityNavMeshAgent;
        private Transform _target;
        [SerializeField]
        private UnityNavMeshAgentConfig _config;

        private void Awake()
        {
            _unityNavMeshAgent = GetComponent<UnityEngine.NavMeshAgent>();
            _config.Init(_unityNavMeshAgent);
        }

        public void MoveTo(Transform target)
        {
            _target = target;
            MoveTo(target.position);
            target.UnSubscribeToPositionChanged();
            StartCoroutine(target.SubscribeToPositionChanged(MoveTo));
        }

        public void MoveTo(Vector3 position)
        {
            _unityNavMeshAgent.SetDestination(position);
        }

        public void Stop()
        {
            _unityNavMeshAgent.Stop();
        }

        public void Resume()
        {
            _unityNavMeshAgent.Resume();
        }

        public void Reset()
        {
            _unityNavMeshAgent.Stop();
            _unityNavMeshAgent.ResetPath();
        }

        public void ResetPath()
        {
            _unityNavMeshAgent.ResetPath();
        }

        private void Update()
        {
            NullAsserter.Assert(Config, "Config");
            if (_unityNavMeshAgent.remainingDistance <= Config.StoppingDistance && ReachedTarget != null)
            {
                ReachedTarget.Invoke(this, EventArgs.Empty);
            }
        }
    }
}