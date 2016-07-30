using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Shop;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Player.Swords.Curses
{
    [EquipmentAttributeMetaData(EquipmentType.Sword, EquipmentAttributeType.Curse)]
    public class HeavySwordCurse : SwordComponent, XmlAttributeLoadable
    {
        public int SpeedToLose = 2;
        private const int CurseId = 1;

        private PlayerProperties _playerProperties;
        private float _startSpeed;
        private EquipmentAttributeLoader _equipmentAttributeLoader;

        protected override void Start()
        {
            _playerProperties = GetComponentInParent<PlayerProperties>();
            Activate();
        }

        public void LoadXml(int level)
        {
            _equipmentAttributeLoader = new EquipmentAttributeLoader(XmlFileLocations.GetLocation(Location.Curse));
            int[] specs = _equipmentAttributeLoader.LoadSpecs(CurseId, level, XmlName.Curses);
            SpeedToLose = specs[0];
        }

        void Activate()
        {
            _startSpeed = _playerProperties.Speed;
            _playerProperties.Speed -= SpeedToLose;
        }

        void Deactivate()
        {
            _playerProperties.Speed = _startSpeed;
        }

        void OnDestroy()
        {
            Deactivate();
        }
    }
}