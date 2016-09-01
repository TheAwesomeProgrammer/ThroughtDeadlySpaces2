using Assets.Scripts.Extensions.Math;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Equipments.Attributes;
using Assets.Scripts.Player.Swords;
using Assets.Scripts.Shop;
using XmlLibrary;
using UnityEngine;

namespace Assets.Scripts.Player.Armors.Curses
{
    [EquipmentAttributeMetaData(EquipmentType.Armor, EquipmentAttributeType.Curse)]
    public class ArmorRustyCurse : EquipmentAttribute, XmlAttributeLoadable
    {
        private const int CurseId = 3;

        private Resistance _resistance;
        private int _procentChanceToBreak;

        public override AttributeXmlData AttributeXmlData
        {
            get
            {
                return _attributeXmlData = _attributeXmlData ??
                                            new AttributeXmlData(XmlLocation.Curse, CurseId);
            }
        }

        public override void Init()
        {
            base.Init();
            _resistance = GetComponent<Resistance>();
            _resistance.Defending += OnDefending;
        }

        void OnDefending()
        {
            if (MathHelper.IsBetweenRandomProcentFrom0To100(_procentChanceToBreak))
            {
                gameObject.AddComponentIfNotExist<ArmorBrokenCurse>();
                Destroy(this);
            }
        }

        public void LoadXml(int level)
        {
            int[] specs = LoadSpecs(level);
            _procentChanceToBreak = specs[0];
        }
    }
}