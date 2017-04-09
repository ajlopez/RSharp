namespace RSharp.Core.Expressions
{
    using RSharp.Core.Functions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class FunctionExpression : IExpression
    {
        private IList<string> arguments;
        private IExpression expression;

        public FunctionExpression(IList<string> arguments, IExpression expression)
        {
            this.arguments = arguments;
            this.expression = expression;
        }

        public IList<string> Arguments { get { return this.arguments; } }

        public IExpression Expression { get { return this.expression; } }

        public object Evaluate(Context context)
        {
            return new DefinedFunction(context, this.arguments, this.expression);
        }
    }
}
