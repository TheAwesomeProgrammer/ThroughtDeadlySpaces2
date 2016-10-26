using Assets.Scripts.Enemy.AI.Factories;
using Assets.Scripts.Enemy.AI.Mind.Abstact;
using Assets.Scripts.Player.Swords;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Enemy.AI.Abstact
{
    public class AnimationStateChanger : StateChangerBase
    {
        public StateType StateTypeTo;

        private AnimationEventListener _animationEventListener;
        private bool _animationEnded;

        protected override void Start()
        {
            base.Start();
            _animationEventListener = GetComponent<AnimationEventListener>();
            _animationEventListener.SetupAnimatorTrigger(null, () => _animationEnded = true);
        } 

        public override bool ShouldStateChange(State currentState, out State newState)
        {
            if (_animationEnded)
            {
                newState = GetState(StateTypeTo);
                return true;
            }

            newState = null;
            return false;
        }
    }
}