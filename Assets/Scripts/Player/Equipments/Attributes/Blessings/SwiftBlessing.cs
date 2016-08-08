using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Equipments.Attributes;
using Assets.Scripts.Shop;
using Assets.Scripts.Xml;

namespace Assets.Scripts.Player.Curses
{
    [EquipmentAttributeMetaData(EquipmentType.SwordOrArmor, EquipmentAttributeType.Blessing)]
    public class SwiftBlessing : EquipmentAttribute, XmlAttributeLoadable
    {
        private PlayerPropertiesSetter _attackSpeedSetter;
        private float _extraAttackSpeed;

        public override AttributeXmlData AttributeXmlData
        {
            get
            {
                return _attributeXmlData = _attributeXmlData ??
                                            new AttributeXmlData(XmlFileLocations.GetLocation(Location.Blessing), _attributeId,
                                                XmlName.Blessing);
            }
        }

        public override void Init()
        {
            base.Init();
            _attackSpeedSetter = GetComponentInParent<PlayerProperties>().AttackSpeedSetter;
            _attributeId = 6;
        }

        public void LoadXml(int level)
        {
            _extraAttackSpeed =
                LoadSpecs(level)[0];
        }

        protected override void Activate()
        {
            _attackSpeedSetter.Add(new SetData(_extraAttackSpeed, _attributeId));
        }

        protected override void Deactivate()
        {
            _attackSpeedSetter.Remove(_attributeId);
        }
    }
}