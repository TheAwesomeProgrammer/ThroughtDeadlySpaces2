using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Combat;
using Assets.Scripts.Extensions;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Swords.Abstract;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    public abstract class Sword : Equipment, EquipmentLoadable
    {
        public bool DeactivateAfterLoad;

        protected SwordXmlLoader _swordXmlLoader;
        protected EquipmentAttributeManager _equipmentAttributeManager;
        protected SwordAttack _swordAttack;
        private bool _hasLoaded;

        protected override void Awake()
        {
            base.Awake();
            _equipmentAttributeManager = gameObject.AddComponentIfNotExist<EquipmentAttributeManager>();
            _swordAttack = GetComponent<SwordAttack>();
            _swordAttack.AttackStarted += OnUse;
        }

        public void Load(int swordId)
        {
            _swordXmlLoader = new SwordXmlLoader(_equipmentAttributeManager, swordId, Id);
            _swordXmlLoader.Load();
            Specs = _swordXmlLoader.EquipmentSpecs;
            UpdateSword();
            _hasLoaded = true;
            if (DeactivateAfterLoad)
            {
                enabled = false;
                DeactivateAfterLoad = false;
            }
        }

        void OnDestroy()
        {
            _equipmentAttributeManager.RemoveAllWithId(Id);
        }

        void OnDisable()
        {
            _equipmentAttributeManager.DisableAllWithId(Id);
        }

        private void UpdateSword()
        {
            _swordAttack.SetSword(this);
            _swordAttack.SetupDamageDatas();
        }

        void OnEnable()
        {
            _equipmentAttributeManager.EnableAllWithId(Id);
            if (_hasLoaded)
            {
                UpdateSword();
            }
        }
    }
}