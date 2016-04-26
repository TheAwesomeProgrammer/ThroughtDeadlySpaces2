using UnityEngine;

namespace Assets.Scripts.Quest.Rewards.Spawner
{
    public class CircleOffsetCalculator
    {
        private const int DegreesInACircle = 360;
        private const int DegreesPerOffset = 60;
        private const float OffsetsPerCircle = DegreesInACircle / (float)DegreesPerOffset;

        private int _currentOffsetNumber = 0;
        private int _currentCircleNumber = 1;
        private float _currentDegress = 0;

        public void Reset()
        {
            _currentDegress = 0;
            _currentCircleNumber = 1;
            _currentOffsetNumber = 0;
        }

        public Vector3 GetOffset(Collider collider)
        {
            Vector3 offset = Vector3.zero;

            ShouldReachEndOfCircle();
            offset = _currentDegress.GetDirectionBasedOnAngleXz() * collider.bounds.size.magnitude * _currentCircleNumber;

            MoveToNextOffset();

            return offset;
        }

        void MoveToNextOffset()
        {
            _currentOffsetNumber++;
            _currentDegress += DegreesPerOffset;
        }

        void ShouldReachEndOfCircle()
        {
            if (HasReachedEndOfCircle())
            {
                ReachedEndOfCircle();
            }
        }

        private bool HasReachedEndOfCircle()
        {
            return _currentOffsetNumber >= OffsetsPerCircle;
        }

        private void ReachedEndOfCircle()
        {
            _currentOffsetNumber = 0;
            _currentCircleNumber++;
        }
    }
}