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
        private Context rootcontext;

        public Machine()
        {
            this.rootcontext = new Context();
            this.rootcontext.SetValue("c", new MakeVector());
            this.rootcontext.SetValue("return", new Return());
        }

        public Context Context { get { return this.rootcontext; } }

        public object Evaluate(IExpression expr)
        {
            return expr.Evaluate(this.rootcontext);
        }
    }
}
