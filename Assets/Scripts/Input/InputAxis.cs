using System;
using TeamUtility.IO;
using UnityEngine;

namespace Assets.Scripts.Input
{
    public class InputAxis : MonoBehaviour
    {
        public string[] AxisNames;

        public event Action<float> AxisMoving;

        void Update()
        {
            foreach (var axisName in AxisNames)
            {
                CheckAxis(axisName);
            }
        }

        private void CheckAxis(string axisName)
        {
            float axisMovement = InputManager.GetAxis(axisName);
            if (AxisMoving != null && Mathf.Abs(axisMovement) > 0)
            {
                AxisMoving(axisMovement);
            }
        }
    }
}