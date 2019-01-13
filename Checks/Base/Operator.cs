namespace Checks.Base
{
    public enum Operator
    {
        [OperatorAttributes(Display = "+")]
        ADD,
        [OperatorAttributes(Display = "==", ResultType = typeof(bool))]
        EQ,
        [OperatorAttributes(Display = "<>", ResultType = typeof(bool))]
        NE,
        [OperatorAttributes(Display = ">", ResultType = typeof(bool))]
        GT,
        [OperatorAttributes(Display = ">=", ResultType = typeof(bool))]
        GE,
        [OperatorAttributes(Display = "<", ResultType = typeof(bool))]
        LT,
        [OperatorAttributes(Display = "<=", ResultType = typeof(bool))]
        LE,
        [OperatorAttributes(Display = "in", ResultType = typeof(bool))]
        IN,
        [OperatorAttributes(Display = "&&")]
        AND,
        [OperatorAttributes(Display = "")]
        NONE
    }
}
