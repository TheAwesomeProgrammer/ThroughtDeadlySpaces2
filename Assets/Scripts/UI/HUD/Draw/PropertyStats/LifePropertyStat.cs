using Assets.Scripts.Extensions;
using UnityEngine;

namespace Assets.Scripts.Camera_ll_UI.HUD
{
    public class LifePropertyStat : PropertyStat
    {
        public string LifeTag;

        protected override void SetType()
        {
            _typeToLoad = typeof(Life);
        }

        protected override void LoadPropertyObject()
        {
            GameObject lifeObject = GameObject.FindGameObjectWithTag(LifeTag);
            Null.OnNot(lifeObject, () => _propertyObject = lifeObject.GetComponentInChildren<Life>());
        }
    }
}