namespace RSharp.Core.Expressions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using RSharp.Core.Functions;
    using RSharp.Core.Language;

    public class ArrayAccessExpression : IExpression
    {
        private IExpression arrexpr;
        private IList<IExpression> argexprs;

        public ArrayAccessExpression(IExpression fn, IList<IExpression> argexprs)
        {
            this.arrexpr = fn;
            this.argexprs = argexprs;
        }

        public IExpression ArrayExpression { get { return this.arrexpr; } }

        public IList<IExpression> ArgumentExpressions { get { return this.argexprs; } }

        public object Evaluate(Context context)
        {
            Vector vector = (Vector)this.arrexpr.Evaluate(context);
            IList<object> args = new List<object>();

            return vector[(int)this.argexprs[0].Evaluate(context)];
        }
    }
}
