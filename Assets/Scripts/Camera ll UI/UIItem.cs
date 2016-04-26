using UnityEngine;

namespace Assets.Scripts.Camera_ll_UI
{
    public abstract class UIItem : MonoBehaviour
    {
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

        public abstract void SetProperties(params object[] properties);

        protected virtual void OnActivate()
        {
            
        }

        protected virtual void OnDeactivate()
        {
            
        }

    }
}