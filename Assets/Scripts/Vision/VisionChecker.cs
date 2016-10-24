using UnityEngine;

namespace Assets.Scripts.Vision
{
    public class VisionChecker
    {
        public bool CanSee(Vector3 from, Vector3 to, VisionConfig visionConfig)
        {
            return CanSeeCheck(from, GetDirection(from, to), visionConfig);
        }

        private Vector3 GetDirection(Vector3 from, Vector3 to)
        {
            return (to - from).normalized;
        }

        private bool CanSeeCheck(Vector3 origin, Vector3 direction, VisionConfig visionConfig)
        {
            Debug.DrawRay(origin, direction * visionConfig.Distance, Color.red, 10);

            RaycastHit raycastHit;
            if (Physics.Raycast(new Ray(origin, direction), out raycastHit, visionConfig.Distance,
                visionConfig.GetLayerMask(),
                visionConfig.QueryTriggerInteraction))
            {
                Transform raycastTransform = raycastHit.transform;
                if (raycastTransform.tag == visionConfig.TargetTag)

                {
                    return true;
                }
            }

            return false;
        }
    }
}