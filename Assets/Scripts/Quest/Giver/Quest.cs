using System.Collections.Generic;
using System.Xml;
using Assets.Scripts.Bosses.Manager;
using Assets.Scripts.Extensions.Enums;
using Assets.Scripts.Player.Swords.Abstract;
using XmlLibrary;
using UnityEngine;

namespace Assets.Scripts.Quest
{
    public class Quest
    {
	    public int Id;
	    public List<Reward> Rewards;
	    public DropType DropType;
        public BossGeneratorProperties BossGeneratorProperties;

	    private RewardFactory _rewardFactory;
	    private BossGenerator _bossGenerator;
        private int _questGiverId;

        public Quest(int id, int questGiverId)
        {
            Id = id;
            _questGiverId = questGiverId;
            _rewardFactory = new RewardFactory();
	        _bossGenerator = GameObject.FindWithTag(Tag.Scripts).GetComponent<BossGenerator>();
	        Rewards = new List<Reward>();
	        LoadQuestData(id);
        }

	    private void LoadQuestData(int questId)
	    {
            XmlPath questsPath = new DefaultXmlPath(XmlLocation.QuestGiver,
                new XmlPathData(_questGiverId),
                new XmlPathData(Id),
                new XmlPathData(XmlName.QuestRoot));
            XmlPath questPath = new DefaultXmlPath(questsPath, new XmlPathData(questId));

            LoadBossGeneratorProperties(questPath);
		    LoadDropType(questPath);
		    LoadRewards(questId, questPath, questsPath);
	    }

	    private void LoadBossGeneratorProperties(XmlPath questPath)
	    {
		    BossGeneratorProperties = GetBossGeneratorProperties(questPath);
	    }

	    private void LoadDropType(XmlPath questPath)
	    {
            XmlPath dropTypePath = new DefaultXmlPath(questPath, new XmlPathData(XmlName.BossDropType));

            int dropTypeNumber = dropTypePath.GetSpecs()[0];
		    DropType = (DropType) dropTypeNumber;
		    if (DropType == DropType.Random)
		    {
			    LoadRandomDropType(DropType.Length());
		    }
	    }

	    private void LoadRandomDropType(int dropTypeLength)
	    {
		    DropType = (DropType) Random.Range(0, dropTypeLength - 1);
	    }

	    private void LoadRewards(int questId, XmlPath questPath, XmlPath questsPath)
	    {
		    if (questPath != null)
		    {
                XmlPath typePath = new DefaultXmlPath(questPath, new XmlPathData("Type"));
		        for (int i = 0; i < typePath.PathLength; i++)
		        {
                    LoadReward(questId, new DefaultXmlPath(questPath, new XmlPathData("Type", i)));
                }
		    }
	    }

	    private void LoadReward(int questId, XmlPath typePath)
	    {
		    int rewardTypeId = typePath.GetAttributeNumber("id");
		    Reward reward = _rewardFactory.GetReward((RewardType) rewardTypeId, questId, _questGiverId);
		    if (reward.IsValid())
		    {
			    Rewards.Add(reward);
		    }
	    }

	    private BossGeneratorProperties GetBossGeneratorProperties(XmlPath questPath)
	    {
            XmlPath bossSpawnPath = new DefaultXmlPath(questPath, new XmlPathData("BossSpawn"));
            BossSpawnType bossSpawnType =
			    (BossSpawnType)bossSpawnPath.GetSpecs()[0];
		    BossGeneratorProperties bossGeneratorProperties = _bossGenerator.GetBoss(bossSpawnType);
		    return bossGeneratorProperties;
	    }
    }
}