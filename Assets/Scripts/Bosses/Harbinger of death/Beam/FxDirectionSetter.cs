using UnityEngine;

namespace Assets.Scripts
{
    public class FxDirectionSetter : MonoBehaviour
    {
        public string AttributeName = "aVelocity";

        private PKFxFX _pkfxFx;
        public float Speed = 10;

        void Awake()
        {
            _pkfxFx = GetComponent<PKFxFX>();
        }

        public void SetPositonToTarget(Vector3 targetPosition)
        {
            Vector3 directionToTarget = (targetPosition - transform.position).normalized;
            directionToTarget *= Speed;
            _pkfxFx.SetAttribute(new PKFxManager.Attribute(AttributeName, directionToTarget));
        }
    }
}