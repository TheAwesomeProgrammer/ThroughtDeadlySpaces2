using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Pickups.PickupExecutes
{
    public class ArmorExecute : Executeable
    {
        public void Execute(GameObject gameObject)
        {
            Resistance resistance = gameObject.GetComponentInChildren<Resistance>();
            GameObject resistanceObject = resistance.gameObject;
            Object.Destroy(resistance);
            resistanceObject.SetActive(false);
            resistance = resistanceObject.AddComponent<Resistance>();
            resistanceObject.SetActive(true);
        }
    }
}