using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Equipments.Attributes;
using Assets.Scripts.Player.Swords;
using Assets.Scripts.Shop;
using XmlLibrary;
using UnityEngine;

namespace Assets.Scripts.Player.Curses
{
    [EquipmentAttributeMetaData(EquipmentType.SwordOrArmor, EquipmentAttributeType.Blessing)]
    public class LightBlessing : EquipmentAttribute, XmlAttributeLoadable
    {
        private PlayerPropertiesSetter _speedSetter;
        private float _extraSpeed;

        public override AttributeXmlData AttributeXmlData
        {
            get
            {
                return _attributeXmlData = _attributeXmlData ??
                                            new AttributeXmlData(XmlLocation.Blessing, _attributeId);
            }
        }

        public override void Init()
        {
            base.Init();
            _speedSetter = GetComponentInParent<PlayerProperties>().SpeedSetter;
            _attributeId = 7;
        }

        public void LoadXml(int level)
        {
            _extraSpeed = LoadSpecs(level)[0];
        }

        protected override void Activate()
        {
            _speedSetter.Add(new SetData(_extraSpeed, _attributeId));
        }

        protected override void Deactivate()
        {
            base.Deactivate();
            _speedSetter.Remove(_attributeId);
        }
    }
}