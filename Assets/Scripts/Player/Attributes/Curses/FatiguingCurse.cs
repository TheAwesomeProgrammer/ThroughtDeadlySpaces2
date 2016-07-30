using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Shop;
using Assets.Scripts.Xml;

namespace Assets.Scripts.Player.Curses
{
    [EquipmentAttributeMetaData(EquipmentType.Sword, EquipmentAttributeType.Curse)]
    public class FatiguingCurse : EquipmentAttribute, XmlAttributeLoadable
    {
        private PlayerProperties _playerProperties;
        private float _slowAmount;
        private int _dexteritySteal;

        public override void Init()
        {
            _playerProperties = GetComponentInParent<PlayerProperties>();
            _attributeId = 5;
        }

        protected override void Activate()
        {
            ChangePlayerProperties(_playerProperties.MaxDexterity - _dexteritySteal, _playerProperties.Speed - _slowAmount);
        }

        protected override void Deactivate()
        {
            base.Deactivate();
            ChangePlayerProperties(_playerProperties.MaxDexterity + _dexteritySteal, _playerProperties.Speed + _slowAmount);
        }

        private void ChangePlayerProperties(float newDexterityValue, float newSpeed)
        {
            _playerProperties.SetSpeed(newDexterityValue);
            _playerProperties.SetMaxDexterity(newSpeed);
        }

        public void LoadXml(int level)
        {
            int[] specs = LoadSpecs(XmlFileLocations.GetLocation(Location.Curse), _attributeId, level, XmlName.Curses);
            _slowAmount = specs[0];
            _dexteritySteal = specs[1];
        }
    }
}