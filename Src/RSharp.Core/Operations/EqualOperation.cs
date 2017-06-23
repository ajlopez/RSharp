namespace RSharp.Core.Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using RSharp.Core.Language;

    public class EqualOperation : IBinaryOperation
    {
        private static EqualOperation instance = new EqualOperation();

        public static EqualOperation Instance
        {
            get
            {
                return instance;
            }
        }
    
        public object Apply(object left, object right)
        {
            return left.Equals(right);
        }
    }
}
