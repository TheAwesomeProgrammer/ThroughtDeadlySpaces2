﻿using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Extensions;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    public abstract class Sword : MonoBehaviour, XmlLoadingObject
    {
        public const int SwordId = 1;
        public SwordSpecs Specs;

        protected List<SwordComponent> _swordComponents;
        protected XmlSearcher _xmlSearcher;

        void Awake()
        {
            _swordComponents = new List<SwordComponent>();
            _xmlSearcher = new XmlSearcher(XmlFileLocations.GetLocation(Location.Sword));
            LoadXmlSpecs();
        }

        public SwordComponent AddExistingComponent(SwordComponent swordComponent)
        {
            _swordComponents.Add(swordComponent);
            return swordComponent;
        }

        public T AddNewComponent<T>() where T : SwordComponent
        {
            return (T)AddExistingComponent(gameObject.AddComponent<T>());
        }

        public List<T> GetSwordComponents<T>()
        {
            return _swordComponents.GetBasesNInterfacesOfType(typeof(T)).Cast<T>().ToList();
        }

        public void RemoveComponents<T>() where T : SwordComponent
        {
            List<SwordComponent> componentsToRemove = _swordComponents.GetBasesNInterfacesOfType(typeof(T));
            foreach (var componentToRemove in componentsToRemove)
            {
                _swordComponents.Remove(componentToRemove);
                Destroy(componentToRemove);
            }
        }

        public void RemoveComponent(SwordComponent swordComponent)
        {
            _swordComponents.Remove(swordComponent);
            Destroy(swordComponent);
        }

        public bool HasComponent(SwordComponent swordComponent)
        {
            return _swordComponents.Contains(swordComponent);
        }

        public bool HasComponent<T>() where T : SwordComponent
        {
            return _swordComponents.Exists(item => item.GetType() == typeof(T));
        }

        public virtual void LoadXmlSpecs()
        {
            int[] specs = _xmlSearcher.GetSpecsWithId(0, "Swords");

            Specs = new SwordSpecs(specs[0], specs[1], specs[2], specs[3], specs[4]);
        }

        void OnDestroy()
        {
            RemoveComponents();
        }

        void RemoveComponents()
        {
            foreach (var component in _swordComponents)
            {
                Destroy(component);
            }
        }
    }
}