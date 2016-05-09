using Assets.Scripts.Player.Swords.Abstract;
using UnityEngine;

namespace Assets.Scripts.Movement
{
    public class LookAtTargetXz : MonoBehaviour
    {
        public string TargetTag = Tag.Player;
        public float LookTime;

        private Transform _target;
        private bool _canLook;

        void Start()
        {
            _canLook = true;
            GameObject targetObject = GameObject.FindGameObjectWithTag(TargetTag);
            if (targetObject != null)
            {
                _target = targetObject.transform;
            }
        }

        void Update()
        {
            if (_canLook && _target != null)
            {
                Vector3 lookAtPosition = new Vector3(_target.transform.position.x, transform.position.y, _target.transform.position.z);
                Vector3 lookRotation = Quaternion.LookRotation(lookAtPosition - transform.position).eulerAngles;
                LeanTween.rotate(gameObject, lookRotation, LookTime);
            }
        }

        public void StopLooking()
        {
            _canLook = false;
        }

        public void StartLooking()
        {
            _canLook = true;
        }
    }
}