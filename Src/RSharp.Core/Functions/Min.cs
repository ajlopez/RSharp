namespace RSharp.Core.Functions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Min : IFunction
    {
        public object Apply(Context context, IList<object> values, IDictionary<string, object> namedvalues)
        {
            int? result = null;

            foreach (var value in values)
            {
                if (value is int)
                    if (result.HasValue)
                    {
                        if (result > (int)value)
                            result = (int)value;
                    }
                    else
                        result = (int)value;
            }

            return result;
        }
    }
}
