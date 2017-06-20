namespace RSharp.Core.Operations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using RSharp.Core.Language;

    public class SequenceOperation : IBinaryOperation
    {
        private static SequenceOperation instance = new SequenceOperation();

        public static SequenceOperation Instance
        {
            get
            {
                return instance;
            }
        }

        public object Apply(object left, object right)
        {
            int from = (int)left;
            int to = (int)right;

            int[] values = new int[to - from + 1];

            for (int k = 0; k < values.Length; k++)
                values[k] = k + from;

            return new Vector(values.Select(i => (object)i));
        }
    }
}
