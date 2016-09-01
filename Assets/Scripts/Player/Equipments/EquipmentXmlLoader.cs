using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;
using Assets.Scripts.Combat;
using Assets.Scripts.Player.Attributes;
using Assets.Scripts.Player.Swords;
using Assets.Scripts.Player.Swords.Abstract;
using XmlLibrary;
using UnityEngine;
using Attribute = Assets.Scripts.Player.Attributes.Attribute;

namespace Assets.Scripts.Player.Equipments
{
	public class AttributeLoaderData<T>
	{
		public T AttributeType;
		public int Level;

		public AttributeLoaderData(int level, T attributeType)
		{
			Level = level;
			AttributeType = attributeType;
		}
	}

    public class EquipmentXmlLoader : XmlLoadable
    {
        public int XmlId;
        public string XmlRaritySpecNodeName = "Type";
        public XmlLocation XmlLocation;

        public EquipmentSpecs EquipmentSpecs
        {
            get
            {
                return _equipmentSpecs;
            }
        }

        protected EnumConverter _enumConverter;
        protected XmlPath _equipmentXmlPath;
        protected XmlPath _rarityPath;
        protected AttributeAdder _attributeAdder;
        protected EquipmentSpecs _equipmentSpecs;
        protected EquipmentAttributeManager _equipmentAttributeManager;

        private int[] _specs;
        private int _rarity;

        public EquipmentXmlLoader(EquipmentAttributeManager equipmentAttributeManager, int xmlId,
            int equipmentId)
        {
            XmlId = xmlId;
            _equipmentAttributeManager = equipmentAttributeManager;
            _enumConverter = new EnumConverter();
            
        }

        public virtual void Load()
        {
            LoadXml();
            AddAttributes<Attribute>();
        }

        public void LoadXml()
        {
             _equipmentXmlPath = new DefaultXmlPath(XmlLocation, new XmlPathData(XmlId));
            XmlPath equipmentSpecsXmlPath = new SpecXmlPath(_equipmentXmlPath);
            _specs = equipmentSpecsXmlPath.GetSpecs();
            XmlPath equipmentRarityPath = new DefaultXmlPath(_equipmentXmlPath, new XmlPathData(XmlRaritySpecNodeName));
            _rarity = equipmentRarityPath.GetSpecs()[0];
            _equipmentSpecs = new EquipmentSpecs(_specs[0], _specs[1], _specs[2], _specs[3], _specs[4], (EquipmentRarity) _rarity);
        }

        protected void AddAttributes<T>() where T : IConvertible
        {
            List<AttributeLoaderData<T>> attributeLoaderDatas = LoadAttributeDatas<T>();

	        foreach (AttributeLoaderData<T> attributeLoaderData in attributeLoaderDatas)
            {
                _attributeAdder.AddAttribute((Enum)(object) attributeLoaderData.AttributeType, attributeLoaderData.Level);
            }
        }

	    private List<AttributeLoaderData<T>> LoadAttributeDatas<T>() where T : IConvertible
	    {
		    List<AttributeLoaderData<T>> attributeLoaderDatas = new List<AttributeLoaderData<T>>();

            XmlPath equipmentAttributePath = new DefaultXmlPath(_equipmentXmlPath, new XmlPathData(XmlName.AttributeNodeName));

		    foreach (var attributeText in equipmentAttributePath.GetEquipmentAttributesInNode())
		    {
			    int attributeLevel = GetLevelInAttribute(attributeText);
			    Result<T> attributeTypeResult = _enumConverter.Convert<T>(GetAttributeTextWithoutLevel(attributeText, attributeLevel));
			    if (attributeTypeResult.Succes)
			    {
				    attributeLoaderDatas.Add(new AttributeLoaderData<T>(attributeLevel, attributeTypeResult.Value));
			    }
		    }

		    return attributeLoaderDatas;
	    }

	    private int GetLevelInAttribute(string attributeText)
	    {
		    int level = 1;

		    Match numberMatch = Regex.Match(attributeText, @"\d+");

		    if (numberMatch.Success)
		    {
			    int.TryParse(numberMatch.Value, out level);
		    }

		    return level;
	    }

	    private string GetAttributeTextWithoutLevel(string attributeText, int level)
	    {
		    return attributeText.Replace(level.ToString(), "");
	    }
    }
}