using UnityEngine;

namespace Assets.Scripts.Enemy.Attacks.Abstract
{
    [System.Serializable]
    public class RangeCheck
    {
        public float Range;
        public TargetData TargetData;

        public bool IsTargetInsideRange(Vector3 from)
        {
            float distanceToTarget = 0;
            Vector3 targetPosition = TargetData.GetTargetPosition();
            distanceToTarget = Mathf.Abs(Vector3.Distance(from, targetPosition));
            return distanceToTarget <= Range;
        }

        public void DrawGizmos(Vector3 from)
        {
            Gizmos.DrawWireSphere(from, Range);
        }
    }
}