using Assets.Scripts.Shop;
using UnityEngine;

public class TestMoneyDrop : MonoBehaviour
{
    public MoneyDrop MoneyDrop;

    private int _moneyToChangeToPass;

    void Start()
    {
        MoneyManager.MoneyChanged += OnMoneyChanged;
        _moneyToChangeToPass = MoneyDrop.MoneyToGive;
    }

    void OnMoneyChanged(int moneyChanged)
    {
        if (moneyChanged == _moneyToChangeToPass)
        {
            IntegrationTest.Pass();
        }
        else
        {
            IntegrationTest.Fail();
        }
    }
}