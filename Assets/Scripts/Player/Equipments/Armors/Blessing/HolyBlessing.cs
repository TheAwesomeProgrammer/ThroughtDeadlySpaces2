using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Equipments.Attributes;
using Assets.Scripts.Player.Swords;
using Assets.Scripts.Player.Swords.Abstract;
using Assets.Scripts.Shop;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Player.Armors.Blessing
{
    [EquipmentAttributeMetaData(EquipmentType.Armor, EquipmentAttributeType.Blessing)]
    public class HolyBlessing : EquipmentAttribute, XmlAttributeLoadable
    {
        private DexterityFiller _dexterityFiller;
        private float _interval;
        private float _dexterityPerInterval;

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
            _attributeId = 8;
            _dexterityFiller = GameObject.FindGameObjectWithTag(Tag.Player).GetComponentInChildren<DexterityFiller>();
        }

        public void LoadXml(int level)
        {
            int[] specs = LoadSpecs(level);
            _interval = specs[0];
            _dexterityPerInterval = specs[1];
        }

        protected override void Activate()
        {
            Timer.Start(gameObject, _interval, AddDexterity);
        }

        private void AddDexterity()
        {
            if (enabled)
            {
                Timer.Start(gameObject, _interval, AddDexterity);
                _dexterityFiller.Dexterity += _dexterityPerInterval;
            }
        }
    }
}