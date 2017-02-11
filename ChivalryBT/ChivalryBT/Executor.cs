namespace ChivalryBT
{
    public class Executor
    {
        public delegate void OnFinishEventHandler(BehaviourTree bt, ActionState state);
        public event OnFinishEventHandler OnFinish;

        public bool IsExecuting { get; private set; }

        private BehaviourTree m_bt = null;

        public void Execute(BehaviourTree bt)
        {
            if (bt == null)
                return;

            if (IsExecuting)
                return;

            IsExecuting = true;
            m_bt = bt;
            m_bt.Init();
        }

        public void OnUpdate(float deltaTime)
        {
            if (!IsExecuting)
                return;

            ActionState state = m_bt.Execute();
            if (state != ActionState.Running)
            {
                IsExecuting = false;
                BehaviourTree finishBt = m_bt;
                m_bt = null;
                if (OnFinish != null)
                {
                    OnFinish(finishBt, state);
                }
            }
        }
    }
}