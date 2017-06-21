namespace RSharp.Core.Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using RSharp.Core.Language;

    public class ModulusOperation : IBinaryOperation
    {
        private static ModulusOperation instance = new ModulusOperation();

        public static ModulusOperation Instance
        {
            get
            {
                return instance;
            }
        }

        public object Apply(object left, object right)
        {
            return (int)left % (int)right;
        }
    }
}
