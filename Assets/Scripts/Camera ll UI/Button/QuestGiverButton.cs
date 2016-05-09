using Assets.Scripts.Camera_ll_UI;
using Assets.Scripts.Enviroment.Map.InputInteractables;
using Assets.Scripts.Enviroment.Map.Rooms;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Quest
{
    public class QuestGiverButton : UiButton
    {
        private QuestGiverManager _questGiverManager;
        private UiItem _uiItem;
        private UIManager _uiManager;
        private Map _map;

        protected override void Start()
        {
            base.Start();
            _uiItem = GetComponentInParent<UiItem>();
            _questGiverManager = GameObject.FindGameObjectWithTag("QuestGiverManager").GetComponent<QuestGiverManager>();
            _uiManager = Camera.main.GetComponent<UIManager>();
            _map = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>();
        }

        protected override void OnClick()
        {
            base.OnClick();
            HideAndSetActive();
            UnlockDoorInActiveRoom();
            SetInteractableToUsed();
        }

        private void UnlockDoorInActiveRoom()
        {
            Room activeRoom = _map.GetActiveRoom();
            Door door = activeRoom.GetComponentInChildren<Door>();
            door.UnLock();
        }

        private void HideAndSetActive()
        {
            UiQuestGiver uiQuestGiver = (UiQuestGiver) _uiItem;
            uiQuestGiver.SetActiveQuestGiver(_questGiverManager);
            _uiManager.DeactivateItemWithType<UiQuestGiver>();
        }

        protected override void OnEnter(BaseEventData eventData)
        {
            base.OnEnter(eventData);
            targetGraphic.color = new Color(targetGraphic.color.r, targetGraphic.color.g, targetGraphic.color.b, 0);
        }

        protected override void OnExit(BaseEventData eventData)
        {
            base.OnExit(eventData);
            targetGraphic.color = new Color(targetGraphic.color.r, targetGraphic.color.g, targetGraphic.color.b, 0.5f);
        }

        private void SetInteractableToUsed()
        {
            Room activeRoom = _map.GetActiveRoom();
            QuestGiverInteractable questGiverInteractable = activeRoom.GetComponentInChildren<QuestGiverInteractable>();
            questGiverInteractable.OnUsedInteractable();
        }
    }
}