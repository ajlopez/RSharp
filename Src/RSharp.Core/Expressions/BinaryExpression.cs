namespace RSharp.Core.Expressions
{
    using System;
    using RSharp.Core.Operations;

    public class BinaryExpression : IExpression
    {
        private IBinaryOperation operation;
        private IExpression leftexpression;
        private IExpression rightexpression;

        public BinaryExpression(IBinaryOperation operation, IExpression leftexpression, IExpression rightexpression)
        {
            this.operation = operation;
            this.leftexpression = leftexpression;
            this.rightexpression = rightexpression;
        }

        public IBinaryOperation BinaryOperation { get { return this.operation; } }

        public IExpression LeftExpression { get { return this.leftexpression; } }

        public IExpression RightExpression { get { return this.rightexpression; } }

        public object Evaluate(Context context)
        {
            return this.operation.Apply(this.leftexpression.Evaluate(context), this.rightexpression.Evaluate(context));
        }
    }
}
