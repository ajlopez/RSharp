namespace RSharp.Core.Functions
{
    using RSharp.Core.Language;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Length : IFunction
    {
        public object Apply(Context context, IList<object> args)
        {
            return ((Vector)args[0]).Length;
        }
    }
}
