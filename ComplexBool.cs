using System.Collections.Generic;

namespace Ibukani
{
    public class ComplexBool<T>
    {
        private List<T> _conditions = new List<T>();

        public ComplexBool(params T[] conditions)
        {
            _conditions.AddRange(conditions);
        }

        public void AddCondition(T condition)
        {
            _conditions.Add(condition);
        }

        public void RemoveCondition(T condition)
        {
            _conditions.Remove(condition);
        }

        public static implicit operator bool(ComplexBool<T> complexBool)
        {
            return complexBool._conditions.Count > 0;
        }

        public static implicit operator ComplexBool<T>(T condition)
        {
            return new ComplexBool<T>(condition);
        }

        public static ComplexBool<T> operator +(ComplexBool<T> complexBool, T condition)
        {
            complexBool.AddCondition(condition);
            return complexBool;
        }

        public static ComplexBool<T> operator -(ComplexBool<T> complexBool, T condition)
        {
            complexBool.RemoveCondition(condition);
            return complexBool;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return _conditions.Count > 0 ? "True" : "False";
        }
    }
}