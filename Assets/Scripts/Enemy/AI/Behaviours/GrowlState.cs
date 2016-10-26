using Assets.Scripts.Enemy.AI.Factories;
using Assets.Scripts.Enemy.AI.Mind.Abstact;
using Assets.Scripts.Player.Swords;
using UnityEditor.Animations;
using UnityEngine;

namespace Assets.Scripts.Enemy.AI.Abstact
{
    public class GrowlState : AiState
    {
        public override StateType StateType
        {
            get { return StateType.Growl; }
        }

        private AnimatorTriggerBase _animatorTriggerBase;

        private void Start()
        {
            _animatorTriggerBase = GetComponent<AnimatorTriggerBase>();
        }

        public override void OnEnterState()
        {
            Debug.Log("Playing growling sound");
            _animatorTriggerBase.StartAnimation(AnimatorRunMode.AlwaysRun);
            Debug.Log("Playing growling animation");
        }

        public override void OnExitState()
        {
            Debug.Log("Stopping growling");
        }
    }
}