namespace RSharp.Core.Functions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Substring : IFunction
    {
        public object Apply(Context context, IList<object> args, IDictionary<string, object> namedvalues)
        {
            string str = (string)args[0];
            
            int from = (int)args[1];
            int to = (int)args[2];

            return str.Substring(from - 1, to - from + 1);
        }
    }
}
