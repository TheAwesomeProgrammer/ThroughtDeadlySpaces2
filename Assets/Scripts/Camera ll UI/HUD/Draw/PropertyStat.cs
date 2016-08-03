using System;
using System.Collections.Generic;
using System.Reflection;
using Assets.Scripts.Player;
using Assets.Scripts.Player.Swords.Abstract;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Camera_ll_UI.HUD
{
    [ExecuteInEditMode]
    public abstract class PropertyStat : MonoBehaviour
    {
        public List<string> Properties;
        public int Index;
        protected object _value;
        protected Type _typeToLoad;

        protected object _propertyObject;

        public void Start()
        {
            Init();
            LoadProperties();
            LoadPropertyObject();
        }

        protected abstract void Init();

        protected void LoadProperties()
        {
            Properties = FindProperties(_typeToLoad);
        }

        public float FloatValue
        {
            get
            {
                if (_value is float)
                {
                    return (float) _value;
                }
                return 0;
            }
        }

        public string StringValue
        {
            get
            {
                if (_value != null)
                {
                    return _value.ToString();
                }
                return "";
            }
        }

        protected abstract void LoadPropertyObject();

        private List<string> FindProperties(Type type)
        {
            List<string> properties = new List<string>();

            foreach (var memberInfo in type.GetMembers())
            {
                if (memberInfo.MemberType == MemberTypes.Property)
                {
                    properties.Add(memberInfo.Name);
                }
            }

            return properties;
        }

        protected virtual void Update()
        {
            if (Application.isPlaying && _propertyObject != null)
            {
                _value = GetValue(_typeToLoad, _propertyObject, Properties[Index]);
            }
        }

        private object GetValue(Type type, object source, string propertyName)
        {
            return type.GetProperty(propertyName).GetValue(source, null);
        }
    }
}