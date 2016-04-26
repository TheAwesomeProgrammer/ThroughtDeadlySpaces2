using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Pickups.Potions
{
    public class SpeedPotion : Trigger
    {
        public float SpeedToGive = 1;

        protected override void Start()
        {
            base.Start();
            Tags.Add("Player");
        }

        public override void OnEnter()
        {
            base.OnEnter();
            PlayerProperties playerProperties = _triggerCollider.GetComponent<PlayerProperties>();
            playerProperties.Speed += SpeedToGive;
        }
    }
}