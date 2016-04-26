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
                    return "Xml/TestSwords.xml";
                case Location.Curse:
                    return "Xml/TestCurses.xml";
                case Location.Blessing:
                    return "Xml/TestBlessings.xml";
                case Location.Reward:
                    return "Xml/TestRewards.xml";
                case Location.QuestGiver:
                    return "Xml/TestQuestGivers.xml";
                default:
                    return "";
            }
        }

        private static string GetReleaseLocation(Location location)
        {
            switch (location)
            {
                case Location.Sword:
                    return "Xml/Elements.xml";
                case Location.Curse:
                    return "Xml/Curses.xml";
                case Location.Blessing:
                    return "Xml/Blessings.xml";
                case Location.Reward:
                    return "Xml/Rewards.xml";
                case Location.QuestGiver:
                    return "Xml/QuestGivers.xml";
                default:
                    return "";
            }
        }
    }
}