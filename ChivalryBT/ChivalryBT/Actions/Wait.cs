using ChivalryBT.Variables;
using UnityEngine;

namespace ChivalryBT.Actions
{
    public class YOUR_ACTION : Action
    {
        protected override void OnResetData()
        {
            base.OnResetData();
            //execute before restart this action
        }

        protected override ActionState OnExecute()
        {
            "code here."
            "ActionState has three values:Success,Failed,Running."
            "if you execute a long-time action, such as Walk, you should return Running when not reach destination."
            return ActionState.Success;
        }
    }
}