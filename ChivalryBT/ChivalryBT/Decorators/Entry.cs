namespace ChivalryBT.Decorators
{
    public class Entry : Decorator
    {
        protected override ActionState OnExecute()
        {
            return m_child != null ? m_child.Execute() : ActionState.Failed;
        }
    }
}