using Assets.Scripts.Player;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Camera_ll_UI.HUD
{
    public abstract class DrawBar<TStat> : MonoBehaviour where TStat : PropertyStat
    {
        protected TStat _maxObjectStat;
        protected TStat _currentObjectStat;

        protected Image _image;

        public void Start()
        {
            _image = GetComponent<Image>();
            LoadObjectStats();
        }

        protected abstract void LoadObjectStats();

        public virtual void Update()
        {
            _image.fillAmount = _currentObjectStat.FloatValue / _maxObjectStat.FloatValue;
        }
    }
}