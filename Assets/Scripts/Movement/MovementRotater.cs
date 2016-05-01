using TeamUtility.IO;
using UnityEngine;

namespace Assets.Scripts.Movement
{
    public class MovementRotater : MonoBehaviour
    {
        private int _rotationOffset;

        void Start()
        {
            SetRotationOffset();
        }

        public void SetRotation(Vector3 newMovedirection)
        {
            Vector2 movementVector2 = new Vector2(newMovedirection.x, newMovedirection.z);
            transform.rotation = Quaternion.Euler(0, movementVector2.GetAngleBasedOnDirection() + _rotationOffset, 0);
        }

        public void SetRotation(Vector3 newMovedirection, int offset)
        {
            _rotationOffset = offset;
            SetRotation(newMovedirection);
        }

        void SetRotationOffset()
        {
            _rotationOffset = -90;
        }
    }
}