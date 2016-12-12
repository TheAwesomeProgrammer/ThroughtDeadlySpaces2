using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Utillity
{
    public class Spawner : MonoBehaviour
    {
        public List<SpawnConfig> SpawnConfigs;

        private void Start()
        {
            CheckSpawnConfigs();
        }

        private void CheckSpawnConfigs()
        {
            foreach (var spawnConfig in SpawnConfigs)
            {
                if (spawnConfig.SpawnOnStart)
                {
                    Spawn(spawnConfig);
                }
            }
        }

        private void Spawn(SpawnConfig spawnConfig)
        {
            Vector3 spawnPosition = spawnConfig.StartSpawnPos.position;

            for (int i = 0; i < spawnConfig.NumberOfObjectsToSpawn; i++)
            {
                spawnConfig.Spawn(spawnPosition, transform);
                spawnPosition += spawnConfig.Offset;
            }
        }
    }
}