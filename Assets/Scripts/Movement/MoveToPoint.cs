using System;
using Assets.Scripts.Extensions;
using Assets.Scripts.Movement;
using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Bridge
{
    [Serializable]
    public class PointInformation
    {
        public Vector3 Point;
        public bool IsLocalPoint = true;
        public bool CalculateAtStart;

        private Vector3 _startPosition;

        public void Init(GameObject gameObject)
        {
            if (CalculateAtStart)
            {
                _startPosition = CalculatePosition(gameObject);
            }
        }

        public Vector3 GetPosition(GameObject gameObject)
        {
            if (CalculateAtStart)
            {
                return _startPosition;
            }
            else
            {
                return CalculatePosition(gameObject);
            }
        }

        public void SetPosition(GameObject gameObject)
        {
            if (CalculateAtStart)
            {
                gameObject.SetPosition(_startPosition);
            }
        }

        private Vector3 CalculatePosition(GameObject gameObject)
        {
            Vector3 position = gameObject.GetPosition();

            if (IsLocalPoint)
            {
                position += Point;
            }
            else
            {
                position = Point;
            }

            return position;
        }
    }

    public class MoveToPoint : MonoBehaviour, SpeedSetable
    {
        public PointInformation StartPoint;
        public PointInformation EndPoint;
        public LeanTweenType LeanTweenType;
        public float Time = 1;
        public GameObject ObjectToMove;

        public event Action OnMoved;

        private Vector3 _targetPoint;

        public void Start()
        {
            if (!ObjectToMove)
            {
                ObjectToMove = gameObject;
            }
            StartPoint.Init(ObjectToMove);
            EndPoint.Init(ObjectToMove);
            SetTargetPoint(EndPoint);
            StartPoint.SetPosition(ObjectToMove);
        }

        public void Move()
        {
	        LeanTween.move(ObjectToMove, _targetPoint, Time).setEase(LeanTweenType).setOnComplete(OnCompleteTween);
        }

        private void OnCompleteTween()
        {
            OnMoved.InvokeIfNotNull();
        }

        public void MoveToStartPosition()
        {
            SetTargetPoint(StartPoint);
            Move();
        }

        public void Move(PointInformation target)
        {
            SetTargetPoint(target);
            Move();
        }

        public void Stop()
        {
            LeanTween.cancel(ObjectToMove);
        }

        public void SetTargetPoint(Vector3 targetPoint)
        {
            _targetPoint = targetPoint;
        }

        public void SetTargetPoint(PointInformation targetPoint)
        {
	        _targetPoint = targetPoint.GetPosition(ObjectToMove);
        }

        public void SetSpeed(float speed)
        {
            Time = speed;
        }
    }
}