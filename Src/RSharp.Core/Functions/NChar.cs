namespace RSharp.Core.Functions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using RSharp.Core.Language;

    public class NChar : IFunction
    {
        public object Apply(Context context, IList<object> args, IDictionary<string, object> namedvalues)
        {
            var arg = args[0];

            return ((string)arg).Length;
        }
    }
}
