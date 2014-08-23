namespace RSharp.Core.Expressions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using RSharp.Core.Operations;

    public class AddExpression : BinaryExpression
    {
        public AddExpression(IExpression leftexpr, IExpression rightexpr)
            : base(new AddOperation(), leftexpr, rightexpr)
        {
        }
    }
}
