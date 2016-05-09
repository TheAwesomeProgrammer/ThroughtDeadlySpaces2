using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Bosses.Manager
{
    public class BossGenerator : MonoBehaviour
    {
        private BossObjectFactory _bossObjectFactory;

        void Start()
        {
            _bossObjectFactory = GetComponent<BossObjectFactory>();
        }

        public BossGeneratorProperties GetBoss(BossSpawnType bossSpawnType, int bossId = 1)
        {
            BossGeneratorProperties bossGeneratorProperties = null;
            GameObject boss = null;

            if (bossSpawnType == BossSpawnType.Random)
            {
                boss = _bossObjectFactory.GetRandomElement();
                bossGeneratorProperties = new BossGeneratorProperties(boss, GetRandomDifficulty(), boss.name);
            }
            else if (bossSpawnType == BossSpawnType.Specific)
            {
                boss = _bossObjectFactory.GetElement(bossId);
                bossGeneratorProperties = new BossGeneratorProperties(boss, GetRandomDifficulty(), boss.name);
            }

            return bossGeneratorProperties;
        }

        private Difficulty GetRandomDifficulty()
        {
            return (Difficulty)Random.Range(0, Enum.GetNames(typeof (Difficulty)).Length);
        }
    }
}