using Assets.Scripts.Shop;
using UnityEngine;

public class MoneyDrop : Trigger
{
    public int MoneyToGive;

    protected override void Start()
    {
        base.Start();
        Tags.Add("Player");
    }

    public override void OnEnter()
    {
        base.OnEnter();
        MoneyManager.Money += MoneyToGive;
        Destroy(gameObject);
    }
}