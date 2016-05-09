using Assets.Scripts.Bosses.Manager;

namespace Assets.Scripts.Quest
{
    public class QuestProperties
    {
        public Reward Reward;
        public int Id;
        public BossGeneratorProperties BossGeneratorProperties;

        public QuestProperties(Reward reward, int id, BossGeneratorProperties bossGeneratorProperties)
        {
            Reward = reward;
            Id = id;
            BossGeneratorProperties = bossGeneratorProperties;
        }
        
    }
}