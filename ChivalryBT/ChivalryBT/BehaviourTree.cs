using ChivalryBT.Decorators;
using UnityEngine;

namespace ChivalryBT
{
    public class BehaviourTree : MonoBehaviour
    {
        public bool m_startOnAwake = true;
        public Entry m_entry;

        public DataContext Context { get; private set; }
        /// <summary>
        /// 是否在执行中
        /// </summary>
        public bool IsExecuting { get; private set; }

        private void Awake()
        {
            Context = new DataContext();
            if (m_entry != null)
            {
                m_entry.Init(this);
            }

            if (m_startOnAwake)
            {
                Execute();
            }
        }

        private void Update()
        {
            if (!IsExecuting)
            {
                enabled = false;
                return;
            }

            ActionState state = m_entry == null ? ActionState.Failed : m_entry.Execute();
            if (state != ActionState.Running)
            {
                IsExecuting = false;
                enabled = false;
            }
        }

        /// <summary>
        /// 启动
        /// </summary>
        public void Execute()
        {
            if (IsExecuting)
                return;

            if (m_entry == null)
            {
                Debug.LogError("Behaviour Tree必须设置Entry");
                return;
            }

            IsExecuting = true;
            m_entry.ResetData();
            enabled = true;
        }
    }
}