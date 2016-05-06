using System;
using System.Collections.Generic;
using Assets.Scripts.Player.Swords.Abstract.Bosses.Attack;
using UnityEngine;

namespace Assets.Scripts.Combat.Attack
{
    public class ExplosionPusher : Trigger
    {
        public bool ExplodeOnStart;
        public event Action Explosion;

        public const float ExplosionForce = 1000;

        private List<Rigidbody> _rigidbodiesInExplosionRadius;
        private SphereCollider _explosionRadiusCollider;

        protected override void Start()
        {
            base.Start();
            _rigidbodiesInExplosionRadius = new List<Rigidbody>();
            _explosionRadiusCollider = GetComponent<SphereCollider>();
            if (ExplodeOnStart)
            {
                if (Explosion != null)
                {
                    Explosion();
                }
                Timer.Start(0.1f, Explode);
            }
        }

        public void Explode()
        {
            foreach (var rigidbodyInExplosion in _rigidbodiesInExplosionRadius)
            {
                if (rigidbodyInExplosion != null)
                {
                    rigidbodyInExplosion.AddExplosionForce(ExplosionForce, transform.position, _explosionRadiusCollider.radius, 0, ForceMode.Impulse);
                }
            }
        }

        public override void OnStay()
        {
            base.OnStayWithTag();
            Rigidbody attachedRigidbody = _triggerCollider.attachedRigidbody;
            if (attachedRigidbody != null && !_rigidbodiesInExplosionRadius.Contains(attachedRigidbody))
            {
                _rigidbodiesInExplosionRadius.Add(attachedRigidbody);
            }
        }

        public override void OnExit()
        {
            base.OnExitWithTag();
            Rigidbody attachedRigidbody = _triggerCollider.attachedRigidbody;
            if (attachedRigidbody != null && _rigidbodiesInExplosionRadius.Contains(attachedRigidbody))
            {
                _rigidbodiesInExplosionRadius.Remove(attachedRigidbody);
            }
        }
    }
}