using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player.Swords.Abstract.Bosses.Attack
{
    public class BossDamageTrigger : PlayerDamageTrigger
    {
        protected override void Start()
        {
            base.Start();
            Tags.Clear();
            Tags.Add("Player");
            _enemyAttackers = new List<CombatAttacker>();
        }
    }
}