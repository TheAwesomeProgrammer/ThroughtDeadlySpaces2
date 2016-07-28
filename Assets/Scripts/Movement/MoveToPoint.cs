using Assets.Scripts.Movement;
using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Bridge
{
    public class MoveToPoint : MonoBehaviour, SpeedSetable
    {
        public Vector3 Point;
        public LeanTweenType LeanTweenType;
        public bool IsLocalPoint;
        public float Time;

        private Vector3 _targetPoint;

        public void CalculateTarget()
        {
            _targetPoint = GetTargetPoint();
        }

        public Vector3 GetTargetPoint()
        {
            var targetPoint = Point;
            if (IsLocalPoint)
            {
                targetPoint = transform.position + Point;
            }

            return targetPoint;
        }

        public void Activate()
        {
            LeanTween.move(gameObject, _targetPoint, Time).setEase(LeanTweenType);
        }

        public void Deactivate()
        {
            LeanTween.cancel(gameObject);
        }

        public void SetTargetPoint(Vector3 targetPoint)
        {
            _targetPoint = targetPoint;
        }

        public void SetSpeed(float speed)
        {
            Time = speed;
        }
    }
}