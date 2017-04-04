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
            foreach (var expr in this.expressions)
            {
                expr.Evaluate(context);

                if (context.HasReturnValue)
                    return context.ReturnValue;
            }

            return null;
        }
    }
}
