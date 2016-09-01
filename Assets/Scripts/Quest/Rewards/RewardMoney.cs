using System.Xml;
using Assets.Scripts.Quest.Rewards.Spawner;

namespace Assets.Scripts.Quest.Rewards
{
    public class RewardMoney : Reward
    {
        private int _money;

        public RewardMoney(int rewardTypeId, int questId, int questGiverId) : base(rewardTypeId, questId, questGiverId)
        {
        }

        public override void LoadXml()
        {
            int[] specs = RewardSpecs;
            _money = specs[0];
        }

        public override void SpawnReward(RewardSpawner rewardSpawner)
        {
            base.SpawnReward(rewardSpawner);
            MoneyDrop moneyDrop = _objectSpawned.GetComponent<MoneyDrop>();
            moneyDrop.MoneyToGive = _money;
        }

        public override string ToString()
        {
            return "Money(" + _money + ")";
        }
    }
}