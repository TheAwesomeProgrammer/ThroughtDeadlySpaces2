using System;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class MoneyManager
    {
        private static int _money = 1000;

        public static int Money
        {
            get { return _money; }
            set
            {
                if (value != _money)
                {
                    if (MoneyChanged != null)
                    {
                        MoneyChanged(value - _money);
                    }
                    _money = Mathf.Clamp(value, 0, int.MaxValue);
                }
                
            }
        }

        public static event Action<int> MoneyChanged;
    }
}