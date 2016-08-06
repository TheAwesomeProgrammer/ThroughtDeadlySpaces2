using UnityEngine;

namespace Assets.Scripts.Camera_ll_UI.HUD
{
    public abstract class UiSwitchManager : MonoBehaviour
    {
        protected UiMoveSwitching _moveSwitching;
        protected UiMoveManager _moveManager;

        public virtual void Start()
        {
            _moveManager = GetComponentInParent<UiMoveManager>();
            _moveSwitching = GetComponent<UiMoveSwitching>();
        }

        public void Switch()
        {
            _moveManager.MoveIfSwitchNotExist((int)_moveSwitching.SwitchType, _moveSwitching);
        }
    }
}