using System;
using System.Collections;
using Assets.Scripts.Extensions;
using Assets.Scripts.Player.Armors;
using Assets.Scripts.Player.Swords;
using Assets.Scripts.Player.Swords.Abstract;
using Assets.Scripts.Shop;
using UnityEngine;

namespace Assets.Scripts.Player.Equipments
{
    public class EquipmentFinder
    {
        // Remember to call with StartCorutine
        public IEnumerator LoadEquipment(Action<Equipment> result, EquipmentType equipmentType)
        {
            bool isEquipmentNull = true;
            Equipment equipment = null;

            while (isEquipmentNull)
            {
                switch (equipmentType)
                {
                    case EquipmentType.Sword:
                        SwordManager swordManager =
                            GameObject.FindGameObjectWithTag(Tag.Player).GetComponentInChildren<SwordManager>();
                        swordManager.GetPrimarySwordWhenLoaded((sword) => equipment = sword);
                        break;
                    case EquipmentType.Armor:
                        equipment = GetEquipment<Armor>();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                if (equipment != null)
                {
                    isEquipmentNull = false;
                }

                yield return null;
            }

	        result.CallIfNotNull(equipment);
        }

	    private Equipment GetEquipment<T>() where T : Equipment
        {
            return GameObject.FindGameObjectWithTag(Tag.Player).GetComponentInChildren<T>();
        }
    }
}