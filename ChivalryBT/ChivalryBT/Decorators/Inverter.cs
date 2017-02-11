namespace ChivalryBT.Decorators
{
    public class Inverter : Decorator
    {
        protected override ActionState OnExecute()
        {
            if (m_child == null)
                return ActionState.Failed;

            ActionState state = m_child.Execute();
            if (state == ActionState.Success)
            {
                return ActionState.Failed;
            }
            else if (state == ActionState.Failed)
            {
                return ActionState.Success;
            }
            else
            {
                return state;
            }
        }
    }
}
