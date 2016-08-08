using Assets.Scripts.Player.Equipments.Attributes;
using Assets.Scripts.Player.Swords;
using UnityEngine;

namespace Assets.Scripts.Player.Equipments
{
    public abstract class EquipmentAttribute : MonoBehaviour
    {
        public ModifierType ModifierType;
        public string Name;
  
        protected int _attributeId;
        protected AttributeXmlData _attributeXmlData;

        private bool _hasInited;

        public abstract AttributeXmlData AttributeXmlData { get; }
        protected EquipmentAttributeLoader EquipmentAttributeLoader
        {
            get
            {
                return _equipmentAttributeLoader = _equipmentAttributeLoader ?? new EquipmentAttributeLoader(AttributeXmlData.LocationToXmlDocument);
            }
        }

        private EquipmentAttributeLoader _equipmentAttributeLoader;

        public virtual void Init()
        {
        }

        private void LoadName()
        {
            if (AttributeXmlData != null)
            {
                Name = EquipmentAttributeLoader.GetName(AttributeXmlData.XmlId, AttributeXmlData.XmlRootName);
            }
        }

        private void OnEnable()
        {
            if (_hasInited == false)
            {
                _hasInited = true;
                Init();
                LoadName();
            }
            Activate();
        }

        protected int[] LoadSpecs(int level)
        {
            return EquipmentAttributeLoader.LoadSpecs(AttributeXmlData.XmlId, level, AttributeXmlData.XmlRootName);
        }

        protected float[] LoadSpecsFloat(int level)
        {
            return EquipmentAttributeLoader.LoadSpecsFloat(AttributeXmlData.XmlId, level, AttributeXmlData.XmlRootName);
        }

        private void OnDisable()
        {
            Deactivate();
        }

        private void OnDestroy()
        {
            Deactivate();
        }

        protected virtual void Activate()
        {
        }

        protected virtual void Deactivate()
        {
        }
    }
}