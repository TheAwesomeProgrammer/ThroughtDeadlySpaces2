using System.Collections.Generic;
using System.Xml;
using Assets.Scripts.Bosses.Manager;
using Assets.Scripts.Xml;

namespace Assets.Scripts.Quest
{
    public class QuestGiverProperties : XmlLoadable
    {
        public string Name;
        public int Health;
        public DropType DropType;
        public List<QuestProperties> QuestPropertieses;
        public int[] RewardIds;
        public int Id;
        public int UiId;
        public int CurrentQuestId;

        private XmlSearcher _xmlSearcher;

        public BossGeneratorProperties BossGeneratorProperties
        {
            get { return QuestPropertieses[CurrentQuestId].BossGeneratorProperties; }
        }

        public QuestGiverProperties()
        {
            _xmlSearcher = new XmlSearcher(Location.QuestGiver);
            LoadXml();
        }

        public void AddReward(int id, Reward reward, BossGeneratorProperties bossGeneratorProperties)
        {
            QuestPropertieses.Add(new QuestProperties(reward, id, bossGeneratorProperties));
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
            RewardIds = new[] {1, 2, 3};
            DropType = (DropType) specs[0];
            Health = specs[1];
        }
    }
}