using System;
using Assets.Scripts.Player.Swords;
using UnityEngine;

namespace Assets.Scripts.Player.Equipments
{
    public class Equipment : MonoBehaviour
    {
        public bool Broken { get; private set; }

        private EquipmentBrokenState _equipmentBrokenState;
        public EquipmentSpecs Specs { get; set; }

        protected virtual void Start()
        {
            _equipmentBrokenState = new EquipmentBrokenState(gameObject, this);
            _equipmentBrokenState.Breaking += () => Broken = true;
        }

        public void Repair()
        {
            Broken = false;
            _equipmentBrokenState.Reset();
        }

        protected virtual void OnUse()
        {
            _equipmentBrokenState.OnHit();
        }
    }
}