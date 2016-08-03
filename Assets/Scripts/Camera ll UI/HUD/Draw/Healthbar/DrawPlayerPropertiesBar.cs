using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Camera_ll_UI.HUD
{
    public class DrawPlayerPropertiesBar : DrawBar<PlayerPropertiesStat>
    {
        public PlayerPropertiesStat CurrentPlayerPropertiesStat;
        public PlayerPropertiesStat MaxPlayerPropertiesStat;

        protected override void LoadObjectStats()
        {
            _currentObjectStat = CurrentPlayerPropertiesStat;
            _maxObjectStat = MaxPlayerPropertiesStat;
        }
    }
}