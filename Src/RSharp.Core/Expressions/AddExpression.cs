namespace RSharp.Core.Expressions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using RSharp.Core.Operations;

    public class AddExpression : IExpression
    {
        private IExpression leftexpr;
        private IExpression rightexpr;
        private AddOperation oper;

        public AddExpression(IExpression leftexpr, IExpression rightexpr)
        {
            this.leftexpr = leftexpr;
            this.rightexpr = rightexpr;
            this.oper = new AddOperation();
        }

        public object Evaluate(Context context)
        {
            return this.oper.Apply(this.leftexpr.Evaluate(context), this.rightexpr.Evaluate(context));
        }
    }
}
