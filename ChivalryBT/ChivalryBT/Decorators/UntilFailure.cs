namespace ChivalryBT.Decorators
{
    public class UntilFailure : Decorator
    {
        protected override ActionState OnExecute()
        {
            if (m_child == null)
                return ActionState.Failed;

            ActionState state = m_child.Execute();
            if (state == ActionState.Success)
            {
                m_child.ResetData();
                return ActionState.Running;
            }
            return state;
        }
    }
}