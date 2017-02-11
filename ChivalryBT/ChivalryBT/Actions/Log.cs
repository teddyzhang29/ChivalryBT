using ChivalryBT.Variables;
using UnityEngine;

namespace ChivalryBT.Actions
{
    public class Log : Action
    {
        public StringSharedVariable m_log;

        protected override ActionState OnExecute()
        {
            Debug.Log(m_log.Value);
            return ActionState.Success;
        }
    }
}