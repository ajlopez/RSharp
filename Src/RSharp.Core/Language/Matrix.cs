namespace RSharp.Core.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Matrix
    {
        private IList<Vector> elements;

        public Matrix(IEnumerable<Vector> elements)
        {
            this.elements = new List<Vector>(elements);
        }

        public object this[int index, int index2] 
        {
            get
            {
                return this.elements[index][index2];
            }
        }
    }
}
