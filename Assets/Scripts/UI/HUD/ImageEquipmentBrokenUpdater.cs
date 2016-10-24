using System;
using Assets.Scripts.Extensions;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Shop;
using UnityEngine;

namespace Assets.Scripts.Camera_ll_UI.HUD
{
    public class ImageEquipmentBrokenUpdater : MonoBehaviour
    {
        public EquipmentType EquipmentType;

        private const int BrokenIndex = 1;
        private const int UnBrokenIndex = 0;

        private ImageSwitching _imageSwitching;
        private Equipment _equipment;
        private EquipmentFinder _equipmentFinder;

        public void Start()
        {
            _equipmentFinder = new EquipmentFinder();
            _imageSwitching = GetComponent<ImageSwitching>();
            _equipment = GetEquipment(EquipmentType);
        }

        private Equipment GetEquipment(EquipmentType equipmentType)
        {
            Equipment equipment = null;
            StartCoroutine(_equipmentFinder.LoadEquipment((item) => equipment = item, equipmentType));
            return equipment;
        }

        public void Update()
        {
            CheckEquipmentState();
        }

        private void CheckEquipmentState()
        {
            Null.OnNot(_equipment, () => _imageSwitching.SetIndex(_equipment.Broken ? BrokenIndex : UnBrokenIndex));
        }
    }
}