using System;
using System.Reflection;

namespace Checks.Base
{
    public delegate TResult EvaluateS<T, TResult>(T o1, T o2);
    public delegate TResult EvaluateM<T, TResult>(T o1, T[] o2);

    class Factory
    {
        private object _get<T, TResult>(Operator _operator, bool _multiple)
        {
            return 
                Delegate.CreateDelegate(
                    (_multiple ? typeof(EvaluateM<T, TResult>) : typeof(EvaluateS<T, TResult>)), 
                    this, 
                    this.GetType().GetMethod(
                        _getMethod(_operator), 
                        BindingFlags.NonPublic | BindingFlags.Instance,
                        null,
                        new Type[] { typeof(T), (_multiple ? typeof(T[]) : typeof(T)) },
                        null
                    )
                );
        }

        public TResult Evaluate<T, TResult>(Operator _operator, T _o1, T _o2)
        {
            EvaluateS<T, TResult> _calc = (EvaluateS<T, TResult>)_get<T, TResult>(_operator, false);
            return _calc(_o1, _o2);
        }
        
        public TResult Evaluate<T, TResult>(Operator _operator, T _o1, T[] _o2)
        {
            EvaluateM<T, TResult> _calc = (EvaluateM<T, TResult>)_get<T, TResult>(_operator, true);
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
            else if (_operator == Operator.IN)
            {
                r = "_in";
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
                return false;
        }
        private bool _in(string _a, string[] _b)
        {
            if (_a == null)
                return false;
            
            foreach (string _s in _b)
                if (_a.Equals(_s))
                    return true;

            return false;
        }

        private bool _and(bool _a, bool _b)
        {
            return _a && _b;
        }
    }
}
