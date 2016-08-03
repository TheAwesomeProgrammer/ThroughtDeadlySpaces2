using Assets.Scripts.Player;
using Assets.Scripts.Player.Swords.Abstract;
using UnityEngine;

namespace Assets.Scripts.Camera_ll_UI.HUD
{
    public class PlayerPropertiesStat : PropertyStat
    {
        protected override void Init()
        {
            _typeToLoad = typeof(PlayerProperties);
        }

        protected override void LoadPropertyObject()
        {
            _propertyObject = GameObject.FindGameObjectWithTag(Tag.Player).GetComponent<PlayerProperties>();
        }
    }
}