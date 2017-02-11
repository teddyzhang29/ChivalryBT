namespace ChivalryBT.Compositers
{
    public class Selector : Compositer
    {
        private int m_index;

        protected override void OnResetData()
        {
            base.OnResetData();
            m_index = 0;
        }

        protected override ActionState OnExecute()
        {
            for (int i = m_index; i < m_children.Count; i++)
            {
                ActionState state = m_children[i].Execute();
                if (state == ActionState.Failed)
                {
                    m_index++;
                    continue;
                }
                return state;
            }
            return ActionState.Failed;
        }
    }
}