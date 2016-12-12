using System.Collections.Generic;
using Assets.Scripts.Enemy.Attacks;
using Assets.Scripts.Enemy.Attacks.Abstract;
using Assets.Scripts.Enemy.Test;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace Assets.Editor.Combat
{
    public class CombatActorEditor : UnityEditor.Editor
    {
        private ReorderableList list;

        private void OnEnable()
        {
            list = new ReorderableList(serializedObject,
                serializedObject.FindProperty("CombatActions"),
                true, true, true, true);
            list.drawElementCallback += DrawLevels;
            list.drawHeaderCallback += DrawHeader;
        }

        private void DrawHeader(Rect rect)
        {
            EditorGUI.LabelField(rect, "Name                                 Time");
        }

        private void DrawLevels(Rect rect, int index, bool isActive, bool isFocused)
        {
            var element = list.serializedProperty.GetArrayElementAtIndex(index);
            //(element.serializedObject.targetObject as Attack).CombatActions[index].SetCombatActions();
            element.FindPropertyRelative("Index").intValue = EditorGUI.Popup(new Rect(rect.x, rect.y, 150, EditorGUIUtility.singleLineHeight),
                element.FindPropertyRelative("Index").intValue, element.FindPropertyRelative("CombatActions").GetStringList().ToArray());
            EditorGUI.PropertyField(new Rect(rect.x + 175, rect.y, 150, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("Time"), GUIContent.none);

        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            serializedObject.Update();
            list.DoLayoutList();
            serializedObject.ApplyModifiedProperties();
        }
    }
}