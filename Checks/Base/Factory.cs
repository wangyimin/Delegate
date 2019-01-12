using System;
using System.Reflection;

namespace Checks.Base
{
    public delegate TResult Evaluate<T, TResult>(T o1, T o2);
    class Factory
    {
        public Evaluate<T, TResult> Get<T, TResult>(Operator _operator)
        {
             return (Evaluate<T, TResult>)
                Delegate.CreateDelegate(
                    typeof(Evaluate<T, TResult>), 
                    this, 
                    this.GetType().GetMethod(
                        _getMethod(_operator), 
                        BindingFlags.NonPublic | BindingFlags.Instance,
                        null,
                        new Type[] { typeof(T), typeof(T) },
                        null
                    )
                );
        }

        public TResult Evaluate<T, TResult>(Operator _operator, T _o1, T _o2)
        {
            Evaluate<T, TResult> _calc = Get<T, TResult>(_operator);
            return _calc(_o1, _o2);
        }

        private string _getMethod(Operator _operator)
        {
            string r = default(string);
            if (_operator == Operator.ADD)
            {
                r = "_add";
            }
            else if (_operator == Operator.EQ)
            {
                r = "_eq";
            }
            else if (_operator == Operator.AND)
            {
                r = "_and";
            }
            else
            {
                throw new InvalidOperationException("Invalid operator[" + _operator.Display() + "]");
            }

            return r;
        }

        private int _add(int _a, int _b)
        {
            return _a + _b;
        }
        private string _add(string _a, string _b)
        {
            return _a + _b;
        }
        private bool _eq(int _a, int _b)
        {
            return _a == _b;
        }
        private bool _eq(string _a, string _b)
        {
            if (_a == null && _b == null)
                return true;
            else if (_a != null)
                return _a.Equals(_b);
            else
                return _b.Equals(_a);
        }
        private bool _and(bool _a, bool _b)
        {
            return _a && _b;
        }
    }
}
