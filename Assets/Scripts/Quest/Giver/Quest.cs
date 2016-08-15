using System.Collections.Generic;
using System.Xml;
using Assets.Scripts.Bosses.Manager;
using Assets.Scripts.Extensions.Enums;
using Assets.Scripts.Player.Swords.Abstract;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Quest
{
    public class Quest
    {
	    public int Id;
	    public List<Reward> Rewards;
	    public DropType DropType;
        public BossGeneratorProperties BossGeneratorProperties;

	    private XmlSearcher _xmlSearcher;
	    private XmlNode _questGiverNode;
	    private RewardFactory _rewardFactory;
	    private BossGenerator _bossGenerator;

        public Quest(int id, XmlNode questGiverNode)
        {
            Id = id;
	        _rewardFactory = new RewardFactory();
	        _questGiverNode = questGiverNode;
	        _xmlSearcher = new XmlSearcher(Location.QuestGiver);
	        _bossGenerator = GameObject.FindWithTag(Tag.Scripts).GetComponent<BossGenerator>();
	        Rewards = new List<Reward>();
	        LoadQuestData(id);
        }

	    private void LoadQuestData(int questId)
	    {
		    XmlNode questsNode = _xmlSearcher.SelectChildNode(_questGiverNode, XmlName.QuestRoot);
		    XmlNode questNode = _xmlSearcher.GetNodeInArrayWithId(questId, questsNode);
		    LoadBossGeneratorProperties(questNode);
		    LoadDropType(questNode);
		    LoadRewards(questId, questNode, questsNode);
	    }

	    private void LoadBossGeneratorProperties(XmlNode questNode)
	    {
		    BossGeneratorProperties = GetBossGeneratorProperties(questNode);
	    }

	    private void LoadDropType(XmlNode questNode)
	    {
		    int dropTypeNumber = _xmlSearcher.GetSpecsInNode(questNode, XmlName.BossDropType)[0];
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

	    private void LoadRewards(int questId, XmlNode questNode, XmlNode questsNode)
	    {
		    if (questNode != null)
		    {
			    foreach (XmlNode rewardTypeNode in _xmlSearcher.GetChildrensWithName(questNode, "Type"))
			    {
				    LoadReward(questId, rewardTypeNode, questsNode);
			    }
		    }
	    }

	    private void LoadReward(int rewardId, XmlNode rewardTypeNode, XmlNode questsNode)
	    {
		    int rewardTypeId = _xmlSearcher.GetAttributeNumber(rewardTypeNode, "id");
		    Reward reward = _rewardFactory.GetReward((RewardType) rewardTypeId, rewardId, questsNode);
		    if (reward.IsValid())
		    {
			    Rewards.Add(reward);
		    }
	    }

	    private BossGeneratorProperties GetBossGeneratorProperties(XmlNode questNode)
	    {
		    BossSpawnType bossSpawnType =
			    (BossSpawnType) _xmlSearcher.GetSpecsInNode(questNode, "BossSpawn")[0];
		    BossGeneratorProperties bossGeneratorProperties = _bossGenerator.GetBoss(bossSpawnType);
		    return bossGeneratorProperties;
	    }
    }
}