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
        private EquipmentAttributeManager _equipmentAttributeManager;

        protected override void Start()
        {
            base.Start();
            _equipmentAttributeManager = GetComponent<EquipmentAttributeManager>();
            GetComponent<Resistance>().Defending += OnUse;
            _armorXmlLoader = new ArmorXmlLoader(_equipmentAttributeManager, transform.root.FindComponentInChildWithName<EquipmentAttributeManager>("Sword"), ArmorId, "Armors");
            _armorXmlLoader.Load();
            Specs = _armorXmlLoader.EquipmentSpecs;
        }

        void OnDestroy()
        {
            _equipmentAttributeManager.RemoveComponents();
        }
    }
}