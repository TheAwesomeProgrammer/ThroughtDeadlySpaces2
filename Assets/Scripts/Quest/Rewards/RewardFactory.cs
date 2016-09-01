using System.Xml;
using Assets.Scripts.Quest.Rewards;

namespace Assets.Scripts.Quest
{
    public class RewardFactory
    {
        public Reward GetReward(RewardType rewardType, int rewardId, int questGiverId)
        {
            int rewardTypeId = (int) rewardType;

            switch (rewardType)
            {
                case RewardType.Potion:
                    return new RewardPotion(rewardTypeId, rewardId, questGiverId);
                case RewardType.Money:
                    return new RewardMoney(rewardTypeId, rewardId, questGiverId);
                case RewardType.Sword:
                    return new RewardSword(rewardTypeId, rewardId, questGiverId);
                default:
                    return new EmptyReward(rewardTypeId, rewardId, questGiverId);
            }
        }
    }
}