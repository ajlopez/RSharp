﻿namespace RSharp.Core.Interpreter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public enum TokenType
    {
        Name,
        Logical,
        Integer,
        Real,
        String,
        Operator,
        Delimiter,
        EndOfLine
    }
}
