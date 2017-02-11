namespace ChivalryBT.Decorators
{
    public class UntilSuccess : Decorator
    {
        protected override ActionState OnExecute()
        {
            if (m_child == null)
                return ActionState.Failed;

            ActionState state = m_child.Execute();
            if (state == ActionState.Success)
                return ActionState.Success;

            if (state == ActionState.Failed)
            {
                m_child.ResetData();
            }
            return ActionState.Running;
        }
    }
}