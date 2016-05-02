﻿using Assets.Scripts.Extensions.Math;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Player.Armors.Curses
{
    public class ArmorRustyCurse : ArmorComponent, XmlLoadable
    {
        private const int CurseId = 3;

        private Resistance _resistance;
        private XmlSearcher _xmlSearcher;
        private int _procentChanceToBreak;

        void Start()
        {
            _xmlSearcher = new XmlSearcher(Location.Curse);
            _resistance = GetComponent<Resistance>();
            _resistance.Defending += OnDefending;
            LoadXml();
        }

        void OnDefending()
        {
            if (MathHelper.IsBetweenRandomProcentFrom0To100(_procentChanceToBreak))
            {
                gameObject.AddComponent<ArmorBrokenCurse>();
                Destroy(this);
            }
        }

        public void LoadXml()
        {
            _procentChanceToBreak = _xmlSearcher.GetSpecsInChildrenWithId(CurseId, "Curses")[0];
        }
    }
}