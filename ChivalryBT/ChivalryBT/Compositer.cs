using System.Collections.Generic;
using UnityEngine;

namespace ChivalryBT
{
    public abstract class Compositer : Action
    {
        protected override int MaxChildCount { get { return int.MaxValue; } }

        protected List<Action> m_children;

        protected override void OnInit()
        {
            base.OnInit();
            m_children = new List<Action>();
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                Action action = child.GetComponent<Action>();
                if (action == null)
                    continue;

                action.Init(m_tree);
                m_children.Add(action);
            }
        }

        protected override void OnResetData()
        {
            base.OnResetData();
            for (int i = 0; i < m_children.Count; i++)
            {
                m_children[i].ResetData();
            }
        }
    }
}