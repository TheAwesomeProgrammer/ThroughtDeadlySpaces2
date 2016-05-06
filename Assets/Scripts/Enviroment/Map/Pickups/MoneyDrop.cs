using Assets.Scripts.Enviroment.Map.Pickups.PickupExecutes;
using Assets.Scripts.Shop;
using UnityEngine;

public class MoneyDrop : Trigger
{
    public int MoneyToGive;

    private MoneyExecute _moneyExecute;

    protected override void Start()
    {
        base.Start();
        Tags.Add("Player");
        _moneyExecute = new MoneyExecute(MoneyToGive);
    }

    public override void OnEnterWithTag()
    {
        base.OnEnterWithTag();
        _moneyExecute.Execute(_triggerCollider.gameObject);
        Destroy(gameObject);
    }
}