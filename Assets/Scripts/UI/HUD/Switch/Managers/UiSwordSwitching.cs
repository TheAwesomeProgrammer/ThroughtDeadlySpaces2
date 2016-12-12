using System;
using Assets.Scripts.Extensions;
using UnityEngine;

namespace Assets.Scripts.Camera_ll_UI.HUD
{
    public class UiSwordSwitching : UiSwitchManager
    {
        private Action _onSwordsOutOfScreen;

        public void Switch(Action onSwordsOutOfScreen = null)
        {
            _onSwordsOutOfScreen = onSwordsOutOfScreen;
            _moveManager.MoveIfSwitchNotExist(_moveSwitching, OnCompletedSwitch);
        }

        private void OnCompletedSwitch()
        {
            _onSwordsOutOfScreen.InvokeIfNotNull();
            _moveManager.Move(_moveSwitching);
        }
    }
}