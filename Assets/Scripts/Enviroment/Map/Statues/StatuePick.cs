using System;
using Assets.Scripts.Extensions.Math;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Enviroment.Map.Statues
{
    public class StatuePick : MonoBehaviour
    {
        private Statue _statue;
        private StatueSacrifice _statueSacrifice;

        public void Start()
        {
            _statue = GetComponent<Statue>();
            _statueSacrifice = GetComponent<StatueSacrifice>();
        }

        public void Pick()
        {
            SelectRandomAttribute();
            _statueSacrifice.Sacrifice();
        }

        private void SelectRandomAttribute()
        {
            int currentProcent = 0;
            int randomProcent = Random.Range(0, 101);
            foreach (var statueData in _statue.StatueDatas)
            {
                currentProcent += statueData.Procent;
                if (currentProcent >= randomProcent)
                {
                    StatueAttribute statueAttribute = (StatueAttribute)Activator.CreateInstance(statueData.GetSelectedAttributeType);
                    statueAttribute.DoFunction(this);
                    break;
                }
            }
        }
    }
}