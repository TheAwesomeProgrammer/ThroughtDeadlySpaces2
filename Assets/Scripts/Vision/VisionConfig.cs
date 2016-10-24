using System;
using UnityEngine;

namespace Assets.Scripts.Vision
{
    [Serializable]
    public class VisionConfig
    {
        public int LayerMask { get; set; }

        public string TargetTag;
        public float Distance;
        public LayerMask LayersToHit;
        public QueryTriggerInteraction QueryTriggerInteraction;

        public int GetLayerMask()
        {
            return LayerMask != 0 ? LayerMask : LayersToHit.value;
        }

        public VisionConfig(string targetTag, float distance = Mathf.Infinity, int layerMask = 0, bool triggersBlockVision = false)
        {
            TargetTag = targetTag;
            Distance = distance;
            LayerMask = layerMask;
            QueryTriggerInteraction = triggersBlockVision
                ? QueryTriggerInteraction.Ignore
                : QueryTriggerInteraction.Collide;
        }
    }
}