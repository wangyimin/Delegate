using Checks.Base;
using System.Diagnostics;

namespace Checks
{
    class Program
    {
        static void Main(string[] args)
        {
            //Expression e = new Expression(new Expression("-1", Operator.ADD, "0"), Operator.ADD, new Expression("2", Operator.ADD, new Expression("3", Operator.ADD, "4")));
            //Expression e = new Expression(new Expression("2", Operator.EQ, "2"), Operator.AND, new Expression("1", Operator.EQ, "1"));
            Expression e = new Expression("2", Operator.IN, new string[] { "3", "2" });
            Trace.WriteLine(e);

            var r = e.Result();
            Trace.WriteLine(r);
        }
    }
}
