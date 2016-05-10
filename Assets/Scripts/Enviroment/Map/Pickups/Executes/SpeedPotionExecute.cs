using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Pickups.PickupExecutes
{
    public class SpeedPotionExecute : Executeable
    {
        private float _speed;

        public SpeedPotionExecute(float speed)
        {
            _speed = speed;
        }

        public void Execute(GameObject gameObject)
        {
            PlayerProperties playerProperties = gameObject.GetComponentInParent<PlayerProperties>();
            playerProperties.Speed += _speed;
        }
    }
}