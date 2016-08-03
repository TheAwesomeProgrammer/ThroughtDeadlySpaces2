using System;

namespace Assets.Scripts.Camera_ll_UI.HUD
{
    public interface Switchable
    {
        void Switch(Action<int> callback);
    }
}