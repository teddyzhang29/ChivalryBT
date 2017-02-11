using ChivalryBT.Variables;
using System;
using UnityEditor;
using UnityEngine;

namespace ChivalryBTEditor
{
    [CustomPropertyDrawer(typeof(StringSharedVariable))]
    public class StringVariableDrawer : VariableDrawer
    {
        protected override Type VariableMonoType { get { return typeof(StringVariable); } }

        protected override void DrawVariable(Rect position, SerializedProperty property, GUIContent label)
        {
            property.stringValue = EditorGUI.TextField(position, label, property.stringValue);
        }
    }
}