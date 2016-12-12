using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Assets.Scripts.Extensions;
using Assets.Scripts.Player.Swords.Abstract.Movement;
using UnityEngine;


namespace Assets.Scripts.Enemy.Attacks.Abstract
{
    public abstract class CombatActor<TCombatStatsType> : MonoBehaviour where TCombatStatsType : CombatStats
    {
        public TCombatStatsType CombatStats;

        private AbillityTiming _abillityTiming;

        public bool IsInRangeToAttack
        {
            get { return CombatStats.IsInRange(transform.position); }
        }

        protected virtual void Start()
        {
            _abillityTiming = GetComponent<AbillityTiming>();
        }

        public virtual void DoAttack()
        {
            _abillityTiming.UseAbillity();
        }
    }
}