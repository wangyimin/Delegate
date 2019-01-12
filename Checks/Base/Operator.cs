namespace Checks.Base
{
    public enum Operator
    {
        [OperatorAttributes(Display = "+")]
        ADD,
        [OperatorAttributes(Display = "==")]
        EQ,
        [OperatorAttributes(Display = "<>")]
        NE,
        [OperatorAttributes(Display = ">")]
        GT,
        [OperatorAttributes(Display = ">=")]
        GE,
        [OperatorAttributes(Display = "<")]
        LT,
        [OperatorAttributes(Display = "<=")]
        LE,
        [OperatorAttributes(Display = "&&")]
        AND,
        [OperatorAttributes(Display = "")]
        NONE
    }
}
