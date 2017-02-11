using ChivalryBT.Variables;
using System;
using UnityEditor;
using UnityEngine;

namespace ChivalryBTEditor
{
    [CustomPropertyDrawer(typeof(FloatSharedVariable))]
    public class FloatVariableDrawer : VariableDrawer
    {
        protected override Type VariableMonoType { get { return typeof(FloatVariable); } }

        protected override void DrawVariable(Rect position, SerializedProperty property, GUIContent label)
        {
            property.floatValue = EditorGUI.FloatField(position, label, property.floatValue);
        }
    }
}