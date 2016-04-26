namespace Assets.Scripts.Quest
{
    public class EmptyReward : Reward
    {
        public EmptyReward(int rewardTypeId, int rewardId) : base(rewardTypeId, rewardId)
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