using UnityEngine;

namespace Assets.Scripts.Extensions
{
    // Have to be defined somewhere in a runtime script file
    public class BitMaskAttribute : PropertyAttribute
    {
        public System.Type propType;
        public BitMaskAttribute(System.Type aType)
        {
            propType = aType;
        }
    }
}