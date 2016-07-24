using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Enviroment.Map.Statues
{
    [ExecuteInEditMode]
    public class Statue : MonoBehaviour
    {
        public const float StatueDataUpdateInterval = 10;
        public StatueData[] StatueDatas;

        private StatueData _statueData;

        public void Update()
        {
            if (_statueData == null)
            {
                UpdateStatueData();
            }

            if (StatueDatas != null && StatueDatas.Length > 0)
            {
                foreach (var statueData in StatueDatas)
                {
                    statueData.StatueAttributeNames = _statueData.StatueAttributeNames;
                    statueData.StatueAttributeTypes = _statueData.StatueAttributeTypes;
                }
            }
        }

        private void UpdateStatueData()
        {
            _statueData = GetStatueAttributes();
        }

        public StatueData GetStatueAttributes()
        {
            List<string> statueAttributeNames = new List<string>();
            List<Type> statueAttributeTypes = new List<Type>();

            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                foreach (Type type in assembly.GetTypes())
                {
                    if (type.IsDefined(typeof(StatueDescription), false))
                    {
                        foreach (var customAttribute in type.GetCustomAttributes(typeof(StatueDescription), false))
                        {
                            StatueDescription statueDescription = customAttribute as StatueDescription;
                            if (statueDescription != null)
                            {
                                statueAttributeNames.Add(statueDescription.Description);
                                statueAttributeTypes.Add(type);
                            }
                        }
                    }
                }
            }

            return new StatueData(statueAttributeNames, statueAttributeTypes);
        }
    }
}
