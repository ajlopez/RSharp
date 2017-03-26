namespace RSharp.Core.Expressions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CompositeExpression : IExpression
    {
        private IList<IExpression> expressions;

        public CompositeExpression(IList<IExpression> expressions)
        {
            this.expressions = expressions;
        }

        public IList<IExpression> Expressions { get { return this.expressions; } }

        public object Evaluate(Context context)
        {
            throw new NotImplementedException();
        }
    }
}
