using Assets.Scripts.Extensions;
using UnityEngine;

namespace Assets.Scripts.Camera_ll_UI.HUD
{
    public abstract class UiSwitchManager : MonoBehaviour
    {
	    public bool Switched
	    {
		    get
		    {
			    return Null.OnNot(_moveSwitching, () => _moveSwitching.Moved);
		    }
	    }

	    protected UiMoveSwitching _moveSwitching;
        protected UiMoveManager _moveManager;

        public virtual void Start()
        {
            _moveManager = GetComponentInParent<UiMoveManager>();
            _moveSwitching = GetComponent<UiMoveSwitching>();

        }

        public void Switch(bool shouldAlwaysRun = false)
        {
	        if (!shouldAlwaysRun)
	        {
		        _moveManager.MoveIfSwitchNotExist((int) _moveSwitching.SwitchType, _moveSwitching);
	        }
	        else
	        {
		        _moveManager.Move((int) _moveSwitching.SwitchType, _moveSwitching);
	        }

        }
    }
}