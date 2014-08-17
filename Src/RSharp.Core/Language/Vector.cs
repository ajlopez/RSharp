namespace RSharp.Core.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using RSharp.Core.Operations;

    public class Vector
    {
        private IList<object> elements;

        public Vector(IEnumerable<object> elements)
        {
            this.elements = new List<object>(elements);
        }

        public int Length { get { return this.elements.Count; } }

        public object this[int index] 
        {
            get
            {
                return this.elements[index];
            }
        }

        public IList<string> ToLines()
        {
            IList<string> lines = new List<string>();

            StringBuilder builder = new StringBuilder();

            builder.Append("[1]");

            foreach (var elem in this.elements)
            {
                builder.Append(" ");
                builder.Append(elem.ToString());
            }

            lines.Add(builder.ToString());

            return lines;
        }

        public object Add(object value)
        {
            if (value is Vector)
                return this.Add((Vector)value);

            var op = new AddOperation();

            IList<object> values = new List<object>();

            foreach (var element in this.elements)
                values.Add(op.Apply(element, value));

            return new Vector(values);
        }

        private Vector Add(Vector value)
        {
            var op = new AddOperation();

            IList<object> values = new List<object>();

            for (int k = 0; k < this.elements.Count; k++)
                values.Add(op.Apply(this.elements[k], value.elements[k]));

            return new Vector(values);
        }
    }
}
