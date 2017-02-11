using ChivalryBT.Variables;

namespace ChivalryBT.Decorators
{
    public class Repeater : Decorator
    {
        public IntSharedVariable m_times;

        private int m_currentTime;
        protected override void OnResetData()
        {
            base.OnResetData();
            m_currentTime = 0;
        }

        protected override ActionState OnExecute()
        {
            if (m_child == null)
                return ActionState.Failed;

            ActionState state = m_child.Execute();
            if (state == ActionState.Success)
            {
                m_currentTime++;
                m_child.ResetData();
                return m_currentTime >= m_times.Value ? ActionState.Success : ActionState.Running;
            }
            return state;
        }
    }
}