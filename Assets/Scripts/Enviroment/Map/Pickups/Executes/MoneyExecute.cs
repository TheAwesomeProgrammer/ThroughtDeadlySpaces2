using Assets.Scripts.Shop;
using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Pickups.PickupExecutes
{
    public class MoneyExecute : Executeable
    {
        private int _money;

        public MoneyExecute(int money)
        {
            _money = money;
        }

        public void Execute(GameObject gameObject)
        {
            MoneyManager.Money += _money;
        }
    }
}