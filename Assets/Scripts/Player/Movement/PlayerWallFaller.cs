using UnityEngine;

namespace Assets.Scripts.Player.Swords.Abstract.Movement
{
    public class PlayerWallFaller : CollisionChecking
    {
        public PhysicMaterial PhysicMaterial;

        private const float DownDistanceCheck = 5;
        private const float ForwardDistanceCheck = 1;

        private Rigidbody _rigidbody;
        private CapsuleCollider _capsuleCollider;
        private bool _fall;

        protected override void Start()
        {
            base.Start();
            _rigidbody = GetComponent<Rigidbody>();
            _capsuleCollider = GetComponent<CapsuleCollider>();
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            RaycastHit[] forwardRaycastHits = CapsuleCastAllInDirection(Vector3.forward);
            RaycastHit[] downRaycastHits = CapsuleCastAllInDirection(Vector3.down);

            if (forwardRaycastHits.Length > 0 && downRaycastHits.Length <= 0)
            {
                _fall = true;
                _capsuleCollider.material = PhysicMaterial;
            }
        }

        private RaycastHit[] CapsuleCastAllInDirection(Vector3 direction)
        {
            Vector3 capsuleCenter = _capsuleCollider.center;
            float capsuleHeight = _capsuleCollider.height;
            float capsuleRadius = _capsuleCollider.radius;
            return Physics.CapsuleCastAll(capsuleCenter + new Vector3(0, capsuleHeight),
                capsuleCenter + new Vector3(0, -capsuleHeight), capsuleRadius, direction * DownDistanceCheck);
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