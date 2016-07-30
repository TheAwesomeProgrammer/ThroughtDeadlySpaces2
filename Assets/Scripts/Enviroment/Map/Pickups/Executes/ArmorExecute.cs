using Assets.Scripts.Player.Armors;
using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Pickups.PickupExecutes
{
    public class ArmorExecute : Executeable
    {
        private int _armorId;

        public ArmorExecute(int armorId)
        {
            _armorId = armorId;
        }

        public void Execute(GameObject gameObject)
        {
            Armor armor = gameObject.GetComponentInChildren<Armor>();
            GameObject armorObject = armor.gameObject;
            Object.Destroy(armor);
            armorObject.SetActive(false);
            armor = armorObject.AddComponent<Armor>();
            armor.Load(_armorId);
            armorObject.SetActive(true);
        }
    }
}