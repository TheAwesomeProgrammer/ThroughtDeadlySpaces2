using Assets.Scripts.Quest.Rewards.Spawner;
using Assets.Scripts.Xml;

namespace Assets.Scripts.Quest
{
    public interface Rewardable
    {
        void SpawnReward(RewardSpawner rewardSpawner);
    }
}