using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Pickups.PickupExecutes
{
    public class SmallHeartPotionExecute : Executeable
    {
        private int _healthToGive;

        public SmallHeartPotionExecute(int healthToGive)
        {
            _healthToGive = healthToGive;
        }

        public void Execute(GameObject gameObject)
        {
            Life life = gameObject.GetComponent<Life>();
            life.Health += _healthToGive;
        }
    }
}