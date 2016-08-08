namespace Assets.Scripts.Camera_ll_UI.HUD
{
    public class UiESwitching : UiSwitchManager
    {
        public void Drop()
        {
           _moveSwitching.ForEachOnUiMover(mover => mover.GetComponent<EDrop>().Drop());
        }
    }
}