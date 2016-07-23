using Assets.Scripts.Player.Equipments;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    public abstract class SwordComponent : MonoBehaviour
    {
        protected EquipmentAttributeManager _swordEquipmentAttributeManager;
        protected Sword _sword;

        protected virtual void Start()
        {
            _swordEquipmentAttributeManager = GetComponent<EquipmentAttributeManager>();
            _sword = GetComponent<Sword>();
        }
    }
}