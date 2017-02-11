using ChivalryBT;
using ChivalryBT.Compositers;
using ChivalryBT.Decorators;
using UnityEditor;
using UnityEngine;

namespace ChivalryBTEditor
{
    public class BTMenu
    {
        [MenuItem("GameObject/Behaviour Tree", priority = 0)]
        private static void CreateBT()
        {
            BehaviourTree bt = new GameObject("Behaviour Tree", typeof(BehaviourTree)).GetComponent<BehaviourTree>();
            bt.transform.SetParent(Selection.activeTransform);

            GameObject variables = new GameObject("Variables");
            variables.transform.SetParent(bt.transform);

            Entry entry = new GameObject("Entry", typeof(Entry)).GetComponent<Entry>();
            entry.transform.SetParent(bt.transform);
            bt.m_entry = entry;

            GameObject sequence = new GameObject("Sequence", typeof(Sequence));
            sequence.transform.SetParent(entry.transform);

            Selection.activeGameObject = sequence;
        }
    }
}