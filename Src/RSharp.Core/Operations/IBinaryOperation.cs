namespace RSharp.Core.Operations
{
    using System;

    public interface IBinaryOperation
    {
        object Apply(object left, object right);
    }
}
