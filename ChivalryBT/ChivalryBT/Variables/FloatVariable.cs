using System;

namespace ChivalryBT.Variables
{
    public class FloatVariable : Variable<FloatSharedVariable>
    {
    }

    [Serializable]
    public class FloatSharedVariable : SharedVariable<float>
    {
        public FloatSharedVariable()
        {
        }

        public FloatSharedVariable(bool isSynced) : base(isSynced)
        {
        }

        public static implicit operator FloatSharedVariable(float value)
        {
            FloatSharedVariable variable = new FloatSharedVariable();
            variable.Value = value;
            return variable;
        }
    }
}