using System;
using System.Collections.Generic;

namespace Assets.Scripts.Extensions
{
    public static class TypeSwitch
    {
        public class CaseInfo
        {
            public bool IsDefault { get; set; }
            public object[] Targets { get; set; }
            public Action<object> Action { get; set; }

            public override bool Equals(object obj)
            {
                bool equals = false;
                int count = 0;
                foreach (var target in Targets)
                {
                    if (IsValueType(target) && IsValueType(obj))
                    {
                        if (MatchingValues(target, obj))
                        {
                            equals = true;
                            break;
                        }
                    }
                    if (!IsValueType(target) && !IsValueType(obj))
                    {
                        if (MatchingTypes(target, obj))
                        {
                            equals = true;
                            break;
                        }
                    }
                    count++;
                }

                return equals;
            }

            private bool IsValueType(object boxedValue)
            {
                Type typeOfBoxedValue = boxedValue.GetType();
                return typeOfBoxedValue.IsValueType;
            }

            private bool MatchingValues(object boxedValue1, object boxedValue2)
            {
                return boxedValue1.Equals(boxedValue2);
            }

            private bool MatchingTypes(object boxedValue1, object boxedValue2)
            {
                return boxedValue1 == boxedValue2;
            }
        }

        public static void Do(object source, params CaseInfo[] cases)
        {
            foreach (var entry in cases)
            {
                if (entry.IsDefault || entry.Equals(source))
                {
                    entry.Action(source);
                    break;
                }
            }
        }

        public static CaseInfo Case<T>(Action action)
        {
            return new CaseInfo()
            {
                Action = x => action(),
                Targets = new List<object>() { typeof(T) }.ToArray()
            };
        }

        public static CaseInfo Case<T>(Action<T> action)
        {
            return new CaseInfo()
            {
                Action = (x) => action((T)x),
                Targets = new List<object>() { typeof(T) }.ToArray()
            };
        }

        public static CaseInfo Case(object target, Action action)
        {
            return new CaseInfo()
            {
                Action = x => action(),
                Targets = new List<object>() { target }.ToArray()
            };
        }

        public static CaseInfo Case(List<object> targets, Action action)
        {
            return new CaseInfo()
            {
                Action = x => action(),
                Targets = targets.ToArray()
            };
        }

        public static CaseInfo Case(object[] targets, Action action)
        {
            return new CaseInfo()
            {
                Action = x => action(),
                Targets = targets
            };
        }

        public static CaseInfo Default(Action action)
        {
            return new CaseInfo()
            {
                Action = x => action(),
                IsDefault = true
            };
        }
    }
}