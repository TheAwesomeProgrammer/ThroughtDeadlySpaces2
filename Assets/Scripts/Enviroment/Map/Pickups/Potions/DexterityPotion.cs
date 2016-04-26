using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Pickups.Potions
{
    public class DexterityPotion : Trigger
    {
        public float DexterityToGive;

        protected override void Start()
        {
            base.Start();
            Tags.Add("Player");
        }

        public override void OnEnter()
        {
            base.OnEnter();
            PlayerProperties playerProperties = _triggerCollider.GetComponent<PlayerProperties>();
            playerProperties.Dexterity += DexterityToGive;
        }
    }
}