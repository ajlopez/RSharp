namespace RSharp.Core.Expressions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using RSharp.Core.Operations;

    public class MultiplyExpression : BinaryExpression
    {
        public MultiplyExpression(IExpression leftexpr, IExpression rightexpr)
            : base(new MultiplyOperation(), leftexpr, rightexpr)
        {
        }
    }
}
