using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Quest
{
    public class GenerateQuestGivers : ScriptGenerateable
    {
        public List<T> Generate<T>(int generateNumber) where T : MonoBehaviour
        {
            List<T> generatedScripts = new List<T>();

            for (int i = 0; i < generateNumber; i++)
            {
                GameObject gameObject = new GameObject(typeof(T).Name);
                generatedScripts.Add(gameObject.AddComponent<T>());
            }

            return generatedScripts;
        }
    }
}