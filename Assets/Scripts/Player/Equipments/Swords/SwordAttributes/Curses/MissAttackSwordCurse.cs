using Assets.Scripts.Extensions.Math;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Swords;
using Assets.Scripts.Shop;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Player.Swords.Curses
{
    [EquipmentAttributeMetaData(EquipmentType.Sword, EquipmentAttributeType.Curse)]
    public class MissAttackSwordCurse : EquipmentAttribute, XmlAttributeLoadable
    {
        private int MissChange = 10;
        private const int CurseId = 4;

        private SwordAttack _swordAttack;
        private EquipmentAttributeLoader _equipmentAttributeLoader;

        public override void Init()
        {
            base.Init();
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

        public void LoadXml(int level)
        {
            int[] specs = LoadSpecs(XmlFileLocations.GetLocation(Location.Curse), CurseId, level, XmlName.Curses);
            MissChange = specs[0];
        }
    }
}