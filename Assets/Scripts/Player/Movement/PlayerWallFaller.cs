using UnityEngine;

namespace Assets.Scripts.Player.Swords.Abstract.Movement
{
    public class PlayerWallFaller : CollisionChecking
    {
        public PhysicMaterial PhysicMaterial;

        private const float DownDistanceCheck = 5;
        private const float ForwardDistanceCheck = 1;

        private Rigidbody _rigidbody;
        private Collider _collider;
        private bool _fall;

        protected override void Start()
        {
            base.Start();
            _rigidbody = GetComponent<Rigidbody>();
            _collider = GetComponent<Collider>();
        }

        public override void OnEnter()
        {
            base.OnEnter();
            RaycastHit[] forwardRaycastHits = Physics.RaycastAll(new Ray(transform.position, transform.forward * ForwardDistanceCheck));
            RaycastHit[] downRaycastHits = Physics.RaycastAll(new Ray(transform.position, Vector3.down * DownDistanceCheck));

            if (forwardRaycastHits.Length > 0 && downRaycastHits.Length <= 0)
            {
                _fall = true;
                _collider.material = PhysicMaterial;
            }
        }

        void LateUpdate()
        {
            if (_fall)
            {
                _rigidbody.velocity = new Vector3(0, _rigidbody.velocity.y, 0);
            }
        }
    }
}