namespace RSharp.Core.Functions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using RSharp.Core.Language;

    public class MakeVector : RSharp.Core.Functions.IFunction
    {
        public object Apply(IList<object> args)
        {
            return new Vector(args);
        }
    }
}
