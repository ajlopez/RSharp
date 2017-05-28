namespace RSharp.Core.Functions
{
    using RSharp.Core.Language;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Length : IFunction
    {
        public object Apply(Context context, IList<object> args, IDictionary<string, object> namedvalues)
        {
            var arg = args[0];

            if (arg is Vector)
                return ((Vector)arg).Length;
 
            return ((String)arg).Length;
        }
    }
}
