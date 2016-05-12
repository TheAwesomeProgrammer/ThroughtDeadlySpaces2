using UnityEngine;

namespace Assets.Scripts.Player.Swords.Abstract.Movement
{
    public class PlayerSmoother : CollisionChecking
    {
        public float Smoothing = 200;

        private Rigidbody _rigidbody;

        protected override void Start()
        {
            base.Start();
            _rigidbody = GetComponent<Rigidbody>();
        }

        public override void OnStay()
        {
            base.OnStay();
            ContactPoint[] contactPoints = _collisionObject.contacts;
            foreach (var contact in contactPoints)
            {
                Vector3 collisionPoint = contact.point;
                if (collisionPoint.y > transform.position.y)
                {
                    _rigidbody.velocity.Scale(new Vector3(0, 0, Smoothing));
                    break;
                }
            }
        }

        public override void OnExit()
        {
            base.OnExit();
            _rigidbody.velocity = Vector3.zero;
        }
    }
}