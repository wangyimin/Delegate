using System;
using System.Reflection;

namespace Checks.Base
{
    public delegate T Evaluate<T>(T o1, T o2);
    class Factory
    {
        public Evaluate<T> Get<T>(Operator _operator)
        {
             return (Evaluate<T>)
                Delegate.CreateDelegate(
                    typeof(Evaluate<T>), 
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

        public T Evaluate<T>(Operator _operator, T o1, T o2)
        {
            Evaluate<T> _calc = Get<T>(_operator);
            return _calc(o1, o2);
        }

        private string _getMethod(Operator _operator)
        {
            string r = default(string);
            if (_operator == Operator.ADD)
            {
                r = "_add";
            }
            else
            {
                throw new InvalidOperationException("Invalid operator[" + _operator.Display() + "]");
            }

            return r;
        }

        private int _add(int a, int b)
        {
            return a + b;
        }
        private string _add(string a, string b)
        {
            return a + b;
        }

    }
}
