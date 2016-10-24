using System;
using Assets.Scripts.Camera_ll_UI.HUD;
using Assets.Scripts.Extensions;

namespace Assets.Scripts.Camera_ll_UI
{
    [Serializable]
    public class SwitchInfo
    {
        public int Id;
        public Switchable Switch;
        private readonly Action _callback;

        public SwitchInfo(int id, Switchable @switch, Action callback)
        {
            Id = id;
            Switch = @switch;
            _callback = callback;
        }

        public void Callback()
        {
            _callback.CallIfNotNull();
        }
    }
}