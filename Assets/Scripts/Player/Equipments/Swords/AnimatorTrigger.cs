using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Input;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{

    [RequireComponent(typeof(InputButton))]
    public class AnimatorTrigger : MonoBehaviour
    {
        public Animator Animator;
        public string TriggerName;
        public event Action AnimationEnded;
        public event Action AnimationStarted;

        private InputButton _inputButton;

        void Start()
        {
            _inputButton = GetComponent<InputButton>();
            _inputButton.ButtonDown += OnButtonDown;
        }

        void OnButtonDown()
        {
            Animator.SetTrigger(TriggerName);
            if (AnimationStarted != null)
            {
                AnimationStarted();
            }
            StartCoroutine(CheckAnimationEnd());
        }

        IEnumerator CheckAnimationEnd()
        {
            bool isInNextState = false;
            int currentHash = 0;

            while (true)
            {
                if (IsNextAnimationFound() && !isInNextState)
                {
                    isInNextState = true;
                    currentHash = Animator.GetNextAnimatorStateInfo(0).fullPathHash;
                }
                else if (IsNextAnimationNotEquals(currentHash) && IsNextAnimationFound() && isInNextState)
                {
                    if (AnimationEnded != null)
                    {
                        AnimationEnded();
                    }
                    break;
                }
                yield return 0;
            }

            
        }

        private bool IsNextAnimationNotEquals(int currentHash)
        {
            return Animator.GetNextAnimatorStateInfo(0).fullPathHash != currentHash;
        }

        private bool IsNextAnimationFound()
        {
            return Animator.GetNextAnimatorStateInfo(0).fullPathHash != 0;
        }
    }
}