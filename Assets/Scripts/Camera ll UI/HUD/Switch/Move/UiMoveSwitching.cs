using System;
using System.Collections.Generic;
using Assets.Scripts.Extensions;

namespace Assets.Scripts.Camera_ll_UI.HUD
{
    public class UiMoveSwitching : MoveSwitcher
    {
        public SwitchType SwitchType;

        private List<UiMover> _uiMoversWithId;
        private UIManager _uiManager;
        private int _uiMoverReachedTargetCount;
        private Action<int> _callback;

        public void Start()
        {
            _uiManager = GetComponentInParent<UIManager>();
            _uiMoversWithId = _uiManager.GetItemsWithTypeAndId<UiMover>((int)SwitchType);
            _uiMoversWithId.ForEach(CountReachedUiMovers);
        }

        public void ForEachOnUiMover(Action<UiMover> action)
        {
            _uiMoversWithId.ForEach(action);
        }

        private void Reset()
        {
            _uiMoverReachedTargetCount = 0;
        }

        private void SetCallback(Action<int> callback)
        {
            _callback = callback;
        }

        protected override void MoveTo(Action<int> callback)
        {
            _uiMoversWithId.ForEach(MoveUiMoverTo);
            SetCallback(callback);
        }

        private void MoveUiMoverTo(UiMover uiMover)
        {
            uiMover.Show();
        }

        protected override void MoveBack(Action<int> callback)
        {
            _uiMoversWithId.ForEach(MoveUiMoverBack);
            SetCallback(callback);
        }

        private void MoveUiMoverBack(UiMover uiMover)
        {
            uiMover.Hide();
        }

        private void CountReachedUiMovers(UiMover uiMover)
        {
            uiMover.OnMoved += CountUp;
        }

        private void CountUp()
        {
            _uiMoverReachedTargetCount++;
            ShouldReset();
        }

        private void ShouldReset()
        {
            if (_uiMoverReachedTargetCount >= _uiMoversWithId.Count)
            {
                Reset();
                Moved = !Moved;
                _callback.CallIfNotNull((int)SwitchType);
            }
        }
    }
}