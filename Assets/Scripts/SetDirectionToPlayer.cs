using UnityEngine;

namespace Assets.Scripts
{
    public class SetDirectionToPlayer : MonoBehaviour
    {
        private PKFxFX _pkfxFx;
        public float Speed = 10;

        void Start()
        {
            _pkfxFx = GetComponent<PKFxFX>();
            Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;
            directionToPlayer *= Speed;
            _pkfxFx.SetAttribute(new PKFxManager.Attribute("aVelocity", directionToPlayer));
        }
    }
}