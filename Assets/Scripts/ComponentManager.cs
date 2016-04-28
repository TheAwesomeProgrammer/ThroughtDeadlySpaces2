using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Extensions;
using UnityEngine;

namespace Assets.Scripts.Player.Swords.Abstract
{
    public abstract class ComponentManager<TGenericType> : MonoBehaviour where TGenericType : MonoBehaviour
    {
        protected List<TGenericType> _components = new List<TGenericType>();

        void Start()
        {
            _components = new List<TGenericType>();
        }

        public TGenericType AddExistingComponent(TGenericType swordComponent)
        {
            _components.Add(swordComponent);
            return swordComponent;
        }

        public T AddNewComponent<T>() where T : TGenericType
        {
            return (T)AddExistingComponent(gameObject.AddComponent<T>());
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

        public void RemoveComponent(TGenericType swordComponent)
        {
            _components.Remove(swordComponent);
            Destroy(swordComponent);
        }

        public bool HasComponent(TGenericType swordComponent)
        {
            return _components.Contains(swordComponent);
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
    }
}