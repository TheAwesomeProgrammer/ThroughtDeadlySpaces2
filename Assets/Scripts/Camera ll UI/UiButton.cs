using Assets.Scripts.Camera_ll_UI;
using Assets.Scripts.Enviroment.Map.Rooms;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Quest
{
    public class UiButton : Button
    {
        protected override void Start()
        {
            base.Start();
            onClick.AddListener(OnClick);
        }

        public override void OnSubmit(BaseEventData eventData)
        {
            base.OnSubmit(eventData);
            OnClick();
        }

        public override void OnSelect(BaseEventData eventData)
        {
            base.OnSelect(eventData);
            OnEnter(eventData);
        }

        public override void OnDeselect(BaseEventData eventData)
        {
            base.OnDeselect(eventData);
            OnExit(eventData);
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);
            OnEnter(eventData);
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            base.OnPointerExit(eventData);
            OnExit(eventData);
        }

        protected virtual void OnClick()
        {

        }

        protected virtual void OnEnter(BaseEventData eventData)
        {
            
        }

        protected virtual void OnExit(BaseEventData eventData)
        {
            
        }
    }
}