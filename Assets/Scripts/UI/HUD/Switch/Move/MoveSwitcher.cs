using System;
using UnityEngine;

namespace Assets.Scripts.Camera_ll_UI.HUD
{
    public abstract class MoveSwitcher : MonoBehaviour, Switchable
    {
        public bool Moved;

        public void Switch(Action<int> callback)
        {
            if (Moved)
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