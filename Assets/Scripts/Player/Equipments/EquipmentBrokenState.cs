using System;
using Assets.Scripts.Enviroment.Map.Pickups.PickupExecutes;
using Assets.Scripts.Player.Swords;
using Assets.Scripts.Shop;
using UnityEngine;

namespace Assets.Scripts.Player.Equipments
{
    public class EquipmentBrokenState
    {
        public int HitsForBrokenEquipment = 50;
        public event Action Breaking;

        private int _equipmentState;
        private GameObject _ownerGameObject;
        private Equipment _equipment;
        private BreakingFactory _breakingFactory;
             

        public EquipmentBrokenState(GameObject ownerGameObject, Equipment equipment)
        {
            _ownerGameObject = ownerGameObject;
            _equipment = equipment;
            _equipmentState = HitsForBrokenEquipment;
            _breakingFactory = new BreakingFactory();
        }

        public void Reset()
        {
            _equipmentState = HitsForBrokenEquipment;
        }

        public void OnHit()
        {
            _equipmentState--;
            ShouldBreak();
        }

        void ShouldBreak()
        {
            if (_equipmentState <= 0)
            {
                Break();
            }
        }

        void Break()
        {
            if (!_equipment.Broken)
            {
                if (Breaking != null)
                {
                    Breaking();
                }
                Executeable executeable = _breakingFactory.GetBreakingExecuteable(_equipment);
                executeable.Execute(_ownerGameObject);
            }
        }
    }
}