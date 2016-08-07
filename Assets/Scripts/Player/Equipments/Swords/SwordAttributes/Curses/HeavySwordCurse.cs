using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Shop;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Player.Swords.Curses
{
    [EquipmentAttributeMetaData(EquipmentType.Sword, EquipmentAttributeType.Curse)]
    public class HeavySwordCurse : EquipmentAttribute, XmlAttributeLoadable
    {
        public int SpeedToLose = 2;
        private const int CurseId = 1;

        private PlayerProperties _playerProperties;
        private float _startSpeed;
        private EquipmentAttributeLoader _equipmentAttributeLoader;

        public override void Init()
        {
            base.Init();
            _playerProperties = GetComponentInParent<PlayerProperties>();
        }

        public void LoadXml(int level)
        {
            int[] specs = LoadSpecs(XmlFileLocations.GetLocation(Location.Curse), CurseId, level, XmlName.Curses);
            SpeedToLose = specs[0];
        }

        protected override void Activate()
        {
            base.Activate();
            _startSpeed = _playerProperties.Speed;
            _playerProperties.Speed -= SpeedToLose;
        }

        protected override void Deactivate()
        {
            base.Activate();
            _playerProperties.Speed = _startSpeed;
        }
    }
}