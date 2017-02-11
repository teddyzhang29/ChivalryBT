using ChivalryBT.Variables;
using UnityEngine;

namespace ChivalryBT.Actions
{
    public class Wait : Action
    {
        public FloatSharedVariable m_delay;

        private float m_timer;

        protected override void OnResetData()
        {
            base.OnResetData();
            m_timer = 0;
        }

        protected override ActionState OnExecute()
        {
            if (m_timer >= m_delay.Value)
            {
                return ActionState.Success;
            }
            m_timer += Time.deltaTime;
            return ActionState.Running;
        }
    }
}