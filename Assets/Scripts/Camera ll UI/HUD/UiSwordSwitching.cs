using System;
using Assets.Scripts.Extensions;
using UnityEngine;

namespace Assets.Scripts.Camera_ll_UI.HUD
{
    public class UiSwordSwitching : MonoBehaviour
    {
        private UiMoveSwitching _moveSwitching;
        private UiMoveManager _moveManager;
        private Action _onSwordsOutOfScreen;

        public void Start()
        {
            _moveSwitching = GetComponent<UiMoveSwitching>();
            _moveManager = GetComponentInParent<UiMoveManager>();
        }

        public void Switch(Action onSwordsOutOfScreen = null)
        {
            _onSwordsOutOfScreen = onSwordsOutOfScreen;
            _moveManager.MoveIfSwitchNotExist(_moveSwitching, OnCompletedSwitch);
        }

        private void OnCompletedSwitch()
        {
            _onSwordsOutOfScreen.CallIfNotNull();
            _moveManager.Move(_moveSwitching);
        }
    }
}