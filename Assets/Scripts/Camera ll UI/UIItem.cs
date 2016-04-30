using UnityEngine;

namespace Assets.Scripts.Camera_ll_UI
{
    public abstract class UiItem : MonoBehaviour
    {
        public int UiId;

        public void Activate()
        {
            gameObject.SetActive(true);
            OnActivate();
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
            OnDeactivate();
        }

        public virtual void SetProperties(params object[] properties)
        {
            
        }

        protected virtual void OnActivate()
        {
            
        }

        protected virtual void OnDeactivate()
        {
            
        }

    }
}