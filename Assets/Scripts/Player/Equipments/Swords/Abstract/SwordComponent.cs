using Assets.Scripts.Player.Equipments;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    public abstract class SwordComponent : MonoBehaviour
    {
        protected AttributeManager _swordAttributeManager;
        protected Sword _sword;

        protected virtual void Start()
        {
            _swordAttributeManager = GetComponent<AttributeManager>();
            _sword = GetComponent<Sword>();

        }

    }
}