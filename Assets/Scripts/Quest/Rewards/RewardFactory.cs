using System.Xml;
using Assets.Scripts.Quest.Rewards;

namespace Assets.Scripts.Quest
{
    public class RewardFactory
    {
        public Reward GetReward(RewardType rewardType, int rewardId, XmlNode questsNode)
        {
            int rewardTypeId = (int) rewardType;

            switch (rewardType)
            {
                case RewardType.Potion:
                    return new RewardPotion(rewardTypeId, rewardId, questsNode);
                case RewardType.Money:
                    return new RewardMoney(rewardTypeId, rewardId, questsNode);
                case RewardType.Sword:
                    return new RewardSword(rewardTypeId, rewardId, questsNode);
                default:
                    return new EmptyReward(rewardTypeId, rewardId, questsNode);
            }
        }
    }
}