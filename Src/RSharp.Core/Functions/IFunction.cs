namespace RSharp.Core.Functions
{
    using System;
    using System.Collections.Generic;

    public interface IFunction
    {
        object Apply(IList<object> values);
    }
}
