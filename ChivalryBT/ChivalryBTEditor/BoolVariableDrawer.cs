using ChivalryBT.Variables;
using System;
using UnityEditor;
using UnityEngine;

namespace ChivalryBTEditor
{
    [CustomPropertyDrawer(typeof(BoolSharedVariable))]
    public class BoolVariableDrawer : VariableDrawer
    {
        protected override Type VariableMonoType { get { return typeof(BoolVariable); } }

        protected override void DrawVariable(Rect position, SerializedProperty property, GUIContent label)
        {
            property.boolValue = EditorGUI.Toggle(position, label, property.boolValue);
        }
    }
}