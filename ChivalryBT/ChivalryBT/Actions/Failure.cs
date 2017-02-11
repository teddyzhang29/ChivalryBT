namespace ChivalryBT.Actions
{
    public class Failure : Action
    {
        protected override ActionState OnExecute()
        {
            return ActionState.Failed;
        }
    }
}