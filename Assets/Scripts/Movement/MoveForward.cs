using UnityEngine;

namespace Assets.Scripts.Movement
{
    public class MoveForward : MonoBehaviour
    {
        public float Speed;

        private bool _movingAfterTarget;

        private Rigidbody _rigidbodyToMove;

        void Start()
        {
            _rigidbodyToMove = GetComponent<Rigidbody>();
            StartMoving();
        }

        public void SetObjectToMove(Rigidbody rigidbodyToMove)
        {
            _rigidbodyToMove = rigidbodyToMove;
        }

        public void StopMoving()
        {
            _movingAfterTarget = false;
        }

        public void StartMoving()
        {
            _movingAfterTarget = true;
        }

        void Update()
        {
            if (_movingAfterTarget && _rigidbodyToMove != null)
            {
                Vector3 moveDirection = transform.forward * Speed;
                moveDirection.y = _rigidbodyToMove.velocity.y;
                _rigidbodyToMove.velocity = moveDirection;
            }
        }
    }
}