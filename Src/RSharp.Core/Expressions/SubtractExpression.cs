namespace RSharp.Core.Expressions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using RSharp.Core.Operations;

    public class SubtractExpression : BinaryExpression
    {
        public SubtractExpression(IExpression leftexpr, IExpression rightexpr)
            : base(new SubtractOperation(), leftexpr, rightexpr)
        {
        }
    }
}
