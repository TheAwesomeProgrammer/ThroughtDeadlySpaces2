using UnityEngine;

namespace Assets.Scripts.Bosses.Manager
{
    public class BossGeneratorProperties
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
    }
}