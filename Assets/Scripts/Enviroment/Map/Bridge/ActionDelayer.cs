using System;
using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Bridge
{
    public class ActionDelayer : MonoBehaviour
    {
        public float MaxDelay;
        public float MinDelay;

        public void Delay(Action delayAction)
        {
            Timer.Start(gameObject, UnityEngine.Random.Range(MinDelay, MaxDelay), delayAction);
        }
    }
}