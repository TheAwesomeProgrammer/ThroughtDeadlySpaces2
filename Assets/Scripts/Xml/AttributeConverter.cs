namespace Assets.Scripts.Xml
{
    public class AttributeConverter : XmlConverter
    {
        public string[] Convert(string xmlAttributeText)
        {
            return GetElementsInString(xmlAttributeText);
        }
    }
}