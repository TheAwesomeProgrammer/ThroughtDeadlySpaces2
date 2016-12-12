using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Extensions
{
    public static class ListExtensions
    {
        public static void RemoveType<T>(this List<T> list, Type type)
        {
            list.RemoveAll(item => item.GetType().IsSubclassOf(type) || item.GetType() == type);
        }

        public static List<T> GetBasesNInterfacesOfType<T>(this List<T> list, Type type)
        {
            return list.FindAll(item => item.GetType().IsSubclassOf(type) || item.GetType() == type|| 
            item.GetType().GetInterfaces().Contains(type));
        }

        public static List<T> Clone<T>(this List<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }

        /// <summary>
        /// Get random element from list
        /// </summary>
        /// <returns>Random element from list</returns>
        public static T Random<T>(this List<T> list)
        {
            if (list.Count <= 0)
            {
                return default(T);
            }
            return list[UnityEngine.Random.Range(0, list.Count)];
        }

        public static TValue RandomValue<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
        {
            return dictionary.Values.ElementAt(UnityEngine.Random.Range(0, dictionary.Count));
        }

        public static T Next<T>(this List<T> list, int index)
        {
            int nextIndex = index + 1;
            if (list.Count > nextIndex)
            {
                return list[nextIndex];
            }
            return default(T);
        }

        public static List<T> FindClosestToTarget<T>(this List<T> list, Vector3 target, int lengthOfTargetList) where T : Transform
        {
            List<T> targets = new List<T>();

            list.Sort((a, b) => GetDistance(target, a).CompareTo(GetDistance(target, b)));

            for (int i = 0; i < lengthOfTargetList; i++)
            {
                targets.Add(list[i]);
            }

            return targets;
        }

        private static float GetDistance(Vector3 position, Transform transform)
        {
            return Vector3.Distance(position, transform.position);
        }



        public static void Remove<T>(this List<T> list, Predicate<T> predicate)
        {
            T item = list.Find(predicate);
            list.Remove(item);
        }
    }
}