using UnityEngine;

namespace Assets.Scripts.Movement
{
    public class LookAtTargetXz : MonoBehaviour
    {
        public string TargetTag = "Player";
        public float LookTime;
        public bool CanLook = true;

        private Transform _target;

        void Start()
        {
            _target = GameObject.FindGameObjectWithTag(TargetTag).transform;
        }

        void Update()
        {
            if (CanLook)
            {
                Vector3 lookAtPosition = new Vector3(_target.transform.position.x, transform.position.y, _target.transform.position.z);
                Vector3 lookRotation = Quaternion.LookRotation(lookAtPosition - transform.position).eulerAngles;
                LeanTween.rotate(gameObject, lookRotation, LookTime);
            }
        }
    }
}