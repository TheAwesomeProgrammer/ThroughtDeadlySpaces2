﻿using System.Xml;
using Assets.Scripts.Quest.Rewards.Spawner;

namespace Assets.Scripts.Quest
{
    public class RewardPotion : Reward
    {
        private int _numberOfPotionsToSpawn = 1;

        public PotionType PotionType;

        public RewardPotion(int rewardTypeId, int rewardId) : base(rewardTypeId, rewardId)
        {
        }

        public override void LoadXml()
        {
            int[] specs = RewardSpecs;
            PotionType = (PotionType)specs[0];
            if (specs.Length > 1)
            {
                _numberOfPotionsToSpawn = specs[1];
            }
        }

        public override void SpawnReward(RewardSpawner rewardSpawner)
        {
            for (int i = 0; i < _numberOfPotionsToSpawn; i++)
            {
                base.SpawnReward(rewardSpawner);
            }
        }

        public override string ToString()
        {
            return PotionType + "(" + _numberOfPotionsToSpawn + "x)";
        }
    }
}