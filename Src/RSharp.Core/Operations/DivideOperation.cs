namespace RSharp.Core.Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using RSharp.Core.Language;

    public class DivideOperation : IBinaryOperation
    {
        public object Apply(object left, object right)
        {
            if (left is int)
                if (right is int)
                {
                    int ileft = (int)left;
                    int iright = (int)right;

                    if (ileft % iright == 0)
                        return ileft / iright;
                    else
                        return ileft / (double)iright;
                }
                else if (right is double)
                    return (int)left / (double)right;
                else
                    return ((Vector)right).Add(left);
            else if (left is double)
                if (right is int)
                    return (double)left / (int)right;
                else if (right is double)
                    return (double)left / (double)right;
                else
                    return ((Vector)right).ApplyToRight(this, left);
            else
                return ((Vector)left).Divide(right);
        }
    }
}
