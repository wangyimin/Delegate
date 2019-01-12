using Checks.Base;
using System.Diagnostics;

namespace Checks
{
    class Program
    {
        static void Main(string[] args)
        {
            Expression e = new Expression("1", Operator.ADD, new Expression("2", Operator.ADD, new Expression("3", Operator.ADD, "4")));
            Trace.WriteLine(e);

            var r = e.Result();
            Trace.WriteLine(r);
        }
    }
}
