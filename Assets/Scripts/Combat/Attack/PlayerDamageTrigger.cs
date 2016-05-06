using System.Collections.Generic;
using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Combat.Defense.Boss;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    public class PlayerDamageTrigger : DamageTrigger
    {
        protected override void Start()
        {
            base.Start();
            Tags.Add("Enemy");
        }
    }
}