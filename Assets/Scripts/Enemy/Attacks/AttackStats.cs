using System;
using Assets.Scripts.Enemy.Attacks.Abstract;
using UnityEngine;

namespace Assets.Scripts.Enemy.Attacks
{
    [Serializable]
    public class AttackStats : CombatStats
    {
        public float AttackSpeed;
        public RangeCheck AttackRange;

        public override bool IsInRange(Vector3 from)
        {
            return AttackRange.IsTargetInsideRange(from);
        }

        public void DrawGizmos(Vector3 from)
        {
            AttackRange.DrawGizmos(from);
        }
    }
}