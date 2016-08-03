using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Camera_ll_UI.HUD
{
    public class ShowTextWithMaxCurrent : MonoBehaviour
    {
        public PlayerPropertiesStat Current;
        public PlayerPropertiesStat Max;

        private Text _text;

        public void Start()
        {
            _text = GetComponent<Text>();
        }

        public void Update()
        {
            _text.text = Current.StringValue + "/" + Max.StringValue;
        }
    }
}