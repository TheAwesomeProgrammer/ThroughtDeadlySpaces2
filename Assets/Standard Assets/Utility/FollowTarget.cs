using System;
using UnityEngine;


namespace UnityStandardAssets.Utility
{
    public class FollowTarget : MonoBehaviour
    {
        public Transform target;
        public Vector3 offset = new Vector3(0f, 7.5f, 0f);
        public float SmoothTime = 0.1f;

        private Vector3 velocity = Vector3.zero;

        private void LateUpdate()
        {
            transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref velocity,
                SmoothTime);
        }
    }
}
