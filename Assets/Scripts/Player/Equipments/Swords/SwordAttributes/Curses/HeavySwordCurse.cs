using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Equipments.Attributes;
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

        private PlayerPropertiesSetter _speedSetter;

        public override AttributeXmlData AttributeXmlData
        {
            get
            {
                return _attributeXmlData = _attributeXmlData ??
                                            new AttributeXmlData(XmlFileLocations.GetLocation(Location.Curse), CurseId,
                                                XmlName.Curses);
            }
        }

        public override void Init()
        {
            base.Init();
            _speedSetter = GetComponentInParent<PlayerProperties>().SpeedSetter;
        }

        public void LoadXml(int level)
        {
            int[] specs = LoadSpecs(level);
            SpeedToLose = specs[0];
        }

        protected override void Activate()
        {
            base.Activate();
            _speedSetter.Add(new SetData(CurseId, SpeedToLose));
        }

        protected override void Deactivate()
        {
            base.Activate();
            _speedSetter.Remove(CurseId);
        }
    }
}