using UnityEngine;

namespace Assets.Scripts.Camera_ll_UI
{
    public abstract class UiItem : MonoBehaviour
    {
        public int UiId;

        public void Show()
        {
            OnShow();
        }

        public void Hide()
        {
            OnHide();
        }

        public virtual void SetProperties(params object[] properties)
        {
            
        }

        protected virtual void OnShow()
        {
            
        }

        protected virtual void OnHide()
        {
            
        }

    }
}