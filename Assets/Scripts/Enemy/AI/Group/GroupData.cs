using System;

namespace Assets.Scripts.Enemy.AI
{
    [Serializable]
    public class GroupData
    {
        public int GroupMinSize;
        public GroupSize GroupSize;

        public GroupData(int groupMinSize, GroupSize groupSize)
        {
            GroupMinSize = groupMinSize;
            GroupSize = groupSize;
        }
    }
}