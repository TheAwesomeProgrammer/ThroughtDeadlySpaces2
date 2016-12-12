using System;
using UnityEngine;

namespace Assets.Scripts.Enemy.Attacks.Abstract
{
    [Serializable]
    public abstract class CombatStats
    {
        public abstract bool IsInRange(Vector3 from);
    }
}