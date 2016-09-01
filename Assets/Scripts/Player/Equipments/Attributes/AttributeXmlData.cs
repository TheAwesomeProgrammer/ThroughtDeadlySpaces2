using XmlLibrary;

namespace Assets.Scripts.Player.Equipments.Attributes
{
    public class AttributeXmlData
    {
        public XmlLocation XmlLocation;
        public int XmlId;

        public AttributeXmlData(XmlLocation xmlLocation, int xmlId)
        {
            XmlLocation = xmlLocation;
            XmlId = xmlId;
        }
    }
}