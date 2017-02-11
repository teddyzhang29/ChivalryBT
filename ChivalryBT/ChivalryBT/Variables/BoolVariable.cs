using System;

namespace ChivalryBT.Variables
{
    public class BoolVariable : Variable<BoolSharedVariable>
    {
    }

    [Serializable]
    public class BoolSharedVariable : SharedVariable<bool>
    {
        public BoolSharedVariable()
        {
        }

        public BoolSharedVariable(bool isSynced) : base(isSynced)
        {
        }

        public static implicit operator BoolSharedVariable(bool value)
        {
            BoolSharedVariable variable = new BoolSharedVariable();
            variable.Value = value;
            return variable;
        }
    }
}