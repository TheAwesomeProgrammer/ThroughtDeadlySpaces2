using System.Xml;
using Assets.Scripts.Xml;

namespace Assets.Scripts.Player.Swords
{
    public class EquipmentAttributeLoader
    {
        private const string AttributeName = "name";

        private XmlSearcher _xmlSearcher;

        public EquipmentAttributeLoader(string xmlDocumentLocation)
        {
            _xmlSearcher = new XmlSearcher(xmlDocumentLocation);
        }

        public string GetName(int xmlId,string rootXmlNodeName, string attributeName = AttributeName)
        {
           return _xmlSearcher.GetAttributeText(_xmlSearcher.GetNodeInArrayWithId(xmlId, rootXmlNodeName), attributeName);
        }

        public int[] LoadSpecs(int xmlId, int level, string xmlArrayName)
        {
            return _xmlSearcher.GetSpecs(GetSpecsNode(xmlId, level, xmlArrayName));
        }

        private XmlNode GetSpecsNode(int xmlId, int level, string xmlArrayName)
        {
            var attributeWithIdNode = _xmlSearcher.GetNodeInArrayWithId(xmlId, xmlArrayName);
            return _xmlSearcher.GetLevelNodeInChildren(attributeWithIdNode, level);
        }

        public float[] LoadSpecsFloat(int xmlId, int level, string xmlArrayName)
        {
            return _xmlSearcher.GetSpecsFloat(GetSpecsNode(xmlId, level, xmlArrayName));
        }
    }
}