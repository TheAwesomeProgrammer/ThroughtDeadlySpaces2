using Assets.Scripts.Input;
using UnityEngine;

namespace Assets.Scripts.Camera_ll_UI.HUD
{
    public class UiTabSwitching : MonoBehaviour
    {
        private UiMoveSwitching _moveSwitching;
        private InputButton _inputButton;
        private UiMoveManager _uiMoveManager;

        public void Start()
        {
            _uiMoveManager = GetComponentInParent<UiMoveManager>();
            _moveSwitching = GetComponent<UiMoveSwitching>();
            _inputButton = GetComponent<InputButton>();
            _inputButton.ButtonDown += OnTap;
        }

        private void OnTap()
        {
            _uiMoveManager.MoveIfSwitchNotExist((int)_moveSwitching.SwitchType, _moveSwitching);
        }
    }
}