using System.Collections.Generic;

namespace ChivalryBT.Compositers
{
    public class Parallel : Compositer
    {
        private List<Action> m_actions;

        protected override void OnInit()
        {
            base.OnInit();
            m_actions = new List<Action>();
        }

        protected override void OnResetData()
        {
            base.OnResetData();
            m_actions.Clear();
            for (int i = 0; i < m_children.Count; i++)
            {
                m_actions.Add(m_children[i]);
            }
        }

        protected override ActionState OnExecute()
        {
            List<Action> removes = new List<Action>();
            for (int i = 0; i < m_actions.Count; i++)
            {
                ActionState state = m_actions[i].Execute();
                if (state == ActionState.Failed)
                    return ActionState.Failed;

                if (state == ActionState.Success)
                    removes.Add(m_actions[i]);
            }

            //移除
            for (int i = 0; i < removes.Count; i++)
            {
                m_actions.Remove(removes[i]);
            }

            return m_actions.Count == 0 ? ActionState.Success : ActionState.Running;
        }
    }
}