namespace RSharp.Core.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

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
    }
}
