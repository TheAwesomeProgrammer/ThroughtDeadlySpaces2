using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Shop;
using Assets.Scripts.Xml;

namespace Assets.Scripts.Player.Curses
{
    [EquipmentAttributeMetaData(EquipmentType.SwordOrArmor, EquipmentAttributeType.Blessing)]
    public class SwiftBlessing : EquipmentAttribute, XmlAttributeLoadable
    {
        private PlayerProperties _playerProperties;
        private float _extraAttackSpeed;

       public override void Init()
        {
            _playerProperties = GetComponentInParent<PlayerProperties>();
            _attributeId = 6;
        }

        public void LoadXml(int level)
        {
            _extraAttackSpeed =
                LoadSpecs(XmlFileLocations.GetLocation(Location.Blessing), _attributeId, level, XmlName.Blessing)[0];
        }

        protected override void Activate()
        {
            _playerProperties.SetAttackSpeed(_playerProperties.AttackSpeed - _extraAttackSpeed);
        }

        protected override void Deactivate()
        {
            _playerProperties.SetAttackSpeed(_playerProperties.AttackSpeed + _extraAttackSpeed);
        }
    }
}