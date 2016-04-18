using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Player.Swords.Curses
{
    public class HeavySwordCurse : SwordComponent
    {
        public int SpeedToLose = 2;

        private PlayerProperties _playerProperties;
        private float _startSpeed;
        private XmlSearcher _xmlSearcher;

        protected override void Start()
        {
            _playerProperties = GetComponent<PlayerProperties>();
            Activate();
        }

        public void LoadSpecs()
        {
            _xmlSearcher = new XmlSearcher(XmlFileLocations.GetLocation(Location.Curse));
            SpeedToLose = _xmlSearcher.GetSpecsWithId(1, "Curses")[0];
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