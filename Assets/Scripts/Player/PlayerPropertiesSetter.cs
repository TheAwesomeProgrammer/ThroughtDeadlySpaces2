using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Camera_ll_UI.HUD;
using Assets.Scripts.Extensions;
using UnityEngine;

namespace Assets.Scripts.Player
{
    [Serializable]
    public struct SetData
    {
        public float FloatValue;
        public int Id;

        public SetData(float floatValue, int id)
        {
            FloatValue = floatValue;
            Id = id;
        }
    }

    [Serializable]
    public class PlayerPropertiesSetter : MonoBehaviour
    {
        private PlayerPropertiesStat _playerPropertiesStat;
        private List<SetData> _setDatas = new List<SetData>();
        private float _startValue;
        private bool _isFirstUpdate;

        public void Start()
        {
            _isFirstUpdate = true;
            _playerPropertiesStat = GetComponent<PlayerPropertiesStat>();
            _setDatas = new List<SetData>();
        }

        public void Add(SetData setData)
        {
            _setDatas.Add(setData);
        }

        public void Remove(SetData setData)
        {
            _setDatas.Remove(setData);
        }

        public void Remove(int id)
        {
            _setDatas.Remove(item => item.Id == id);
        }

        public void Update()
        {
            if(IsFirstUpdate() == false)
            {
                float highestValue = HighestValue();
                float lowestValue = LowestValue();
                _playerPropertiesStat.SetValue(_startValue + (highestValue - lowestValue));
            }
        }
        private bool IsFirstUpdate()
        {
            if (_isFirstUpdate)
            {
                OnFirstUpdate();
                _isFirstUpdate = false;
                return true;
            }
            return false;
        }

        private void OnFirstUpdate()
        {
            _startValue = _playerPropertiesStat.FloatValue;
        }

        private float HighestValue()
        {
            float highestValue = 0;
            if (_setDatas.Count > 0)
            {
                highestValue = _setDatas.Max(item => item.FloatValue);
            }
            return highestValue;
        }

        private float LowestValue()
        {
            float lowestValue = 0;
            if (_setDatas.Count > 0)
            {
                lowestValue = _setDatas.Min(item => item.FloatValue);
            }
            return lowestValue;
        }
    }
}