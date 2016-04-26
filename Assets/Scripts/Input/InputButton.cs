using System;
using TeamUtility.IO;
using UnityEngine;

namespace Assets.Scripts.Input
{
    public class InputButton : MonoBehaviour
    {
        public string[] ButtonNames;

        public event Action ButtonDown;
        public event Action ButtonPressed;
        public event Action ButtonUp;

        void Update()
        {
            foreach (var buttonName in ButtonNames)
            {
                CheckInput(buttonName);
            }
        }

        private void CheckInput(string buttonName)
        {
            if (InputManager.GetButtonDown(buttonName) && ButtonDown != null)
            {
                ButtonDown();
            }
            else if (InputManager.GetButtonUp(buttonName) && ButtonUp != null)
            {
                ButtonUp();
            }
            if (InputManager.GetButton(buttonName) && ButtonPressed != null)
            {
                ButtonPressed();
            }
        }
    }
}