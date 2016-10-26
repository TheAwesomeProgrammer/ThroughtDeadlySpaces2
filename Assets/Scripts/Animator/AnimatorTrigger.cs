using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Input;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    public enum AnimatorRunMode
    {
        AlwaysRun,
        RunIfNoAnimationPlaying
    }

    public class AnimatorTrigger : AnimatorTriggerBase
    {
        public Animator Animator;

        protected int _layerNumber;

        private InputButton _inputButton;
        private bool _shouldCancel;
        private bool _running;

        protected virtual void Start()
        {
            _layerNumber = 0;
            _inputButton = GetComponent<InputButton>();
            if (_inputButton)
            {
                _inputButton.ButtonDown += () => StartAnimation(AnimatorRunMode.RunIfNoAnimationPlaying);
            }
        }

        public override void Cancel()
        {
            _shouldCancel = true;
        }

        public override void End()
        {
            Animator.SetTrigger(TriggerEndName);
            _running = false;
        }

        public override void StartAnimation(AnimatorRunMode animatorRunMode)
        {
            switch (animatorRunMode)
            {
                case AnimatorRunMode.AlwaysRun:
                    StartAnimation();
                    break;
                case AnimatorRunMode.RunIfNoAnimationPlaying:
                    if (!_running)
                    {
                        StartAnimation();
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException("animatorRunMode", animatorRunMode, null);
            }
        }

        private void StartAnimation()
        {
            StartCoroutine(DoAnimation());
            _running = true;
        }


        IEnumerator DoAnimation()
        {
            OnAnimationStarting();
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

        protected virtual IEnumerator CheckAnimationEnd()
        {
            bool isInNextState = false;
            int currentHash = 0;
            
            while (true)
            {
                if (IsNextAnimationFound() && !isInNextState)
                {
                    isInNextState = true;

                    currentHash = GetNextAnimatorStateInfo().fullPathHash;
                }
                else if (IsNextAnimationNotEquals(currentHash) && IsNextAnimationFound() && isInNextState)
                {
                    OnAnimationEnded();
                    _running = false;
                    break;
                }
                yield return 0;
            }
        }

        protected virtual AnimatorStateInfo GetNextAnimatorStateInfo()
        {
            return Animator.GetNextAnimatorStateInfo(_layerNumber);
        }

        private bool IsNextAnimationNotEquals(int currentHash)
        {
            return Animator.GetNextAnimatorStateInfo(_layerNumber).fullPathHash != currentHash;
        }

        private bool IsNextAnimationFound()
        {
            return Animator.GetNextAnimatorStateInfo(_layerNumber).fullPathHash != 0;
        }
    }
}