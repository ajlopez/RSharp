namespace RSharp.Core.Functions
{
    using RSharp.Core.Language;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Rep : IFunction
    {
        public object Apply(Context context, IList<object> args, IDictionary<string, object> namedvalues)
        {
            var value = args[0];
            var ntimes = (int)args[1];
            IList<object> values = new List<object>();

            for (int k = 0; k < ntimes; k++)
                values.Add(value);

            return new Vector(values);
        }
    }
}
