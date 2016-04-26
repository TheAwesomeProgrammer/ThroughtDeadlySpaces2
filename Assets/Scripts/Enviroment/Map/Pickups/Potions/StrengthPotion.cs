using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Pickups.Potions
{
    public class StrengthPotion : Trigger
    {
        public int StrengthToGive = 1;

        protected override void Start()
        {
            base.Start();
            Tags.Add("Player");
        }

        public override void OnEnter()
        {
            base.OnEnter();
            PlayerProperties playerProperties = _triggerCollider.GetComponent<PlayerProperties>();
            playerProperties.Strength += StrengthToGive;
        }
    }
}