﻿using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Player.Equipments.Attributes;
using Assets.Scripts.Player.Swords.Abstract;
using UnityEngine;

namespace Assets.Scripts.Player.Curses
{
    [EquipmentAttributeMetaData(EquipmentAttributeType.Curse)]
    public class MinusMaxHpCurse : EquipmentAttribute
    {
        public const int MaxHpToLose = 1;

        public override AttributeXmlData AttributeXmlData
        {
            get { return null; }
        }

        protected override void Activate()
        {
            PlayerProperties playerProperties = GameObject.FindGameObjectWithTag(Tag.Player).GetComponent<PlayerProperties>();
            playerProperties.MaxHealth -= MaxHpToLose;
            Destroy(this);
        }
    }
}