using System.Collections.Generic;
using System.Xml;
using Assets.Scripts.Xml;

namespace Assets.Scripts.Quest
{
    public class QuestGiverProperties : XmlLoadable
    {
        public string Name;
        public int Health;
        public DropType DropType;
        public List<Reward> Rewards;
        public int[] RewardIds;
        public int Id;

        private static int _id;

        private XmlSearcher _xmlSearcher;

        public QuestGiverProperties(int id)
        {
            Id = id;
            _xmlSearcher = new XmlSearcher(Location.QuestGiver);
            LoadXml();
        }

        public void LoadXml()
        {
            XmlNode questGiverNode = _xmlSearcher.GetNodeInArrayWithId(Id, "QuestGivers");
            SetSpecs(questGiverNode);
            Name = questGiverNode.Attributes["name"].InnerText;
        }

        public void SetSpecs(XmlNode questGiverNode)
        {
            int[] specs = _xmlSearcher.GetSpecsInNode(questGiverNode);
            RewardIds = _xmlSearcher.GetSpecsInNode(questGiverNode, "Rewards");
            DropType = (DropType) specs[0];
            Health = specs[1];
        }
    }
}