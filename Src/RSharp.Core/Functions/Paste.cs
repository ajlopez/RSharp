namespace RSharp.Core.Functions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Paste : IFunction
    {
        public object Apply(Context context, IList<object> args, IDictionary<string, object> namedvalues)
        {
            string result = (string)args[0];

            for (int k = 1; k < args.Count; k++)
                result += " " + args[k];

            return result;
        }
    }
}
