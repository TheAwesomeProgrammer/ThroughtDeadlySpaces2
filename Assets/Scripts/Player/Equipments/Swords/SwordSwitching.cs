using Assets.Scripts.Input;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    public class SwordSwitching : MonoBehaviour
    {
        private SwordManager _swordManager;
        private InputButton _inputButton;

        public void Start()
        {
            _swordManager = GetComponentInParent<SwordManager>();
            _inputButton = GetComponentInChildren<InputButton>();
            _inputButton.ButtonDown += OnSwitchSword;
        }

        public void OnSwitchSword()
        {
            _swordManager.SwitchSword();
        }
    }
}