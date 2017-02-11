using UnityEngine;

namespace ChivalryBT.Variables
{
    public abstract class Variable<T> : MonoBehaviour
    {
        [Unsync]
        public T m_value;
    }
}