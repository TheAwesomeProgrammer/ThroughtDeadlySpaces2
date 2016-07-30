using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Swords;
using Assets.Scripts.Shop;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Player.Curses
{
    [EquipmentAttributeMetaData(EquipmentType.SwordOrArmor, EquipmentAttributeType.Blessing)]
    public class LightBlessing : EquipmentAttribute, XmlAttributeLoadable
    {
        private PlayerProperties _playerProperties;
        private float _extraSpeed;
        private float _startSpeed;

        public override void Init()
        {
            _playerProperties = GetComponentInParent<PlayerProperties>();
            _attributeId = 7;
        }

        public void LoadXml(int level)
        {
            _extraSpeed = LoadSpecs(XmlFileLocations.GetLocation(Location.Blessing), _attributeId, level, XmlName.Blessing)[0];
        }

        protected override void Activate()
        {
            _startSpeed = _playerProperties.Speed;
            _playerProperties.SetSpeed(_startSpeed + _extraSpeed);
        }

        protected override void Deactivate()
        {
            base.Deactivate();
            _playerProperties.SetSpeed(_startSpeed);
        }
    }
}