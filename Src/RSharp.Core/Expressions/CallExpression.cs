namespace RSharp.Core.Expressions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using RSharp.Core.Functions;

    public class CallExpression : IExpression
    {
        private IExpression fnexpr;
        private IList<IExpression> argexprs;

        public CallExpression(IExpression fn, IList<IExpression> argexprs)
        {
            this.fnexpr = fn;
            this.argexprs = argexprs;
        }

        public object Evaluate(Context context)
        {
            IFunction fn = (IFunction)this.fnexpr.Evaluate(context);
            IList<object> args = new List<object>();

            foreach (var argexpr in this.argexprs)
                args.Add(argexpr.Evaluate(context));

            return fn.Apply(args);
        }
    }
}
