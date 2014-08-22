﻿namespace RSharp.Core.Expressions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using RSharp.Core.Operations;

    public class MultiplyExpression : IExpression
    {
        private IExpression leftexpr;
        private IExpression rightexpr;
        private MultiplyOperation oper;

        public MultiplyExpression(IExpression leftexpr, IExpression rightexpr)
        {
            this.leftexpr = leftexpr;
            this.rightexpr = rightexpr;
            this.oper = new MultiplyOperation();
        }

        public IExpression LeftExpression { get { return this.leftexpr; } }

        public IExpression RightExpression { get { return this.rightexpr; } }

        public object Evaluate(Context context)
        {
            return this.oper.Apply(this.leftexpr.Evaluate(context), this.rightexpr.Evaluate(context));
        }
    }
}
