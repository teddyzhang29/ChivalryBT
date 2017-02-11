using System.Collections.Generic;

namespace ChivalryBT
{
    public class DataContext
    {
        private Dictionary<string, object> m_datas;

        public DataContext()
        {
            m_datas = new Dictionary<string, object>();
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void SetData(string name, object value)
        {
            if (m_datas.ContainsKey(name))
            {
                m_datas[name] = value;
            }
            else
            {
                m_datas.Add(name, value);
            }
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public object GetData(string name)
        {
            object value;
            m_datas.TryGetValue(name, out value);
            return value;
        }
    }
}