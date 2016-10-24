using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Assets.Scripts.Extensions;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts.Pathfinding
{
    [Serializable]
    public abstract class NavMeshAgentConfig : INotifyPropertyChanged
    {
        public float Speed
        {
            get { return _speed; }
            set
            {
                _speed = value;
                OnPropertyChanged(this.NameOf(() => Speed));
            }
        }

        public float AngularSpeed
        {
            get { return _angularSpeed; }
            set
            {
                _angularSpeed = value;
                OnPropertyChanged(this.NameOf(() => AngularSpeed));
            }
        }

        public float Acceleration
        {
            get { return _acceleration; }
            set
            {
                _acceleration = value;
                OnPropertyChanged(this.NameOf(() => Acceleration));
            }
        }

        public float StoppingDistance
        {
            get { return _stoppingDistance; }
            set
            {
                _stoppingDistance = value;
                OnPropertyChanged(this.NameOf(() => StoppingDistance));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [SerializeField]
        protected float _speed;
        [SerializeField]
        protected float _angularSpeed;
        [SerializeField]
        protected float _acceleration;
        [SerializeField]
        protected float _stoppingDistance;

        protected object _navMeshAgentObject;
        protected Dictionary<string, Action<object>> _propertyChangeSet = new Dictionary<string, Action<object>>();

        public virtual void Init(object navMeshAgentObject)
        {
            _navMeshAgentObject = navMeshAgentObject;
        }

        public abstract void SetStats();

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            object value = GetType().GetProperty(propertyName).GetValue(this, null);
            _propertyChangeSet[propertyName].Invoke(value);
        }

        protected void AddPropertyChangeData(string name, Action<object> action)
        {
            _propertyChangeSet.Add(name, action);
        }

        public virtual void CopyValues(NavMeshAgentConfig navMeshAgentConfig)
        {
            Speed = navMeshAgentConfig.Speed;
            AngularSpeed = navMeshAgentConfig.AngularSpeed;
            Acceleration = navMeshAgentConfig.Acceleration;
            StoppingDistance = navMeshAgentConfig.StoppingDistance;
        }
    }
}