using System;
using System.Xml;
using XmlLibrary;

namespace Assets.Scripts.Player.Swords
{
    public class EquipmentAttributeLoader
    {
        private const string AttributeName = "name";

        private XmlLocation _xmlLocation;

        public EquipmentAttributeLoader(XmlLocation xmlLocation)
        {
            _xmlLocation = xmlLocation;
        }

        public string GetName(int xmlId, string attributeName = AttributeName)
        {
            XmlPath xmlPath = new DefaultXmlPath(_xmlLocation, new XmlPathData(xmlId));
            return xmlPath.GetAttributeText(attributeName);
        }

        public int[] LoadSpecs(int xmlId, int level)
        {
            return Array.ConvertAll(LoadSpecsFloat(xmlId, level), item => (int) item);
        }

        private XmlNode GetSpecsNode(int xmlId, int level)
        {
            XmlPath xmlPath = new DefaultXmlPath(_xmlLocation, new XmlPathData(xmlId),
                new XmlPathData(level, XmlName.AttributeLevelName));
            XmlPathData xmlPathData = xmlPath.GetDefaultPathData();
            return xmlPathData.GetDefaultPathNode();
        }

        public float[] LoadSpecsFloat(int xmlId, int level)
        {
            XmlPath specsPath = new DefaultXmlPath(_xmlLocation, new XmlPathData(xmlId),
                new XmlPathData(XmlName.SpecNodeName),
                new XmlPathData(level, XmlName.AttributeLevelName));
            return specsPath.GetSpecsFloat();
        }
    }
}