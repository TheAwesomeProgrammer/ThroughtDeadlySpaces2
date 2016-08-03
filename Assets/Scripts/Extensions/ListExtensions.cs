﻿using System;
using System.Collections.Generic;
using System.Linq;

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

        public static T Random<T>(this List<T> list)
        {
            return list[UnityEngine.Random.Range(0, list.Count)];
        }

        public static TValue RandomValue<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
        {
            return dictionary.Values.ElementAt(UnityEngine.Random.Range(0, dictionary.Count));
        }

        public static void Remove<T>(this List<T> list, Predicate<T> predicate)
        {
            T item = list.Find(predicate);
            list.Remove(item);
        }
    }
}