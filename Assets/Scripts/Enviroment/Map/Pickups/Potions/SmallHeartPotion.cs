using System;
using Assets.Scripts.Enviroment.Map.Pickups;
using Assets.Scripts.Enviroment.Map.Pickups.PickupExecutes;
using UnityEngine;
using UnityTest;

public class SmallHeartPotion : Pickup
{
    public int HealthToGive = 2;

    private SmallHeartPotionExecute _smallHeartPotionExecute;

    protected override void Start()
    {
        base.Start();
        _smallHeartPotionExecute = new SmallHeartPotionExecute(HealthToGive);
    }

    protected override void OnPickup()
    {
        base.OnPickup();
        _smallHeartPotionExecute.Execute(_player);
    }
}