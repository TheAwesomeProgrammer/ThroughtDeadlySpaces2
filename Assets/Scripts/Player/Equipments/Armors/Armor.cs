using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Swords;
using Assets.Scripts.Player.Swords.Abstract;
using UnityEngine;

namespace Assets.Scripts.Player.Armors
{
    public abstract class Armor : Equipment
    {
        public int ArmorId = 1;

        private ArmorXmlLoader _armorXmlLoader;
        private AttributeManager _attributeManager;

        protected override void Start()
        {
            base.Start();
            _attributeManager = GetComponent<AttributeManager>();
            GetComponent<Resistance>().Defending += OnUse;
            _armorXmlLoader = new ArmorXmlLoader(_attributeManager, transform.root.FindComponentInChildWithName<AttributeManager>("Sword"), ArmorId, "Armors");
            _armorXmlLoader.Load();
            Specs = _armorXmlLoader.EquipmentSpecs;
        }

        void OnDestroy()
        {
            _attributeManager.RemoveComponents();
        }
    }
}