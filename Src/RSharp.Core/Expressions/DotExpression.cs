namespace RSharp.Core.Expressions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using RSharp.Core.Functions;

    public class DotExpression : IExpression
    {
        private IExpression expr;
        private String property;

        public DotExpression(IExpression expr, string property)
        {
            this.expr = expr;
            this.property = property;
        }

        public IExpression Expression { get { return this.expr; } }

        public string Property { get { return this.property; } }

        public object Evaluate(Context context)
        {
            throw new NotImplementedException();
        }
    }
}
