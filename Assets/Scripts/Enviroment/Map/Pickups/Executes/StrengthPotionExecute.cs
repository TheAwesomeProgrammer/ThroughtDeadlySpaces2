using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Pickups.PickupExecutes
{
    public class StrengthPotionExecute : Executeable
    {
        private int _strength;

        public StrengthPotionExecute(int strength)
        {
            _strength = strength;
        }

        public void Execute(GameObject gameObject)
        {
            PlayerProperties playerProperties = gameObject.GetComponent<PlayerProperties>();
            playerProperties.Strength += _strength;
        }
    }
}