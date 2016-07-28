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
            SwordManager swordManager = gameObject.GetComponentInChildren<SwordManager>();
            GameObject swordObject = swordManager.gameObject;
            Object.Destroy(swordManager);
            swordObject.SetActive(false);
            Sword newSword = swordManager.AddNewComponent<DefaultSword>();
            newSword.Load(_swordId);
            swordObject.SetActive(true);
        }
    }
}