using System.Xml;
using Assets.Scripts.Xml;

namespace Assets.Scripts.Player.Swords
{
    public class EquipmentAttributeLoader
    {
        private XmlSearcher _xmlSearcher;

        public EquipmentAttributeLoader(string xmlDocumentLocation)
        {
            _xmlSearcher = new XmlSearcher(xmlDocumentLocation);
        }

        public int[] LoadSpecs(int xmlId, int level, string xmlArrayName)
        {
            var attributeWithIdNode = _xmlSearcher.GetNodeInArrayWithId(xmlId, xmlArrayName);
            var levelNode = _xmlSearcher.GetLevelNodeInChildren(attributeWithIdNode, level);
            return _xmlSearcher.GetSpecs(levelNode);
        }
    }
}