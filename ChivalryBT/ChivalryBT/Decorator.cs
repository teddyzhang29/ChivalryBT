using UnityEngine;

namespace ChivalryBT
{
    public abstract class Decorator : Action
    {
        protected override int MaxChildCount { get { return 1; } }

        protected Action m_child;

        protected override void OnInit()
        {
            base.OnInit();
            if (transform.childCount > 0)
            {
                Transform child = transform.GetChild(0);
                m_child = child.GetComponent<Action>();
            }

            if (m_child == null)
            {
                Debug.LogErrorFormat("装饰节点没有子节点,节点名:{0}", m_actionName);
            }
            else
            {
                m_child.Init(m_tree);
            }
        }

        protected override void OnResetData()
        {
            base.OnResetData();
            if (m_child != null)
            {
                m_child.ResetData();
            }
        }
    }
}