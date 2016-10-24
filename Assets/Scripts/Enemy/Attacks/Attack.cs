using Assets.Scripts.Player.Swords;
using Assets.Scripts.Tests;
using UnityEngine;

namespace Assets.Scripts.Enemy.Attacks
{
    public class Attack : MonoBehaviour, Attackable
    {
        private AnimatorTrigger _animatorTrigger;

        private void Start()
        {
            _animatorTrigger = GetComponent<AnimatorTrigger>();
            NullAsserter.Assert(_animatorTrigger, "AnimatorTrigger");
        }

        public void DoAttack()
        {
            _animatorTrigger.StartAnimation(AnimatorRunMode.AlwaysRun);
        }
    }
}