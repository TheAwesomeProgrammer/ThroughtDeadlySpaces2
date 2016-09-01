using System.Xml;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Swords;
using Assets.Scripts.Player.Swords.Abstract;
using XmlLibrary;
using UnityEngine;

namespace Assets.Scripts.Player.Armors
{
    public abstract class Armor : Equipment, EquipmentLoadable
    {
        private ArmorXmlLoader _armorXmlLoader;
        private EquipmentAttributeManager _equipmentAttributeManager;
        private Resistance _resistance;

        protected void Start()
        {
            _resistance = GetComponent<Resistance>();
            _equipmentAttributeManager = gameObject.AddComponentIfNotExist<EquipmentAttributeManager>();
            GetComponent<Resistance>().Defending += OnUse;
            Load(1);
        }

        void OnDestroy()
        {
            _equipmentAttributeManager.RemoveComponents();
        }

        public void Load(int armorId)
        {
            _armorXmlLoader = new ArmorXmlLoader(_equipmentAttributeManager, armorId, Id);
            _armorXmlLoader.Load();
            Specs = _armorXmlLoader.EquipmentSpecs;
            _resistance.SetupDefenseDamageDatas();
        }
    }
}