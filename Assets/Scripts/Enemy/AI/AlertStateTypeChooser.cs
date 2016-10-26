using System;
using Assets.Scripts.Enemy.AI.Mind.Abstact;

namespace Assets.Scripts.Enemy.AI
{
    public class AlertStateTypeChooser : StateTypeChooserBase
    {
        public StateType IndividualStateType;
        public StateType GroupStateType;

        private Group _group;

        private void Start()
        {
            _group = GetComponentInParent<Group>();
        }

        public override StateType GetStateType()
        {
            switch (_group.Size)
            {
                case GroupSize.Big:
                case GroupSize.Small:
                    return GroupStateType;
                case GroupSize.Individual:
                    return IndividualStateType;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}