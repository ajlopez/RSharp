namespace RSharp.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using RSharp.Core.Expressions;
    using RSharp.Core.Functions;

    public class Machine
    {
        private Context context;

        public Machine()
        {
            this.context = new Context();
            this.context.SetValue("c", new MakeVector());
            this.context.SetValue("return", new Return());
            this.context.SetValue("length", new Length());
        }

        public Context Context { get { return this.context; } }

        public object Evaluate(IExpression expr)
        {
            return expr.Evaluate(this.context);
        }
    }
}
