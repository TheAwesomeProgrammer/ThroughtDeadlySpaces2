using System.Xml;

namespace Assets.Scripts.Quest
{
    public class EmptyReward : Reward
    {
        public EmptyReward(int rewardTypeId, int questId, XmlNode questsNode) : base(rewardTypeId, questId, questsNode)
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