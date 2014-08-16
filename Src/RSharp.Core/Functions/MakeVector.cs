namespace RSharp.Core.Functions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using RSharp.Core.Language;

    public class MakeVector
    {
        public object Apply(IList<object> arguments)
        {
            return new Vector(arguments);
        }
    }
}
