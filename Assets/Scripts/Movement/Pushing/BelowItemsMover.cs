using UnityEngine;

namespace Assets.Scripts.Movement.Pushing
{
    public class BelowItemsMover : CollisionChecking
    {
        public float MinYThreeshold = 1;
        public float TweenTime = 1;

        private const float ForwardDistance = 100;

        public override void OnEnterWithTag()
        {
            base.OnEnterWithTag();
            if ((transform.position.y - _collisionObject.transform.position.y)  > MinYThreeshold)
            {
                Vector3 forwardMovedPosition = _collisionObject.transform.position + transform.forward * ForwardDistance;
                Vector3 belowItemNewPosition = _myCollider.ClosestPointOnBounds(forwardMovedPosition);
                LeanTween.move(_collisionObject.gameObject, belowItemNewPosition, TweenTime);
            }
        }
    }
}