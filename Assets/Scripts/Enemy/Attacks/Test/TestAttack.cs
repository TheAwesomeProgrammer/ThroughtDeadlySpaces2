using Assets.Scripts.Enemy.Attacks.Abstract;
using UnityEngine;

namespace Assets.Scripts.Enemy.Attacks.Test
{
    public class TestAttack : CombatActor<AttackStats>
    {
        public string AttackMessage;

        public override void DoAttack()
        {
            Debug.Log(AttackMessage);
        }
    }
}