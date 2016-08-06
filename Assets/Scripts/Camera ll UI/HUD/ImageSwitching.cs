using Assets.Scripts.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Camera_ll_UI.HUD
{
    public class ImageSwitching : MonoBehaviour
    {
        public Sprite[] Sprites;

        private Image _image;

        public void Start()
        {
            _image = GetComponent<Image>();
        }

        public void SetIndex(int index)
        {
            Null.OnNot(_image, () => _image.sprite = Sprites[index]);
        }
    }
}