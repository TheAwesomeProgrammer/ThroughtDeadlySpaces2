using Assets.Scripts.Player.Swords;
using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Pickups.PickupExecutes
{
    public class SwordExecute : Executeable
    {
        private int _swordId;

        public SwordExecute(int swordId)
        {
            _swordId = swordId;
        }

        public void Execute(GameObject gameObject)
        {
            Sword playerSword = gameObject.transform.root.GetComponentInChildren<Sword>();
            GameObject swordObject = playerSword.gameObject;
            Object.Destroy(playerSword);
            swordObject.SetActive(false);
            Sword newSword = swordObject.AddComponent<DefaultSword>();
            newSword.SwordId = _swordId;
            swordObject.SetActive(true);
        }
    }
}