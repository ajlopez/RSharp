namespace RSharp.Core.Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class AddOperation
    {
        public object Apply(object left, object right)
        {
            if (left is int)
                if (right is int)
                    return (int)left + (int)right;
                else
                    return (int)left + (double)right;
            else
                if (right is int)
                    return (double)left + (int)right;
                else
                    return (double)left + (double)right;
        }
    }
}
