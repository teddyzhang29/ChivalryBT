using System;

namespace ChivalryBT.Variables
{
    public class StringVariable : Variable<StringSharedVariable>
    {
    }

    [Serializable]
    public class StringSharedVariable : SharedVariable<string>
    {
        public StringSharedVariable()
        {
        }

        public StringSharedVariable(bool isSynced) : base(isSynced)
        {
        }

        public static implicit operator StringSharedVariable(string value)
        {
            StringSharedVariable variable = new StringSharedVariable();
            variable.Value = value;
            return variable;
        }
    }
}