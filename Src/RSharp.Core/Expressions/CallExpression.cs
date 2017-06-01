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
        private IDictionary<string, IExpression> namedargexprs;

        public CallExpression(IExpression fn, IList<IExpression> argexprs, IDictionary<string, IExpression> namedargexprs)
        {
            this.fnexpr = fn;
            this.argexprs = argexprs;
            this.namedargexprs = namedargexprs;
        }

        public IExpression FunctionExpression { get { return this.fnexpr; } }

        public IList<IExpression> ArgumentExpressions { get { return this.argexprs; } }

        public object Evaluate(Context context)
        {
            IFunction fn = (IFunction)this.fnexpr.Evaluate(context);
            IList<object> args = new List<object>();
            IDictionary<string, object> namedargs = new Dictionary<string, object>();

            foreach (var argexpr in this.argexprs)
                args.Add(argexpr.Evaluate(context));

            if (this.namedargexprs != null)
                foreach (var nexpr in this.namedargexprs)
                    namedargs[nexpr.Key] = nexpr.Value.Evaluate(context);

            return fn.Apply(context, args, namedargs);
        }
    }
}
