using System.Collections.Generic;
using Assets.Scripts.Combat.Attack;
using Assets.Scripts.Extensions;
using UnityEngine;

namespace Assets.Scripts.Camera_ll_UI.HUD
{
    public class ShowWeakness : MonoBehaviour
    {
        public CombatType Weakness;

        private WeaknessProperty _weaknessProperty;

        public void Start()
        {
            _weaknessProperty = GetComponent<WeaknessProperty>();
        }

        public void Update()
        {
            List<object> weaknesses = _weaknessProperty.ListValue;
            Null.OnNot(weaknesses, () => ShouldShow(weaknesses));
        }

        private void ShouldShow(List<object> weaknesses)
        {
            if (weaknesses.Exists(item => item.Equals(Weakness)))
            {
                Show();
            }
            else
            {
                Hide();
            }
        }

        private void Show()
        {
            gameObject.SetActive(true);
        }

        private void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}