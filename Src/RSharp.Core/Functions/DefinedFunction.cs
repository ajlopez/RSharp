namespace RSharp.Core.Functions
{
    using RSharp.Core.Expressions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class DefinedFunction : IFunction
    {
        private Context context;
        private IList<string> arguments;
        private IExpression expression;

        public DefinedFunction(Context context, IList<string> arguments, IExpression expression)
        {
            this.context = context;
            this.arguments = arguments;
            this.expression = expression;
        }

        public IList<string> Arguments { get { return this.arguments; } }

        public IExpression Expression { get { return this.expression; } }

        public Context Context { get { return this.context; } }

        public object Apply(Context ctx, IList<object> values)
        {
            Context fctx = new Context(this.context);

            for (int k = 0; k < this.arguments.Count; k++)
                fctx.SetValue(this.arguments[k], values[k]);

            return this.expression.Evaluate(fctx);
        }
    }
}
 