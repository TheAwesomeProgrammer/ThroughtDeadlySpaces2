using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Enemy.Attacks.Abstract;
using Assets.Scripts.Extensions;
using Assets.Scripts.Player.Swords;
using UnityEngine;

namespace Assets.Scripts.Enemy.Attacks
{
    public class RandomAttackSet : CombatSet<AttackStats>
    {
        protected override CombatActor<AttackStats> FindCombat()
        {
            return _combats.Random();
        }
    }
}