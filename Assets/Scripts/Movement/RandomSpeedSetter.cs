using Assets.Scripts.Movement;
using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Bridge
{
    public class RandomSpeedSetter : MonoBehaviour
    {
        public float MaxSpeed = 8;
        public float MinSpeed = 3;
        public bool AutoSetSpeed = true;

        private SpeedSetable _speedSetable;

        public void Start()
        {
            _speedSetable = GetComponent<SpeedSetable>();
            if (AutoSetSpeed)
            {
                SetSpeed();
            }
        }

        public void SetSpeed()
        {
            _speedSetable.SetSpeed(Random.Range(MinSpeed, MaxSpeed));
        }

    }
}