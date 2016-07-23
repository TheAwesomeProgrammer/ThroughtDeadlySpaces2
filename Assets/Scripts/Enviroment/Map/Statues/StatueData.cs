using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Statues
{
    [Serializable]
    public class StatueData
    {
        public int Procent;
        [HideInInspector]
        public List<string> StatueAttributeNames;
        [HideInInspector]
        public int AttributeIndex;

        public List<Type> StatueAttributeTypes { get; set; }

        public StatueData(List<string> statueAttributeNames, List<Type> statueAttributeTypes)
        {
            StatueAttributeNames = statueAttributeNames;
            StatueAttributeTypes = statueAttributeTypes;
        }

        public Type GetSelectedAttributeType
        {
            get
            {
                if (StatueAttributeTypes != null && StatueAttributeTypes.Count > 0)
                {
                    return StatueAttributeTypes[AttributeIndex];
                }
                return null;
            }
        }
    }
}