using Assets.Scripts.Enemy.AI.Behaviours.GroupBehaviours.Abstract;
using Assets.Scripts.Enemy.AI.Mind.Abstact;
using Assets.Scripts.Extensions;
using UnityEngine;

namespace Assets.Scripts.Enemy.AI.Factories
{
    public class RandomGroupBehaviour : GroupBehaviourBase
    {
        public override GroupSize GroupSize
        {
            get { return _groupSize; }
        }

        public override StateType StateType
        {
            get { return _groupType; }
        }

        [SerializeField]
        [BitMask(typeof(GroupSize))]
        private GroupSize _groupSize;
        [SerializeField]
        private StateType _groupType;

        public override State GetState()
        {
            State randomState = _states.Random().State;
            Debug.Log("Chosing a random state. That state is "+ randomState);
            return randomState;
        }
    }
}