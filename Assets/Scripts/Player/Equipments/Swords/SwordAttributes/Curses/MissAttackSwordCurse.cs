using Assets.Scripts.Extensions.Math;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Swords;
using Assets.Scripts.Shop;
using UnityEngine;

namespace Assets.Scripts.Player.Swords.Curses
{
    [EquipmentAttributeMetaData(EquipmentType.Sword, EquipmentAttributeType.Curse)]
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