using UnityEngine;

namespace ChivalryBT
{
    public abstract class Action : MonoBehaviour
    {
        /// <summary>
        /// 最大子节点数量
        /// </summary>
        protected virtual int MaxChildCount { get { return 0; } }
        protected BehaviourTree m_tree;

        protected bool m_firstExecute;
        protected string m_actionName;
        private ActionState m_lastState;

        /// <summary>
        /// MonoBehaviour.Reset
        /// </summary>
        private void Reset()
        {
            if (GetComponents<Action>().Length == 1)
            {
                name = GetType().Name;
            }
        }

        /// <summary>
        /// 创建
        /// </summary>
        public void Init(BehaviourTree tree)
        {
            m_tree = tree;
            m_actionName = name;
            CheckChildCount();
            OnInit();
        }

        protected virtual void OnInit() { }

        /// <summary>
        /// 检查子节点最大数量
        /// </summary>
        private void CheckChildCount()
        {
            if (transform.childCount > MaxChildCount)
            {
                Debug.LogErrorFormat("子节点数量超过上限,上限为:{0},节点名:{1}", MaxChildCount, m_actionName);
            }
        }

        public void ResetData()
        {
            m_firstExecute = true;
            name = m_actionName;
            m_lastState = ActionState.Inactive;
            OnResetData();
        }

        /// <summary>
        /// 重置
        /// </summary>
        protected virtual void OnResetData() { }

        public ActionState Execute()
        {
            ActionState state = OnExecute();
            if (m_lastState != state)
            {
                m_lastState = state;
                UpdateActionName(state);
            }
            m_firstExecute = false;
            return state;
        }

        /// <summary>
        /// 执行
        /// </summary>
        /// <returns></returns>
        protected abstract ActionState OnExecute();

        /// <summary>
        /// 更新行为名称
        /// </summary>
        /// <param name="state"></param>
        private void UpdateActionName(ActionState state)
        {
            string prefix;
            switch (state)
            {
                case ActionState.Success:
                    prefix = "S";
                    break;
                case ActionState.Failed:
                    prefix = "F";
                    break;
                case ActionState.Running:
                    prefix = "R";
                    break;
                default:
                    prefix = string.Empty;
                    break;
            }
            name = string.Format("({0}){1}", prefix, m_actionName);
        }
    }
}