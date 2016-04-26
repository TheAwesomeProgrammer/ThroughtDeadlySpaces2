using System.Xml;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    public sealed class SwordXmlLoader : XmlLoadable
    {
        private EnumConverter _enumConverter;
        private XmlSearcher _xmlSearcher;
        private Sword _sword;
        private SwordAttributeAdder _swordAttributeAdder;

        public SwordXmlLoader(Sword sword)
        {
            _sword = sword;
            _swordAttributeAdder = new SwordAttributeAdder(sword);
            _xmlSearcher = new XmlSearcher(XmlFileLocations.GetLocation(Location.Sword));
            _enumConverter = new EnumConverter();
            LoadXml();
        }

        public void LoadXml()
        {
            int[] specs = _xmlSearcher.GetSpecsInChildrenWithId(_sword.SwordId, "Swords");

            _sword.Specs = new SwordSpecs(specs[0], specs[1], specs[2], specs[3], specs[4]);
            AddAttributes();
        }

        void AddAttributes()
        {
            XmlNode swordNode = _xmlSearcher.GetNodeInArrayWithId(_sword.SwordId, "Swords");

            SwordAttribute[] swordAttributes = _enumConverter.Convert<SwordAttribute>(_xmlSearcher.GetAttributesInNode(swordNode));

            foreach (var swordAttribute in swordAttributes)
            {
                _swordAttributeAdder.AddAttribute(swordAttribute);
            }
        }
    }
}