using System.Collections.Generic;
using System.Xml;
using Assets.Scripts.Bosses.Manager;
using XmlLibrary;

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
        private XmlPath _questGiverPath;
        private XmlPath _questGiverSpecsPath;

        public BossGeneratorProperties BossGeneratorProperties
        {
            get { return Quests[CurrentQuestId].BossGeneratorProperties; }
        }

        public QuestGiverProperties()
        {
            Quests = new List<Quest>();
        }

        public void LoadQuests(int questGiverId)
        {
	        foreach (var questId in QuestIds)
	        {
		        Quests.Add(new Quest(questId, questGiverId));
	        }
        }

        public void LoadXml()
        {
	        _xmlSearcher = new XmlSearcher(XmlLocation.QuestGiver);
            _questGiverPath = new DefaultXmlPath(XmlLocation.QuestGiver, new XmlPathData(Id));
            _questGiverSpecsPath = new DefaultXmlPath(_questGiverPath, new XmlPathData(XmlName.SpecNodeName));
            SetSpecs();
	        Name = _questGiverPath.GetAttributeText("name");
        }

        public void SetSpecs()
        {
            int[] specs = _questGiverSpecsPath.GetSpecs();
            QuestIds = new[] {1, 2, 3};
            Health = specs[0];
        }

	    public List<Reward> GetRewards()
	    {
		    return Quests[CurrentQuestId].Rewards;
	    }
    }
}