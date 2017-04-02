namespace RSharp.Core.Functions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using RSharp.Core.Language;

    public class Return : RSharp.Core.Functions.IFunction
    {
        public object Apply(Context context, IList<object> args)
        {
            var value = args[0];
            context.ReturnValue = value;
            return value;
        }
    }
}
