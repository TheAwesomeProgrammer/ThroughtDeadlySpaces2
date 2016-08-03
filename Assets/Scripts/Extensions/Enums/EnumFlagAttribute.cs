using UnityEngine;

namespace Assets.Scripts.Extensions.Enums
{
    public class EnumFlagAttribute : PropertyAttribute
    {
        public string EnumName;

        public EnumFlagAttribute() { }

        public EnumFlagAttribute(string name)
        {
            EnumName = name;
        }
    }
}