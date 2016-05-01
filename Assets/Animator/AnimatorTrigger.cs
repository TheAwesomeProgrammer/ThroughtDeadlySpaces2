using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Input;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    public class AnimatorTrigger : MonoBehaviour
    {
        public Animator Animator;
        public string TriggerName;
        public string TriggerEndName;
        public event Action AnimationEnded;
        public event Action AnimationStarting;

        private InputButton _inputButton;
        private bool _shouldCancel;

        void Start()
        {
            _inputButton = GetComponent<InputButton>();
            if (_inputButton)
            {
                _inputButton.ButtonDown += StartAnimation;
            }
        }

        public void Cancel()
        {
            _shouldCancel = true;
        }

        public void End()
        {
            Animator.SetTrigger(TriggerEndName);
        }

        public void StartAnimation()
        {
            StartCoroutine(DoAnimation());
        }

        IEnumerator DoAnimation()
        {
            if (AnimationStarting != null)
            {
                AnimationStarting();
            }
            yield return 0;
            if (!_shouldCancel)
            {
                StartCoroutine(CheckAnimationEnd());
                Animator.SetTrigger(TriggerName);
            }
            else
            {
                _shouldCancel = false;
            }
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