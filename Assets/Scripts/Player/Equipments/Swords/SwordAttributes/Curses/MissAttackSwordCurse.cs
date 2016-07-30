using Assets.Scripts.Extensions.Math;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Swords;
using Assets.Scripts.Shop;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Player.Swords.Curses
{
    [EquipmentAttributeMetaData(EquipmentType.Sword, EquipmentAttributeType.Curse)]
    public class MissAttackSwordCurse : MonoBehaviour, XmlAttributeLoadable
    {
        private int MissChange = 10;
        private const int CurseId = 4;

        private SwordAttack _swordAttack;
        private EquipmentAttributeLoader _equipmentAttributeLoader;

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

        public void LoadXml(int level)
        {
            _equipmentAttributeLoader = new EquipmentAttributeLoader(XmlFileLocations.GetLocation(Location.Curse));
            int[] specs = _equipmentAttributeLoader.LoadSpecs(CurseId, level, XmlName.Curses);
            MissChange = specs[0];
        }
    }
}