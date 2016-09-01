using System.Xml;

namespace Assets.Scripts.Quest
{
    public class EmptyReward : Reward
    {
        public EmptyReward(int rewardTypeId, int questId, int questGiverId) : base(rewardTypeId, questId, questGiverId)
        {
        }

        public override void LoadXml()
        {
            
        }

        public override string ToString()
        {
            return "Empty reward";
        }
    }
}