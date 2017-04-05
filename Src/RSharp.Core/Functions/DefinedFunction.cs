namespace RSharp.Core.Functions
{
    using RSharp.Core.Expressions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class DefinedFunction : IFunction
    {
        private IList<string> arguments;
        private IExpression expression;

        public DefinedFunction(IList<string> arguments, IExpression expression)
        {
            this.arguments = arguments;
            this.expression = expression;
        }

        public IList<string> Arguments { get { return this.arguments; } }

        public IExpression Expression { get { return this.expression; } }

        public object Apply(Context context, IList<object> values)
        {
            throw new NotImplementedException();
        }
    }
}
