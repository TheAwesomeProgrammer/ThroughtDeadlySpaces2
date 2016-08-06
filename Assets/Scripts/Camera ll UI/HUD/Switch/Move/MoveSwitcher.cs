using System;
using UnityEngine;

namespace Assets.Scripts.Camera_ll_UI.HUD
{
    public abstract class MoveSwitcher : MonoBehaviour, Switchable
    {
        protected bool _moved;

        public void Switch(Action<int> callback)
        {
            if (_moved)
            {
                MoveBack(callback);
            }
            else
            {
                MoveTo(callback);
            }
        }

        protected abstract void MoveTo(Action<int> callback);

        protected abstract void MoveBack(Action<int> callback);
    }
}