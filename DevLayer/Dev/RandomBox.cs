using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevLayer.Dev
{
    public class RandomBox<T>
    {
        public RandomBox()
        {
            Value = new List<T>();
        }

        public RandomBox(List<T> v)
        {
            Value = v;
        }

        public List<T> Value { get; set; }

        public bool RandomGet(out T ran, bool isNeedRemove = false)
        {
            if (Value == null || Value.Count == 0)
            {
                ran = default(T);
                return false;
            }
            int r = (new Random()).Next(Value.Count);
            ran = Value[r];
            if (isNeedRemove)
                Value.RemoveAt(r);
            return true;
        }

        public T RandomGet(bool isNeedRemove = false)
        {
            if (Value == null || Value.Count == 0)
                return default(T);
            int r = (new Random()).Next(Value.Count);
            T ran = Value[r];
            if (isNeedRemove)
                Value.RemoveAt(r);
            return ran;
        }

    }
}
