using Assets.Scripts.Player.Swords;
using UnityEngine;

namespace Assets.Scripts.Player.Equipments
{
    public abstract class EquipmentAttribute : MonoBehaviour
    {
        public ModifierType ModifierType;

        protected EquipmentAttributeLoader _equipmentAttributeLoader;
        protected int _attributeId = 5;

        private bool _hasInited;

        protected int[] LoadSpecs(string locationToXmlDocument, int xmlId, int level, string xmlRootName)
        {
            _equipmentAttributeLoader = new EquipmentAttributeLoader(locationToXmlDocument);
            return _equipmentAttributeLoader.LoadSpecs(xmlId, level, xmlRootName);
        }

        public virtual void Init()
        {
        }

        private void OnEnable()
        {
            if (_hasInited == false)
            {
                _hasInited = true;
                Init();
            }
            Activate();
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