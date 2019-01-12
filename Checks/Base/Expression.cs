using System;

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
            return "(" + _o1 + _operator.Display() + _o2 + ")";
        }

        public object Result()
        {
            return _result(_o1, _operator, _o2);
        }

        private object _result(object _o1, Operator _operator, object _o2)
        {
            Factory _f = new Factory();

            if (_o1 is Expression _exp1)
            {
                return _result(_result(_exp1._o1, _exp1._operator, _exp1._o2), _operator, _o2);
            }
            else if (_o2 is Expression _exp2)
            {
                return _result(_o1, _operator, _result(_exp2._o1, _exp2._operator, _exp2._o2));
            }
            else
            {
                return _eval(_f, _operator, _o1, _o2);
            }
        }

        private object _eval(Factory _f, Operator _operator, object _o1, object _o2)
        {
            Type _r;
            if (_operator == Operator.EQ 
                || _operator == Operator.NE
                || _operator == Operator.GT
                || _operator == Operator.GE
                || _operator == Operator.LT
                || _operator == Operator.LE
                )
                _r = typeof(bool);
            else
                _r = _o1.GetType();

            return _f.GetType()
                .GetMethod("Evaluate")
                .MakeGenericMethod(new Type[] {_o1.GetType(), _r})
                .Invoke(_f, new object[] { _operator, _o1, _o2 });
        }
    }
}
