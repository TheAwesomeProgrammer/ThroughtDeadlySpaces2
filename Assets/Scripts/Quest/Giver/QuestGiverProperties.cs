using System.Collections.Generic;
using System.Xml;
using Assets.Scripts.Bosses.Manager;
using Assets.Scripts.Xml;

namespace Assets.Scripts.Quest
{
    [System.Serializable]
    public class QuestGiverProperties : XmlLoadable
    {
        public string Name;
        public int Health;
        public List<Quest> Quests;
        public int[] QuestIds;
        public int Id;
        public int UiId;
        public int CurrentQuestId;

        private XmlSearcher _xmlSearcher;

        public BossGeneratorProperties BossGeneratorProperties
        {
            get { return Quests[CurrentQuestId].BossGeneratorProperties; }
        }

        public QuestGiverProperties()
        {
            Quests = new List<Quest>();
        }

        public void LoadQuests(XmlNode questGiverNode)
        {
	        foreach (var questId in QuestIds)
	        {
		        Quests.Add(new Quest(questId, questGiverNode));
	        }
        }

        public void LoadXml()
        {
	        _xmlSearcher = new XmlSearcher(Location.QuestGiver);
	        XmlNode questGiverNode = _xmlSearcher.GetNodeInArrayWithId(Id, XmlName.QuestGiverRoot);
            SetSpecs(questGiverNode);
	        Name = _xmlSearcher.GetAttributeText(questGiverNode, "name");
        }

        public void SetSpecs(XmlNode questGiverNode)
        {
            int[] specs = _xmlSearcher.GetSpecsInNode(questGiverNode);
            QuestIds = new[] {1, 2, 3};
            Health = specs[0];
        }

	    public List<Reward> GetRewards()
	    {
		    return Quests[CurrentQuestId].Rewards;
	    }
    }
}