using UnityEngine;

namespace Assets.Scripts.Movement
{
    public class LookAtTargetXz : MonoBehaviour
    {
        public GameObject LookTarget;
        public float LookTime;
        public bool CanLook = true;

        void Update()
        {
            if (CanLook)
            {
                Vector3 lookAtPosition = new Vector3(LookTarget.transform.position.x, transform.position.y, LookTarget.transform.position.z);
                Vector3 lookRotation = Quaternion.LookRotation(lookAtPosition - transform.position).eulerAngles;
                LeanTween.rotate(gameObject, lookRotation, LookTime);
            }
        }
    }
}