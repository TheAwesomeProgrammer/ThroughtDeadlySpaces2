using UnityEngine;

namespace Assets.Scripts.Shop.BlackSmith
{
    public class RepairUiElement
    {
        protected EquipmentFactory _equipmentFactory;
        protected RarityMoneyLoaderFactory _moneyLoaderFactory;

        public RepairUiElement()
        {
            _equipmentFactory = new EquipmentFactory();
            _moneyLoaderFactory = new RarityMoneyLoaderFactory();
        }
    }
}