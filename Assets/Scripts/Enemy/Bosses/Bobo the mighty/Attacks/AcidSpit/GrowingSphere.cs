using UnityEngine;

namespace Assets.Scripts.Bosses.Bobo_the_mighty.Attacks.AcidSpit
{
    public class GrowingSphere : MonoBehaviour
    {
        public const float GrowRate = 3;
        public const float MaxRadius = 4;

        private SphereCollider _sphereCollider;

        private void Start()
        {
            _sphereCollider = GetComponent<SphereCollider>();
        }

        private void Update()
        {
            if (_sphereCollider.radius < MaxRadius)
            {
                _sphereCollider.radius += GrowRate * Time.deltaTime;
            }
        }
    }
}