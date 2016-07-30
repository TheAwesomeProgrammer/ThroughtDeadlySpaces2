using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player.Swords.Abstract.Bosses.Attack
{
    public class BossDamageTrigger : DamageTrigger
    {
        protected override void Start()
        {
            base.Start();
            Tags.Clear();
            Tags.Add(Tag.PlayerCollision);
            _enemyAttackers = new List<CombatDamage>();
        }
    }
}