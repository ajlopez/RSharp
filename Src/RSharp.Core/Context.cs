namespace RSharp.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Context
    {
        private Context parent;
        private IDictionary<string, object> values = new Dictionary<string, object>();
        private bool hasReturnValue;
        private object returnValue;

        public Context()
        {
        }

        public Context(Context parent)
        {
            this.parent = parent;
        }

        public bool HasReturnValue { get { return this.hasReturnValue; } }

        public object ReturnValue
        {
            get
            {
                return this.returnValue;
            }

            set
            {
                this.returnValue = value;
                this.hasReturnValue = true;
            }
        }

        public void SetValue(string name, object value)
        {
            this.values[name] = value;
        }

        public object GetValue(string name)
        {
            if (this.values.ContainsKey(name))
                return this.values[name];

            if (this.parent != null)
                return this.parent.GetValue(name);

            return null;
        }
    }
}
