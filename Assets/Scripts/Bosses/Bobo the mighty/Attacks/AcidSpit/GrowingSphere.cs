using UnityEngine;

namespace Assets.Scripts.Bosses.Bobo_the_mighty.Attacks.AcidSpit
{
    public class GrowingSphere : MonoBehaviour
    {
        public float GrowRate;

        private SphereCollider _sphereCollider;

        private void Start()
        {
            _sphereCollider = GetComponent<SphereCollider>();
        }

        private void Update()
        {
            _sphereCollider.radius += GrowRate * Time.deltaTime;
        }
    }
}