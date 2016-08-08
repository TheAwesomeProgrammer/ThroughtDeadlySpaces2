using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Equipments.Attributes;
using Assets.Scripts.Shop;
using Assets.Scripts.Xml;

namespace Assets.Scripts.Player.Curses
{
    [EquipmentAttributeMetaData(EquipmentType.Sword, EquipmentAttributeType.Curse)]
    public class FatiguingCurse : EquipmentAttribute, XmlAttributeLoadable
    {
        private PlayerProperties _playerProperties;
        private PlayerPropertiesSetter _speedSetter;
        private float _slowAmount;
        private int _dexteritySteal;

        public override AttributeXmlData AttributeXmlData
        {
            get
            {
                return _attributeXmlData = _attributeXmlData ??
                                            new AttributeXmlData(XmlFileLocations.GetLocation(Location.Curse), _attributeId,
                                                XmlName.Curses);
            }
        }

        public override void Init()
        {
            _playerProperties = GetComponentInParent<PlayerProperties>();
            _speedSetter = _playerProperties.SpeedSetter;
            _attributeId = 5;
        }

        protected override void Activate()
        {
            ChangePlayerProperties(_playerProperties.MaxDexterity - _dexteritySteal);
            _speedSetter.Add(new SetData(_slowAmount, _attributeId));
        }

        protected override void Deactivate()
        {
            base.Deactivate();
            _speedSetter.Remove(_attributeId);
            ChangePlayerProperties(_playerProperties.MaxDexterity + _dexteritySteal);
        }

        private void ChangePlayerProperties(float newDexterityValue)
        {
            _playerProperties.MaxDexterity = newDexterityValue;
        }

        public void LoadXml(int level)
        {
            int[] specs = LoadSpecs(level);
            _slowAmount = specs[0];
            _dexteritySteal = specs[1];
        }
    }
}