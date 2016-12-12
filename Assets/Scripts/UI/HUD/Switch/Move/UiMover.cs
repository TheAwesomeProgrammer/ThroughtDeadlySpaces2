using System;
using Assets.Scripts.Enviroment.Map.Bridge;
using Assets.Scripts.Extensions;
using Assets.Scripts.Extensions.Enums;
using UnityEngine;

namespace Assets.Scripts.Camera_ll_UI.HUD
{
    public class UiMover : UiItem
    {
        public event Action OnMoved;
        public SwitchType SwitchType;

        private MoveToPoint _moveToPoint;

        public void Start()
        {
            UiId = (int) SwitchType;
            _moveToPoint = GetComponent<MoveToPoint>();
            _moveToPoint.OnMoved += () => OnMoved.InvokeIfNotNull();
        }

        protected override void OnShow()
        {
            base.OnShow();
            _moveToPoint.Move(_moveToPoint.EndPoint);
        }

        protected override void OnHide()
        {
            base.OnHide();
            _moveToPoint.MoveToStartPosition();
        }
    }
}