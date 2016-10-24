using System;
using System.Collections;
using Assets.Scripts.Player.Armors;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Swords;
using Assets.Scripts.Player.Swords.Abstract;
using Assets.Scripts.Shop;
using UnityEngine;

namespace Assets.Scripts.Camera_ll_UI.HUD
{
    public class EquipmentSpecsPropertiesStat : PropertyStat
    {
        public EquipmentType EquipmentType;

        private EquipmentFinder _equipmentFinder;
	    private Equipment _currentEquipment;

        public override void Start()
        {
            _equipmentFinder = new EquipmentFinder();
            base.Start();
        }

        protected override void SetType()
        {
            _typeToLoad = typeof(EquipmentSpecs);
        }

        protected override void LoadPropertyObject()
        {
            StartCoroutine(_equipmentFinder.LoadEquipment(LoadEquipment, EquipmentType));
        }

        private void LoadEquipment(Equipment equipment)
        {
	        SetPropertyObject(equipment);
        }

	    private void SetPropertyObject(Equipment equipment)
	    {
			_propertyObject = equipment.Specs;
		    equipment.EquipmentChanged += SetPropertyObject;
	    }
    }
}