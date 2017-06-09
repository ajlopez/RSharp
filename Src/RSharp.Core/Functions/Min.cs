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
            int? intresult = null;
            double? realresult = null;

            foreach (var value in values)
            {
                if (value is int)
                    if (intresult.HasValue)
                    {
                        if (intresult > (int)value)
                            intresult = (int)value;
                    }
                    else
                        intresult = (int)value;
                else if (value is double)
                    if (realresult.HasValue)
                    {
                        if (realresult > (double)value)
                            realresult = (double)value;
                    }
                    else
                        realresult = (double)value;
            }

            if (realresult.HasValue && intresult.HasValue)
                if (realresult < intresult)
                    return realresult;
                else
                    return intresult;

            if (realresult.HasValue)
                return realresult;

            return intresult;
        }
    }
}
