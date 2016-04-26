using Assets.Scripts.Quest.Rewards;

namespace Assets.Scripts.Quest
{
    public class RewardFactory
    {
        public Reward GetReward(RewardType rewardType, int rewardId)
        {
            int rewardTypeId = (int) rewardType;

            switch (rewardType)
            {
                case RewardType.Potion:
                    return new RewardPotion(rewardTypeId, rewardId);
                case RewardType.Money:
                    return new RewardMoney(rewardTypeId, rewardId);
                case RewardType.Sword:
                    return new RewardSword(rewardTypeId, rewardId);
                default:
                    return new EmptyReward(rewardTypeId, rewardId);
            }
        }
    }
}