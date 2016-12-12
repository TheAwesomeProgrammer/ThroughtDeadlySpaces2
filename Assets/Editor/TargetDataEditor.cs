using System;
using Assets.Scripts.Enemy.Attacks.Abstract;
using UnityEditor;
using UnityEngine;

namespace Assets.Editor
{
    [CustomPropertyDrawer (typeof (TargetData))]
    public class TargetDataEditor: PropertyDrawer
    {
        private SerializedProperty _targetType;
        private SerializedProperty _target;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            _target = property;
            _targetType = _target.FindPropertyRelative("TargetType");
            EditorGUI.BeginProperty (position, label, property);
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
            EditorGUI.PropertyField(new Rect(position.x - 30, position.y, 150, position.height), _targetType, GUIContent.none);
            EditorGUI.PropertyField(new Rect(position.x + 100, position.y, 223, position.height), GetTargetProperty((TargetType) _targetType.enumValueIndex), GUIContent.none);

            EditorGUI.EndProperty();
        }

        private SerializedProperty GetTargetProperty(TargetType targetType)
        {
            switch (targetType)
            {
                case TargetType.Position:
                    return _target.FindPropertyRelative("TargetPosition");
                case TargetType.Tag:
                    return _target.FindPropertyRelative("TargetTag");
                case TargetType.Transform:
                    return _target.FindPropertyRelative("TargetTransform");
                default:
                    throw new ArgumentOutOfRangeException("targetType", targetType, null);
            }
        }
    }
}