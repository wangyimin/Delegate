using System;
using System.Linq;
using System.Reflection;

namespace Checks.Base
{
    public static class Extensions
    {
        public static string Display(this Enum e)
        {
            return e.GetType()
                            .GetMember(e.ToString())
                            .First()
                            .GetCustomAttribute<OperatorAttributes>()
                            .Display;
        }
    }
}
