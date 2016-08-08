namespace Assets.Scripts.Player.Equipments.Attributes
{
    public class AttributeXmlData
    {
        public string LocationToXmlDocument;
        public int XmlId;
        public string XmlRootName;

        public AttributeXmlData(string locationToXmlDocument, int xmlId, string xmlRootName)
        {
            LocationToXmlDocument = locationToXmlDocument;
            XmlId = xmlId;
            XmlRootName = xmlRootName;
        }
    }
}