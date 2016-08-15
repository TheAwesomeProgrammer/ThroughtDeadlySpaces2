using System.Diagnostics;
using System.Xml;
using Assets.Scripts.Enviroment.Map.Pickups;
using Assets.Scripts.Quest.Rewards.Spawner;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Quest
{
    public class RewardSword : Reward
    {
        public int SwordId;
        public string SwordName;
        public int[] SwordDamageSpecs;

        public RewardSword(int rewardTypeId, int questId, XmlNode questsNode) : base(rewardTypeId, questId, questsNode)
        {
        }

        public override void LoadXml()
        {
	        LoadSwordId();
		    LoadSwordSpecs();
        }

	    private void LoadSwordId()
	    {
		    int[] specs = RewardSpecs;
		    SwordId = specs[0];
	    }

        private void LoadSwordSpecs()
        {
			_xmlSearcher = new XmlSearcher(Location.Sword);
	        XmlNode swordNode = _xmlSearcher.GetNodeInArrayWithId(SwordId, "Swords");
	        UnityEngine.Debug.Log("Sword id"+SwordId);
			LoadSwordName(swordNode);
			LoadSwordDamageSpecs(swordNode);
        }

	    public override bool IsValid()
	    {
		    LoadSwordId();
		    return SwordId > 0;
	    }

	    private void LoadSwordName(XmlNode swordNode)
        {
            if (swordNode.Attributes != null)
            {
                SwordName = swordNode.Attributes["name"].InnerText;
            }
        }

        private void LoadSwordDamageSpecs(XmlNode swordNode)
        {
            swordNode = _xmlSearcher.GetNodeInArrayWithId(SwordId, "Swords");
            SwordDamageSpecs = _xmlSearcher.GetSpecsInNode(swordNode);
        }

        public override void SpawnReward(RewardSpawner rewardSpawner)
        {
            base.SpawnReward(rewardSpawner);
            SwordDrop swordDrop = _objectSpawned.GetComponent<SwordDrop>();
            swordDrop.SwordId = SwordId;
        }

        public override string ToString()
        {
            return SwordName + "(" + SwordDamageSpecs[0] + "," + SwordDamageSpecs[1] + "," + SwordDamageSpecs[2] + "," +
                   SwordDamageSpecs[3] + "," +
                   SwordDamageSpecs[4] + ")";
        }
    }
}