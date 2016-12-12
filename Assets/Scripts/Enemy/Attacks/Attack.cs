using Assets.Scripts.Enemy.Attacks.Abstract;
using Assets.Scripts.Player.Swords;
using Assets.Scripts.Tests;
using UnityEngine;

namespace Assets.Scripts.Enemy.Attacks
{
    public class Attack : CombatActor<AttackStats>
    {
        private void OnDrawGizmos()
        {
            CombatStats.DrawGizmos(transform.position);
        }
    }
}