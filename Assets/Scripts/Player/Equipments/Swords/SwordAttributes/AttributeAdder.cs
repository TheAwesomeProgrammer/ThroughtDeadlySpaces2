using System;
using UnityEngine;

namespace Assets.Scripts.Player.Swords
{
    public interface AttributeAdder
    {
        MonoBehaviour AddAttribute(Enum attribute);
    }
}