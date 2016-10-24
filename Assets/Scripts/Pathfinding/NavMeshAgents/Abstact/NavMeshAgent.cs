using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Enemy.AI.Abstact;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts.Pathfinding
{
    public interface NavMeshAgent : AiMoveable
    {
        Transform Target { get; }
        NavMeshAgentConfig Config { get; set; }
        event EventHandler ReachedTarget; 

        void Reset();
        void ResetPath();
    }
}