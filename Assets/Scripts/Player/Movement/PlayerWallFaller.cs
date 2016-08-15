using UnityEngine;

namespace Assets.Scripts.Player.Swords.Abstract.Movement
{
    public class PlayerWallFaller : MonoBehaviour
    {
        private const float DownDistanceCheck = 5;
        private const float ForwardDistanceCheck = 1;
        private const float UpdateRate = 10;

        private CapsuleCollider _capsuleCollider;
        private PlayerMovement _playerMovement;
        private AbillityTiming _playerDash;
        private bool _fall;

        protected void Start()
        {
            _capsuleCollider = GetComponent<CapsuleCollider>();
            _playerMovement = GetComponent<PlayerMovement>();
            _playerDash = GetComponentInChildren<AbillityTiming>();
        }

        public void FixedUpdate()
        {
            CheckIfFalling();
        }

        public void CheckIfFalling()
        {
            bool hittingAnythingDown = CapsuleCastAllInDirection(Vector3.down, DownDistanceCheck);

            if (!hittingAnythingDown && _playerMovement.CanMove && !_fall)
            {
                _fall = true;
                _playerMovement.CanMove = false;
            }
            else if (hittingAnythingDown && !_playerMovement.CanMove && !_playerDash.Active && _fall)
            {
                _playerMovement.CanMove = true;
                _fall = false;
            }
        }

        private bool CapsuleCastAllInDirection(Vector3 direction, float distanceCheck)
        {
            Vector3 capsuleCenter = _capsuleCollider.center;
            Vector3 capsuleTopPoint = transform.position + capsuleCenter + new Vector3(0, _capsuleCollider.height);
            Vector3 capsuleBottomPoint = transform.position + capsuleCenter + new Vector3(0, -_capsuleCollider.height);
            float capsuleRadius = _capsuleCollider.radius;
            return Physics.SphereCast(new Ray(capsuleTopPoint, direction), capsuleRadius, distanceCheck,
                Physics.AllLayers);
        }
    }
}