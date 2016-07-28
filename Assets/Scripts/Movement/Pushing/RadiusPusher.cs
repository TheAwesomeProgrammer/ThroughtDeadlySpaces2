using System;
using System.Collections.Generic;
using Assets.Scripts.Enviroment.Collisions.Abstract;
using Assets.Scripts.Player.Swords.Abstract.Bosses.Attack;
using UnityEngine;

namespace Assets.Scripts.Combat.Attack
{
    public abstract class RadiusPusher : Trigger
    {
        public bool PushOnStart;
        public float PushingForce = 1000;
        public Rigidbody OwnerRigidbody;

        public event Action Pushing;

        private List<Rigidbody> _rigidbodiesInPushRadius;
        private SphereCollider _pushRadiusCollider;

        protected override void Start()
        {
            base.Start();
            _rigidbodiesInPushRadius = new List<Rigidbody>();
            _pushRadiusCollider = GetComponent<SphereCollider>();
            ShouldPushOnStart();
        }

        private void ShouldPushOnStart()
        {
            if (PushOnStart)
            {
                ShouldCallPushingEvent();
                Timer.Start(gameObject, 0.1f, Push);
            }
        }

        private void ShouldCallPushingEvent()
        {
            if (Pushing != null)
            {
                Pushing();
            }
        }

        public void Push()
        {
            foreach (var rigidbodyInExplosion in _rigidbodiesInPushRadius)
            {
                if (rigidbodyInExplosion != null)
                {
                    rigidbodyInExplosion.AddExplosionForce(PushingForce, transform.position, _pushRadiusCollider.radius, 0f);
                }
            }
        }

        public override void OnStay()
        {
            base.OnStay();
            Rigidbody attachedRigidbody = _triggerCollider.attachedRigidbody;
            if (ExistRigidbody(attachedRigidbody))
            {
                AddRigidbody(attachedRigidbody);
            }
        }

        protected virtual void AddRigidbody(Rigidbody attachedRigidbody)
        {
            if (OwnerRigidbody != attachedRigidbody)
            {
                _rigidbodiesInPushRadius.Add(attachedRigidbody);
            }
        }

        protected virtual bool ExistRigidbody(Rigidbody attachedRigidbody)
        {
            return attachedRigidbody != null && !_rigidbodiesInPushRadius.Contains(attachedRigidbody);
        }

        public override void OnExit()
        {
            base.OnExit();
            Rigidbody attachedRigidbody = _triggerCollider.attachedRigidbody;
            if (ExistRigidbody(attachedRigidbody))
            {
                RemoveRigidbody(attachedRigidbody);
            }
        }

        protected virtual void RemoveRigidbody(Rigidbody attachedRigidbody)
        {
            _rigidbodiesInPushRadius.Remove(attachedRigidbody);
        }
    }
}