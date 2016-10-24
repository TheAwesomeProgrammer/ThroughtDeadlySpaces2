using System;
using System.Collections.Generic;
using Assets.Scripts.Extensions;
using Assets.Scripts.Player.Equipments;
using Assets.Scripts.Shop;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Camera_ll_UI.HUD
{
    public class ShowAttributeNames : MonoBehaviour
    {
        public EquipmentType EquipmentType;

        private EquipmentFinder _equipmentFinder;
        private EquipmentAttributeManager _equipmentAttributeManager;
        private List<TextRow> _textRows;
        private int _textRowIndex;
	    private int _attributesAdded;
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

	    private void UpdateAttributes()
	    {
		    StartCoroutine(
			    _equipmentFinder.LoadEquipment(OnLoadedEquipment, EquipmentType));
	    }

	    private void OnLoadedEquipment(Equipment equipment)
	    {
		    SetAttributes(equipment);
	    }

	    private void SetAttributes(Equipment equipment)
	    {
		    EquipmentAttributeManager equipmentAttributeManager = equipment.GetComponent<EquipmentAttributeManager>();
		    _attributes = equipmentAttributeManager.GetAttributesById(equipment.Id);
		    equipment.EquipmentChanged += SetAttributes;
	    }

	    public void Update()
        {
			ResetTextRows();
	        UpdateTextRows();
        }

	    private void ResetTextRows()
	    {
		    _hasOverflowed = false;
		    _attributesAdded = 0;
		    foreach (var textRow in _textRows)
		    {
			    textRow.Clear();
			    _textRowIndex = 0;
		    }
	    }

	    private void UpdateTextRows()
	    {
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

        private void TryAddText(TextRow textRow, string text)
        {
	        _attributesAdded++;
	        if (textRow.TryAddText(text, IsNotLastRow()) == false || _hasOverflowed)
            {
	            NextTextRow();
	            textRow.AddText(text, IsNotLastRow());
            }
	        ShouldOverflow();
        }

	    private void NextTextRow()
	    {
		    _textRowIndex++;
	    }

	    private bool IsNotLastRow()
	    {
		    return _attributes.Count > _attributesAdded;
	    }

	    private void ShouldOverflow()
	    {
		    if (_textRows.Count <= _textRowIndex)
		    {
				Overflow();
		    }
	    }

	    private void Overflow()
	    {
		    _textRowIndex = 0;
		    _hasOverflowed = true;
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