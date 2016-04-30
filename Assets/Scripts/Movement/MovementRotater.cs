using TeamUtility.IO;
using UnityEngine;

namespace Assets.Scripts.Movement
{
    public class MovementRotater : MonoBehaviour
    {
        private int _rotationOffset;

        public void SetRotation(Vector3 newMovedirection)
        {
            SetRotationOffset();
            Vector2 movementVector2 = new Vector2(newMovedirection.x, newMovedirection.z);
            transform.rotation = Quaternion.Euler(0, movementVector2.GetAngleBasedOnDirection() + _rotationOffset, 0);
        }

        void SetRotationOffset()
        {
            if (InputAdapter.inputDevice != InputDevice.Joystick)
            {
                _rotationOffset = -90;
            }
            else
            {
                _rotationOffset = -90;
            }
        }
    }
}