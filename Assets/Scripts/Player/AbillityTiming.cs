using System;
using UnityEngine;

namespace Assets.Scripts.Player.Swords.Abstract.Movement
{
    public class AbillityTiming : MonoBehaviour
    {
        public float Duration;
        public bool Active { get; private set; }

        public event Action AbillityStart;
        public event Action AbillityUpdate;
        public event Action AbillityEnd;

        private float _abilltyTimer = int.MinValue;

        void Start()
        {
            Active = false;

        }

        public virtual void UseAbillity()
        {
            if (!Active)
            {
                OnAbillityStart();
            }
        }

        void Update()
        {
            if (Active)
            {
                OnAbillityUpdate();
            }
            if (Active && _abilltyTimer > Duration)
            {
                OnAbillityEnd();
            }

            _abilltyTimer += Time.deltaTime;
        }

        private void OnAbillityStart()
        {
            if (AbillityStart != null)
            {
                AbillityStart();
            }
            _abilltyTimer = 0;
            Active = true;
        }

        private void OnAbillityUpdate()
        {
            if (AbillityUpdate != null)
            {
                AbillityUpdate();
            }
        }

        private void OnAbillityEnd()
        {
            Active = false;
            if (AbillityEnd != null)
            {
                AbillityEnd();
            }
        }
    }
}