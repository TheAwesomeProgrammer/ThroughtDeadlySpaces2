using System;
using Assets.Scripts.Enviroment.Map.Pickups.PickupExecutes;
using UnityEngine;
using UnityTest;

public class SmallHeartPotion : Trigger
{
    public int HealthToGive = 2;

    private SmallHeartPotionExecute _smallHeartPotionExecute;

    protected override void Start()
    {
        base.Start();
        Tags.Add("Debug");
        _smallHeartPotionExecute = new SmallHeartPotionExecute(HealthToGive);
    }

    public override void OnEnterWithTag()
    {
        base.OnEnterWithTag();
        _smallHeartPotionExecute.Execute(_triggerCollider.gameObject);
        Destroy(gameObject);
    }
}