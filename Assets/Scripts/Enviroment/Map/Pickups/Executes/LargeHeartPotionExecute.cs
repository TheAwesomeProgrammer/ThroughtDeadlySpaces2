using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Pickups.PickupExecutes
{
    public class LargeHeartPotionExecute : Executeable
    {
        public void Execute(GameObject gameObject)
        {
            Life life = gameObject.GetComponent<Life>();
            life.Health = life.MaxHealth;
        }
    }
}