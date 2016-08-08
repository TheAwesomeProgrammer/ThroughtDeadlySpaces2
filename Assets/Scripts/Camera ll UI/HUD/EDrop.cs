using Assets.Scripts.Enviroment.Map.Bridge;
using UnityEngine;

namespace Assets.Scripts.Camera_ll_UI.HUD
{
    public class EDrop : MonoBehaviour
    {
        public float AmountToRotate;
        public Vector2 AmountToMove;
        public float Time;
        public bool AutoPlay;

        private MoveToPoint _moveToPoint;

        public void Start()
        {
            _moveToPoint = GetComponent<MoveToPoint>();
            if (AutoPlay)
            {
                Drop();
                _moveToPoint.enabled = false;
            }
        }

        public void Drop()
        {
            LeanTween.rotateZ(gameObject, transform.eulerAngles.z + AmountToRotate, Time);
            Timer.Start(gameObject, Time, () => LeanTween.move(GetComponent<RectTransform>(),
                GetComponent<RectTransform>().anchoredPosition + AmountToMove, Time));
            Timer.Start(gameObject, Time * 2, Reset);
        }

        private void Reset()
        {
            transform.eulerAngles = Vector3.zero;
            _moveToPoint.SetTargetPoint(_moveToPoint.StartPoint);
            _moveToPoint.enabled = true;
        }
    }
}