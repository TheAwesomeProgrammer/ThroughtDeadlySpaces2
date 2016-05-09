using Assets.Scripts.Enviroment.Map.Pickups;
using Assets.Scripts.Enviroment.Map.Pickups.PickupExecutes;
using Assets.Scripts.Player.Swords.Abstract;
using Assets.Scripts.Shop;
using UnityEngine;

public class MoneyDrop : Pickup
{
    public int MoneyToGive;

    private MoneyExecute _moneyExecute;

    protected override void Start()
    {
        base.Start();
        _moneyExecute = new MoneyExecute(MoneyToGive);
    }

    protected override void OnPickup()
    {
        base.OnPickup();
        _moneyExecute.Execute(_player);
        Destroy(gameObject);
    }
}