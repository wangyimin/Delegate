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

            if (_o2 is Expression _exp)
            {
                return _eval(_f, _operator, _o1, _result(_exp._o1, _exp._operator, _exp._o2));
            }
            else
            {
                return _eval(_f, _operator, _o1, _o2);
            }
        }

        private object _eval(Factory _f, Operator _operator, object _o1, object _o2)
        {
            return _f.GetType()
                .GetMethod("Evaluate")
                .MakeGenericMethod(_o1.GetType())
                .Invoke(_f, new object[] { _operator, _o1, _o2 });
        }
    }
}
