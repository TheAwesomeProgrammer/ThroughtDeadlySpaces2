using Assets.Scripts.Bosses.Abstract;
using Assets.Scripts.Player.Swords.Abstract.Bosses.Attack;
using UnityEngine;

namespace Assets.Scripts.Bosses.Manager
{
    public class BossGeneratorProperties : ObjectSpawnerable
    {
        public GameObject Boss;
        public Difficulty Difficulty;
        public string Name;

        public BossGeneratorProperties(GameObject boss, Difficulty difficulty, string name)
        {
            Boss = boss;
            Difficulty = difficulty;
            Name = name;
        }

        public GameObject Spawn(Vector3 spawnPosition)
        {
            GameObject spawnedBoss = Object.Instantiate(Boss, spawnPosition, Boss.transform.rotation) as GameObject;
            BossProperties bossProperties = spawnedBoss.GetComponent<BossProperties>();
            bossProperties.Difficulty = Difficulty;
            return spawnedBoss;
        }
    }
}