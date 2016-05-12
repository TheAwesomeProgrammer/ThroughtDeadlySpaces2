using UnityEngine;

namespace Assets.Scripts.Movement.Pushing
{
    public class BelowItemsMover : CollisionChecking
    {
        private const float ForwardDistance = 100;

        public override void OnEnterWithTag()
        {
            base.OnEnterWithTag();
            if (_collisionObject.transform.position.y < transform.position.y)
            {
                Vector3 forwardMovedPosition = _collisionObject.transform.position + transform.forward * ForwardDistance;
                Vector3 belowItemNewPosition = _myCollider.ClosestPointOnBounds(forwardMovedPosition);
                _collisionObject.transform.position = belowItemNewPosition;
            }
        }
    }
}