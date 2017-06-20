namespace RSharp.Core.Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using RSharp.Core.Language;

    public class MultiplyOperation : IBinaryOperation
    {
        private static MultiplyOperation instance = new MultiplyOperation();

        public static MultiplyOperation Instance
        {
            get
            {
                return instance;
            }
        }

        public object Apply(object left, object right)
        {
            if (left is int)
                if (right is int)
                    return (int)left * (int)right;
                else if (right is double)
                    return (int)left * (double)right;
                else
                    return ((Vector)right).Multiply(left);
            else if (left is double)
                if (right is int)
                    return (double)left * (int)right;
                else if (right is double)
                    return (double)left * (double)right;
                else
                    return ((Vector)right).Multiply(left);
            else
                return ((Vector)left).Multiply(right);
        }
    }
}
