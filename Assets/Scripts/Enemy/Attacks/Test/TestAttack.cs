using UnityEngine;

namespace Assets.Scripts.Enemy.Attacks.Test
{
    public class TestAttack : MonoBehaviour, Attackable
    {
        public string AttackMessage;

        public void DoAttack()
        {
            Debug.Log(AttackMessage);
        }
    }
}