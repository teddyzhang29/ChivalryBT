using ChivalryBT.Actions;
using ChivalryBT.Variables;
using System;
using UnityEditor;
using UnityEngine;

namespace ChivalryBTEditor
{
    public abstract class VariableDrawer : PropertyDrawer
    {
        protected abstract Type VariableMonoType { get; }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            object[] attrs = fieldInfo.GetCustomAttributes(typeof(UnsyncAttribute), false);
            bool unsync = attrs.Length > 0;

            SerializedProperty m_isSynced = property.FindPropertyRelative("m_isSynced");
            SerializedProperty m_syncedObject = property.FindPropertyRelative("m_syncedObject");
            SerializedProperty m_value = property.FindPropertyRelative("m_value");

            int syncRectWidth = 30;
            if (unsync)
            {
                syncRectWidth = 0;
            }
            Rect propertyRect = new Rect(position.x, position.y, position.width - syncRectWidth, position.height);
            Rect syncRect = new Rect(position.x + position.width - syncRectWidth + 10, position.y, position.width, position.height);
            if (!unsync && m_isSynced.boolValue)
            {
                //同步
                m_syncedObject.objectReferenceValue = EditorGUI.ObjectField(propertyRect, label, m_syncedObject.objectReferenceValue, VariableMonoType, true);
            }
            else
            {
                //未同步
                m_syncedObject.objectReferenceValue = null;
                DrawVariable(propertyRect, m_value, label);
            }
            if (!unsync)
            {
                m_isSynced.boolValue = EditorGUI.Toggle(syncRect, m_isSynced.boolValue);
            }
            EditorGUI.EndProperty();
        }

        protected abstract void DrawVariable(Rect position, SerializedProperty property, GUIContent label);
    }
}