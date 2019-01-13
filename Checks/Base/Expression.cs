using Checks.Utils;
using System;
using System.Linq;
using System.Reflection;

namespace Checks.Base
{
    class Expression
    {
        private Operator _operator;
        private object _o1, _o2;

        public Expression(object _o1, Operator _operator, object _o2)
        {
            this._operator = _operator;
            this._o1 = _o1;
            this._o2 = _o2;
        }

        public override string ToString()
        {
            string s = _o2.ToString();
            if (_o2 is Array)
                s = StringUtils.Array2String(_o2 as object[]);

            return "(" + _o1 + " " + _operator.Display() + " " + s + ")";
        }

        public object Result()
        {
            return _result(_o1, _operator, _o2);
        }

        private object _result(object _o1, Operator _operator, object _o2)
        {
            Factory f = new Factory();

            if (_o1 is Expression exp1)
            {
                if (exp1._o2 is Array)
                    return _result(_result(exp1._o1, exp1._operator, exp1._o2), _operator, _o2);
                else
                    return _result(_result(exp1._o1, exp1._operator, exp1._o2), _operator, _o2);
            }
            else if (_o2 is Expression exp2)
            {
                return _result(_o1, _operator, _result(exp2._o1, exp2._operator, exp2._o2));
            }
            else
            {
                return _eval(f, _operator, _o1, _o2);
            }
        }

        private object _eval(Factory _f, Operator _operator, object _o1, object _o2)
        {
            Type r = _operator.ResultType()?? _o1.GetType();

            MethodInfo mi = _f.GetType().GetMethods()
                .Where(el => "Evaluate".Equals(el.Name))
                .Where(el=>el.GetParameters()[2].ParameterType.IsArray == (_o2 is Array))
                .First();

            return mi.MakeGenericMethod(new Type[] { _o1.GetType(), r }).Invoke(_f, new object[] { _operator, _o1, _o2 });
        }
    }
}
