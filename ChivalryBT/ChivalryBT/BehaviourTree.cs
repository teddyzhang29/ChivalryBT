using ChivalryBT.Decorators;
using UnityEngine;

namespace ChivalryBT
{
    public class BehaviourTree : MonoBehaviour
    {
        public Entry m_entry;

        public DataContext Context { get; private set; }

        private void Awake()
        {
            Context = new DataContext();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            if (m_entry != null)
            {
                m_entry.Init(this);
                m_entry.ResetData();
            }
        }

        public ActionState Execute()
        {
            return m_entry == null ? ActionState.Failed : m_entry.Execute();
        }
    }
}