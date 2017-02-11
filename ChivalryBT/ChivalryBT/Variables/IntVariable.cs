using System;

namespace ChivalryBT.Variables
{
    public class IntVariable : Variable<IntSharedVariable>
    {
    }

    [Serializable]
    public class IntSharedVariable : SharedVariable<int>
    {
        public IntSharedVariable()
        {
        }

        public IntSharedVariable(bool isSynced) : base(isSynced)
        {
        }

        public static implicit operator IntSharedVariable(int value)
        {
            IntSharedVariable variable = new IntSharedVariable();
            variable.Value = value;
            return variable;
        }
    }
}