using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Combat;
using Assets.Scripts.Extensions;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Swords.Abstract;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    public abstract class Sword : Equipment
    {
        public int SwordId = 1;

        protected SwordXmlLoader _swordXmlLoader;
        protected AttributeManager _swordAttributeManager;

        public void Awake()
        {
            _swordAttributeManager = GetComponent<AttributeManager>();
            _swordXmlLoader = new SwordXmlLoader(_swordAttributeManager, SwordId, "Swords");
            _swordXmlLoader.Load();
            GetComponent<SwordAttack>().AttackStarted += OnUse;
            Specs = _swordXmlLoader.EquipmentSpecs;
        }

        void OnDestroy()
        {
            _swordAttributeManager.RemoveComponents();
        }
    }
}