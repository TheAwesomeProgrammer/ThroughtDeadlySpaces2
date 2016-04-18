namespace Assets.Scripts.Xml
{
    public class XmlFileLocations
    {
        public static string GetLocation(Location location)
        {
            switch (location)
            {
                case Location.Sword:
                    return "Xml/TestSwords.xml";
                case Location.Curse:
                    return "Xml/TestCurses.xml";
                case Location.Blessing:
                    return "Xml/TestBlessings.xml";

                default:
                    return "";
            }
        }
    }
}