using System;
using System.Collections.Generic;
using Assets.Scripts.Extensions;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Shop;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Camera_ll_UI.HUD
{
    [Serializable]
    public class TextRow
    {
        private const int AttributesPerRow = 3;

        private Text _rowText;
        private int _elementsCount;

        public TextRow(Text rowText)
        {
            _rowText = rowText;
        }

        public bool TryAddText(string text)
        {
            if (HasReachedLimit() == false)
            {
                AddText(text);
                return true;
            }
            return false;
        }

        public void AddText(string text)
        {
            _elementsCount++;
            _rowText.text += text + Environment.NewLine;
        }

        public void Clear()
        {
            _rowText.text = "";
            _elementsCount = 0;
        }

        private bool HasReachedLimit()
        {
            return _elementsCount >= AttributesPerRow;
        }
    }

    public class ShowAttributeNames : MonoBehaviour
    {
        public EquipmentType EquipmentType;

        private EquipmentFinder _equipmentFinder;
        private EquipmentAttributeManager _equipmentAttributeManager;
        private List<TextRow> _textRows;
        private int _textRowIndex;
        private bool _hasOverflowed;
        private List<AttributeData> _attributes;

        public void Start()
        {
            _attributes = new List<AttributeData>();
            _equipmentFinder = new EquipmentFinder();
            UpdateAttributes();
            _textRows = new List<TextRow>();
            foreach (var text in GetComponentsInChildren<Text>())
            {
                _textRows.Add(new TextRow(text));
            }
        }

        public void Update()
        {
            UpdateAttributes();
            _hasOverflowed = false;
            foreach (var textRow in _textRows)
            {
                textRow.Clear();
                _textRowIndex = 0;
            }
            foreach (var attributeData in _attributes)
            {
                string attributeName = GetAttributeName(attributeData);
                if (string.IsNullOrEmpty(attributeName) == false)
                {
                    TextRow currentTextRow = GetCurrentTextRow();
                    TryAddText(currentTextRow, attributeName);
                }
            }
        }

        private void UpdateAttributes()
        {
            StartCoroutine(
                _equipmentFinder.LoadEquipment(OnLoadedEquipment, EquipmentType));
        }

        private void OnLoadedEquipment(Equipment equipment)
        {
            EquipmentAttributeManager equipmentAttributeManager = equipment.GetComponent<EquipmentAttributeManager>();
            _attributes =  equipmentAttributeManager.GetAttributesById(equipment.Id);
        }

        private void TryAddText(TextRow textRow, string text)
        {
            if (_hasOverflowed)
            {
                textRow.AddText(text);
                _textRowIndex++;
            }
            else if(textRow.TryAddText(text) == false)
            {
                _textRowIndex++;
            }
            if (_textRows.Count <= _textRowIndex)
            {
                _textRowIndex = 0;
                _hasOverflowed = true;
            }
        }

        private TextRow GetCurrentTextRow()
        {
            return _textRows[_textRowIndex];
        }

        private string GetAttributeName(AttributeData attributeData)
        {
            string attributeName = "";
            EquipmentAttribute attribute = attributeData.Attribute as EquipmentAttribute;
            Null.OnNot(attribute, () => attributeName = attribute.Name);
            return attributeName;
        }
    }
}