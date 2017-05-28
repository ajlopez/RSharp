namespace RSharp.Core.Functions
{
    using RSharp.Core.Language;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class NChar : IFunction
    {
        public object Apply(Context context, IList<object> args, IDictionary<string, object> namedvalues)
        {
            var arg = args[0];

            return ((String)arg).Length;
        }
    }
}
