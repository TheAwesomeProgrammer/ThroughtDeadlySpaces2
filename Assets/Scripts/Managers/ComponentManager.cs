using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Extensions;
using UnityEngine;

namespace Assets.Scripts.Player.Swords.Abstract
{
    public abstract class ComponentManager<TGenericType> : MonoBehaviour where TGenericType : MonoBehaviour
    {
        protected List<TGenericType> _components = new List<TGenericType>();

        protected virtual void Start()
        {
            _components = new List<TGenericType>();
        }

        public virtual TGenericType AddExistingComponent(TGenericType component)
        {
            if (!_components.Contains(component))
            {
                _components.Add(component);
            }
            return component;
        }

        public virtual T AddNewComponent<T>(GameObject alternativeObjectAddingOn = null) where T : TGenericType
        {
            if (alternativeObjectAddingOn == null)
            {
                alternativeObjectAddingOn = gameObject;
            }
            return (T)AddExistingComponent(alternativeObjectAddingOn.AddComponent<T>());
        }

        public List<T> GetComponentsList<T>() where T : TGenericType
        {
            return _components.GetBasesNInterfacesOfType(typeof(T)).Cast<T>().ToList();
        }

        public void RemoveComponents<T>() where T : TGenericType
        {
            List<TGenericType> componentsToRemove = _components.GetBasesNInterfacesOfType(typeof(T));
            foreach (var componentToRemove in componentsToRemove)
            {
                _components.Remove(componentToRemove);
                Destroy(componentToRemove);
            }
        }

        public void RemoveComponent(TGenericType component)
        {
            _components.Remove(component);
            Destroy(component);
        }

        public bool HasComponent(TGenericType component)
        {
            return _components.Contains(component);
        }

        public bool HasComponent<T>() where T : TGenericType
        {
            return _components.Exists(item => item.GetType() == typeof(T));
        }

        public void RemoveComponents()
        {
            foreach (var component in _components)
            {
                Destroy(component);
            }
        }

        public void DisableComponents()
        {
            foreach (var component in _components)
            {
                DisableComponent(component);
            }
        }

        public void DisableComponent(TGenericType component)
        {
            component.enabled = false;
        }

        public void EnableComponents()
        {
            foreach (var component in _components)
            {
                EnableComponent(component);
            }
        }

        public void EnableComponent(TGenericType component)
        {
            component.enabled = false;
        }
    }
}