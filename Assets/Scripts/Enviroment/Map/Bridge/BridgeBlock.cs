using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Bridge
{
    public class BridgeBlock : MonoBehaviour
    {
        private Vector3 _startPosition;
        private ActionDelayer _actionDelayer;
        private MoveToPoint _moveToPoint;

        public void Start()
        {
            _actionDelayer = GetComponent<ActionDelayer>();
            _moveToPoint = GetComponent<MoveToPoint>();
            _startPosition = transform.position + (-_moveToPoint.Point);
            transform.position = _startPosition;
            _moveToPoint.CalculateTarget();
        }

        public void Activate()
        {
            _actionDelayer.Delay(ActivateAction);
        }

        private void ActivateAction()
        {
            _moveToPoint.Activate();
        }

        public void Deactivate()
        {
            _actionDelayer.Delay(DeactivateAction);
        }

        private void DeactivateAction()
        {
            _moveToPoint.SetTargetPoint(_startPosition);
            _moveToPoint.Activate();
        }
    }
}