using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Player.Movement;
using UnityEngine;

namespace Assets.Scripts.Enemy.AI.Abstact
{
    public interface AiMoveable : Moveable
    {
        void MoveTo(Transform target);
        void MoveTo(Vector3 targetPosition);
    }
}
