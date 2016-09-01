using System.Diagnostics;
using System.Xml;
using Assets.Scripts.Enviroment.Map.Pickups;
using Assets.Scripts.Quest.Rewards.Spawner;
using XmlLibrary;
using UnityEngine;

namespace Assets.Scripts.Quest
{
    public class RewardSword : Reward
    {
        public int SwordId;
        public string SwordName;
        public int[] SwordDamageSpecs;

        private XmlPath _swordPath;

        public RewardSword(int rewardTypeId, int questId, int questGiverId) : base(rewardTypeId, questId, questGiverId)
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
            _swordPath = new DefaultXmlPath(XmlLocation.Sword, new XmlPathData(SwordId));
            LoadSwordName();
			LoadSwordDamageSpecs(SwordId);
        }

	    public override bool IsValid()
	    {
		    LoadSwordId();
		    return SwordId > 0;
	    }

	    private void LoadSwordName()
	    {
	        SwordName = _swordPath.GetAttributeText("name");
	    }

        private void LoadSwordDamageSpecs(int swordId)
        {
            XmlPath swordSpecsPath = new DefaultXmlPath(_swordPath, new XmlPathData(XmlName.SpecNodeName));
            SwordDamageSpecs = _swordPath.GetSpecs();
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