using Assets.Scripts.Quest.Rewards.Spawner;
using XmlLibrary;

namespace Assets.Scripts.Quest
{
    public interface Rewardable
    {
        void SpawnReward(RewardSpawner rewardSpawner);
    }
}