namespace Assets.Scripts.Camera_ll_UI
{
    public class UiItemActive : UiItem
    {
        protected override void OnShow()
        {
            base.OnShow();
            gameObject.SetActive(true);
        }

        protected override void OnHide()
        {
            base.OnHide();
            gameObject.SetActive(false);
        }
    }
}