using System;

namespace Checks.Base
{
    class OperatorAttributes : Attribute
    {
        public string Display { get; set; }
        public Type ResultType { get; set; }
    }
}
