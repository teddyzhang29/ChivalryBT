using System.Reflection;
using UnityEngine;

namespace ChivalryBT.Variables
{
    [System.Serializable]
    public class SharedVariable
    {
        /// <summary>
        /// 是否同步
        /// </summary>
        public bool m_isSynced;
        /// <summary>
        /// 同步变量
        /// </summary>
        public Object m_syncedObject;
        protected Object m_lastSyncedObject;
    }

    public class SharedVariable<T> : SharedVariable
    {
        private SharedVariable<T> m_syncedVariable;

        [SerializeField]
        private T m_value;
        public T Value
        {
            get
            {
                if (m_lastSyncedObject != m_syncedObject)
                {
                    UpdateSyncedVariable();
                }
                if (m_syncedVariable != null)
                {
                    return m_syncedVariable.Value;
                }
                return m_value;
            }
            set
            {
                if (m_lastSyncedObject != m_syncedObject)
                {
                    UpdateSyncedVariable();
                }
                if (m_syncedVariable != null)
                {
                    m_syncedVariable.Value = value;
                }
                m_value = value;
            }
        }

        public SharedVariable()
        {
        }

        public SharedVariable(bool isSynced)
        {
            m_isSynced = isSynced;
        }

        /// <summary>
        /// 更新同步变量
        /// </summary>
        private void UpdateSyncedVariable()
        {
            m_lastSyncedObject = m_syncedObject;
            if (m_syncedObject == null)
            {
                m_syncedVariable = null;
            }
            else
            {
                FieldInfo fieldInfo = m_syncedObject.GetType().GetField("m_value");
                if (fieldInfo != null)
                {
                    m_syncedVariable = fieldInfo.GetValue(m_syncedObject) as SharedVariable<T>;
                }
            }
        }

        public static implicit operator T(SharedVariable<T> v)
        {
            return v.m_value;
        }
    }

    public sealed class UnsyncAttribute : PropertyAttribute
    {
    }
}