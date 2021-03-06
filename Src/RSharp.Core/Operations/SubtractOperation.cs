﻿namespace RSharp.Core.Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using RSharp.Core.Language;

    public class SubtractOperation : IBinaryOperation
    {
        private static SubtractOperation instance = new SubtractOperation();

        public static SubtractOperation Instance
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
                    return (int)left - (int)right;
                else if (right is double)
                    return (int)left - (double)right;
                else
                    return ((Vector)right).ApplyToRight(this, left);
            else if (left is double)
                if (right is int)
                    return (double)left - (int)right;
                else if (right is double)
                    return (double)left - (double)right;
                else
                    return ((Vector)right).ApplyToRight(this, left);
            else
                return ((Vector)left).Subtract(right);
        }
    }
}
