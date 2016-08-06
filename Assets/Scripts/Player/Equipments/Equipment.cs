using System;
using Assets.Scripts.Extensions.StaticClasses;
using Assets.Scripts.Player.Swords;
using UnityEngine;

namespace Assets.Scripts.Player.Equipments
{
    public class Equipment : MonoBehaviour
    {
        public bool Broken { get; private set; }

        public bool Damaged
        {
            get { return _equipmentBrokenState.Damaged; }
        }

        public int BrokenState
        {
            get { return _equipmentBrokenState.EquipmentState; }
        }

        public int HitsForBrokenEquipment
        {
            get { return _equipmentBrokenState.HitsForBrokenEquipment; }
        }

        public EquipmentSpecs Specs { get; set; }

        protected int Id;

        private EquipmentBrokenState _equipmentBrokenState;

        protected virtual void Awake()
        {
            Id = IdGenerator.GetId();
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