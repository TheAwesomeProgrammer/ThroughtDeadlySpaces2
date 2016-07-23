using System;
using System.Xml;
using Assets.Scripts.Combat;
using Assets.Scripts.Player.Swords;
using Assets.Scripts.Player.Swords.Abstract;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Player.Equipments
{
    public class EquipmentXmlLoader : XmlLoadable
    {
        public int XmlId;
        public string XmlArrayName;
        public string XmlRaritySpecNodeName = "Type";
        public Location XmlLocation;

        public EquipmentSpecs EquipmentSpecs
        {
            get
            {
                return _equipmentSpecs;
            }
        }

        protected EnumConverter _enumConverter;
        protected XmlSearcher _xmlSearcher;
        protected AttributeAdder _attributeAdder;
        protected EquipmentSpecs _equipmentSpecs;
        protected EquipmentAttributeManager _equipmentAttributeManager;

        private int[] _specs;
        private int _rarity;

        public EquipmentXmlLoader(EquipmentAttributeManager equipmentAttributeManager, int xmlId, string xmlArrayName)
        {
            XmlId = xmlId;
            XmlArrayName = xmlArrayName;
            _equipmentAttributeManager = equipmentAttributeManager;
            _enumConverter = new EnumConverter();
        }

        public virtual void Load()
        {
            LoadXml();
        }

        public void LoadXml()
        {
            _xmlSearcher = new XmlSearcher(XmlLocation);
            _specs = _xmlSearcher.GetSpecsInChildrenWithId(XmlId, XmlArrayName);
            _rarity = _xmlSearcher.GetSpecsInChildrenWithId(XmlId, XmlArrayName, XmlRaritySpecNodeName)[0];
            _equipmentSpecs = new EquipmentSpecs(_specs[0], _specs[1], _specs[2], _specs[3], _specs[4], (EquipmentRarity) _rarity);
        }

        protected void AddAttributes<T>() where T : IConvertible
        {
            XmlNode swordNode = _xmlSearcher.GetNodeInArrayWithId(XmlId, XmlArrayName);

            T[] attributes = _enumConverter.Convert<T>(_xmlSearcher.GetAttributesInNode(swordNode));

            foreach (T attribute in attributes)
            {
                _attributeAdder.AddAttribute((Enum)(object)attribute);
            }
        }
    }
}