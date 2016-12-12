using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Enemy.Attacks.Abstract
{
    public abstract class CombatSet<TCombatStatsType> : MonoBehaviour where TCombatStatsType : CombatStats
    {
        protected List<CombatActor<TCombatStatsType>> _combats;

        protected virtual void Awake()
        {
            _combats = GetComponentsInChildren<CombatActor<TCombatStatsType>>().ToList();
        }

        public CombatActor<TCombatStatsType> GetCombat()
        {
            return FindCombat();
        }

        protected abstract CombatActor<TCombatStatsType> FindCombat();
    }
}
