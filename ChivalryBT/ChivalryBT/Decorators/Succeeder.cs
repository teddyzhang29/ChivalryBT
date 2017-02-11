namespace ChivalryBT.Decorators
{
    public class Succeeder : Decorator
    {
        protected override ActionState OnExecute()
        {
            if (m_child == null)
                return ActionState.Failed;

            ActionState state = m_child.Execute();
            return state == ActionState.Running ? ActionState.Running : ActionState.Success;
        }
    }
}