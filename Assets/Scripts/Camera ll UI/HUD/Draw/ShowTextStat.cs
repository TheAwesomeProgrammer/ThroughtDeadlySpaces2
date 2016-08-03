using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Camera_ll_UI.HUD
{
    public class ShowTextStat : MonoBehaviour
    {
        private PropertyStat _propertyStat;
        private Text _text;

        public void Start()
        {
            _propertyStat = GetComponent<PropertyStat>();
            _text = GetComponent<Text>();
        }

        public void Update()
        {
            _text.text = _propertyStat.StringValue;
        }
    }
}