using System;
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
    }
}