using System;
using System.Collections.Generic;
using System.Reflection;
using Assets.Scripts.Extensions;
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

        public virtual void Start()
        {
            SetType();
            LoadProperties();
            LoadPropertyObject();
        }

        protected abstract void SetType();

        protected void LoadProperties()
        {
            Properties = FindProperties(_typeToLoad);
        }

        public float FloatValue
        {
            get
            {
                float value = 0;
                Null.OnNot(_value, () => float.TryParse(_value.ToString(), out value));
                return value;
                //if (_value is float || _value is int)
                //{
                //    return (float) _value;
                //}
                //return 0;
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

        public List<object> ListValue
        {
            get
            {
                if (_value.IsList())
                {
                    return (List<object>)_value;
                }
                return new List<object>();
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
            else if(_propertyObject == null)
            {
                LoadPropertyObject();
            }
        }

        private object GetValue(Type type, object source, string propertyName)
        {
            return type.GetProperty(propertyName).GetValue(source, null);
        }
    }
}