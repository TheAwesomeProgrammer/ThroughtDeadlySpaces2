using Assets.Scripts.Input;
using UnityEngine;

namespace Assets.Scripts.Camera_ll_UI.HUD
{
    public class UiTabSwitching : UiSwitchManager
    {
        private InputButton _inputButton;

        public override void Start()
        {
            base.Start();
            _inputButton = GetComponent<InputButton>();
            _inputButton.ButtonDown += OnTap;
        }

        private void OnTap()
        {
            Switch();
        }
    }
}