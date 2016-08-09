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
        private bool _fall;

        protected void Start()
        {
            _capsuleCollider = GetComponent<CapsuleCollider>();
            _playerMovement = GetComponent<PlayerMovement>();
            //InvokeRepeating("CheckIfFalling", 0.1f, 1f/UpdateRate);
        }

        public void FixedUpdate()
        {
            CheckIfFalling();
        }

        public void CheckIfFalling()
        {
            //aycastHit[] forwardRaycastHits = CapsuleCastAllInDirection(Vector3.forward, ForwardDistanceCheck);
            bool hittingAnythingDown = CapsuleCastAllInDirection(Vector3.down, DownDistanceCheck);

            if (!hittingAnythingDown && _playerMovement.CanMove)
            {
                _fall = true;
                _playerMovement.CanMove = false;
            }
            else if (hittingAnythingDown && !_playerMovement.CanMove)
            {
                _playerMovement.CanMove = true;
                _fall = false;
            }
        }

        private bool CapsuleCastAllInDirection(Vector3 direction, float distanceCheck)
        {
            //Vector3 capsuleCenter = _capsuleCollider.center;
            //Vector3 capsuleTopPoint = transform.position + capsuleCenter + new Vector3(0, _capsuleCollider.height);
            //Vector3 capsuleBottomPoint = transform.position + capsuleCenter + new Vector3(0, -_capsuleCollider.height);
            //float capsuleRadius = _capsuleCollider.radius;
            return Physics.Raycast(new Ray(transform.position, direction), distanceCheck, Physics.AllLayers);
        }
    }
}