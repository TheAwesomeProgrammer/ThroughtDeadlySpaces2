using Assets.Scripts.Debugging;

namespace Assets.Scripts.Xml
{
    public class XmlFileLocations
    {
        public static string GetLocation(Location location)
        {
            switch (Build.State)
            {
                case BuildState.Debug:
                    return GetDebugLocation(location);
                case BuildState.Release:
                    return GetReleaseLocation(location);
                default:
                    return "";
            }
        }

        private static string GetDebugLocation(Location location)
        {
            switch (location)
            {
                case Location.Sword:
                    return "Xml/Test/Swords.xml";
                case Location.Curse:
                    return "Xml/Test/Curses.xml";
                case Location.Blessing:
                    return "Xml/Test/Blessings.xml";
                case Location.QuestGiver:
                    return "Xml/Test/QuestGivers.xml";
                case Location.Shop:
                    return "Xml/Test/Shop.xml";
                case Location.Armor:
                    return "Xml/Test/Armor.xml";
                case Location.Boss:
                    return "Xml/Test/Bosses.xml";
                default:
                    return "";
            }
        }

        private static string GetReleaseLocation(Location location)
        {
            switch (location)
            {
                case Location.Sword:
                    return "Xml/Release/Elements.xml";
                case Location.Curse:
                    return "Xml/Release/Curses.xml";
                case Location.Blessing:
                    return "Xml/Release/Blessings.xml";
                case Location.QuestGiver:
                    return "Xml/Release/QuestGivers.xml";
                case Location.Shop:
                    return "Xml/Release/Shop.xml";
                case Location.Boss:
                    return "Xml/Release/Bosses.xml";
                default:
                    return "";
            }
        }
    }
}