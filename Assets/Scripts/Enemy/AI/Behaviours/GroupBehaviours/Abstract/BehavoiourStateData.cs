using System;

namespace Assets.Scripts.Enemy.AI.Factories
{
    [Serializable]
    public class BehavoiourStateData
    {
        public AiState State;
        public BehaviourType BehaviourType;

        public BehavoiourStateData(AiState state, BehaviourType behaviourType)
        {
            State = state;
            BehaviourType = behaviourType;
        }
    }
}