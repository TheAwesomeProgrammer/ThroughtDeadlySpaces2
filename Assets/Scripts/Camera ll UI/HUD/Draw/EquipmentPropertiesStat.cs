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
    public class EquipmentPropertiesStat : PropertyStat
    {
        public EquipmentType EquipmentType;

        protected override void Init()
        {
            _typeToLoad = typeof(EquipmentSpecs);
        }

        protected override void LoadPropertyObject()
        {
            StartCoroutine(LoadEquipment());
        }

        private IEnumerator LoadEquipment()
        {
            bool isEquipmentNull = true;

            while (isEquipmentNull)
            {
                switch (EquipmentType)
                {
                    case EquipmentType.Sword:
                        Sword sword =
                            GameObject.FindGameObjectWithTag(Tag.Player).GetComponentInChildren<SwordManager>().GetPrimarySword();
                        if (sword != null)
                        {
                            _propertyObject = sword.Specs;
                        }
                        break;
                    case EquipmentType.Armor:
                        _propertyObject = GetEquipment<Armor>();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                if (_propertyObject != null)
                {
                    isEquipmentNull = false;
                }
                yield return null;
            }
        }

        private EquipmentSpecs GetEquipment<T>() where T : Equipment
        {
            return GameObject.FindGameObjectWithTag(Tag.Player).GetComponentInChildren<T>().Specs;
        }
    }
}