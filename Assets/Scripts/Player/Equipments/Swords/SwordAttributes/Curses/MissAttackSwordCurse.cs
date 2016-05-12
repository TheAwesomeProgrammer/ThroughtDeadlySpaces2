using Assets.Scripts.Extensions.Math;
using UnityEngine;

namespace Assets.Scripts.Player.Swords.Curses
{
    public class MissAttackSwordCurse : MonoBehaviour
    {
        private int MissChange = 10;

        private SwordAttack _swordAttack;

        void Start()
        {
            _swordAttack = GetComponent<SwordAttack>();
            _swordAttack.AttackStarted += OnAttackStarted;
        }

        void OnAttackStarted()
        {
            if (MathHelper.IsBetweenRandomProcentFrom0To100(MissChange))
            {
                _swordAttack.EndAttack();
            }
        }
    }
}