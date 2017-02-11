using ChivalryBT.Variables;
using System;
using UnityEditor;
using UnityEngine;

namespace ChivalryBTEditor
{
    [CustomPropertyDrawer(typeof(IntSharedVariable))]
    public class IntVariableDrawer : VariableDrawer
    {
        protected override Type VariableMonoType { get { return typeof(IntVariable); } }

        protected override void DrawVariable(Rect position, SerializedProperty property, GUIContent label)
        {
            property.intValue = EditorGUI.IntField(position, label, property.intValue);
        }
    }
}