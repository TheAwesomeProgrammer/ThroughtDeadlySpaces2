using Assets.Scripts.Player;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Camera_ll_UI.HUD
{
    public class DrawBar : MonoBehaviour
    {
        public PropertyStat MaxObjectStat;
        public PropertyStat CurrentObjectStat;

        protected Image _image;

        public void Start()
        {
            _image = GetComponent<Image>();
        }

        public virtual void Update()
        {
            if (CurrentObjectStat && MaxObjectStat)
            {
                _image.fillAmount = CurrentObjectStat.FloatValue / MaxObjectStat.FloatValue;
            }
        }
    }
}