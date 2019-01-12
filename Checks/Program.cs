using Checks.Base;
using System.Diagnostics;

namespace Checks
{
    class Program
    {
        static void Main(string[] args)
        {
            string o1 = "1";
            string o2 = "2";
            var r = _wrapper(new Factory(), Operator.ADD, o1, o2);

            Trace.WriteLine(r);
        }

        private static object _wrapper(Factory _f, Operator _operator, object _o1, object _o2)
        {
            return _f.GetType()
                .GetMethod("Evaluate")
                .MakeGenericMethod(_o1.GetType())
                .Invoke(_f, new object[] { Operator.ADD, _o1, _o2 });
        }
    }
}
