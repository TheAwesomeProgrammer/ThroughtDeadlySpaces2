using Assets.Scripts.Player;
using Test;
using UnityEditor;
using UnityEngine;
using System.Collections;

namespace Test
{
    [CustomEditor(typeof(PlayerProperties))]
    public class PlayerPropertiesEditor : Editor
    {
        PlayerProperties _instance;
        PropertyField[] _fields;


        public void OnEnable()
        {
            _instance = target as PlayerProperties;
            _fields = ExposeProperties.GetProperties(_instance);
        }

        public override void OnInspectorGUI()
        {
            if (_instance == null)
                return;
            DrawDefaultInspector();
            ExposeProperties.Expose(_fields);
        }
    }
}