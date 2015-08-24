using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevLayer.Dev
{
    /// <summary>
    /// PP's RandomBox -20150601 ver-
    /// 将List塞入盒子，随机进行读取
    /// 该类是线程安全的
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RandomBox<T>
    {
        public List<T> ValueList { get; set; }
        private object Lock = new object();

        public RandomBox()
        {
            ValueList = new List<T>();
        }

        public RandomBox(List<T> v)
        {
            ValueList = v;
        }

        public bool RandomGet(out T ran, bool isNeedRemove = false)
        {
            if (ValueList == null || ValueList.Count == 0)
            {
                ran = default(T);
                return false;
            }
            lock (Lock)
            {
                int r = (new Random()).Next(ValueList.Count);
                ran = ValueList[r];
                if (isNeedRemove)
                    ValueList.RemoveAt(r);
            }
            return true;
        }

        public T RandomGet(bool isNeedRemove = false)
        {
            if (ValueList == null || ValueList.Count == 0)
                return default(T);
            lock (Lock)
            {
                int r = (new Random()).Next(ValueList.Count);
                T ran = ValueList[r];
                if (isNeedRemove)
                    ValueList.RemoveAt(r);
                return ran;
            }
        }



    }
}
