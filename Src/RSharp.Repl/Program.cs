namespace RSharp.Repl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using RSharp.Core.Interpreter;
    using System.IO;
    using RSharp.Core;
    using RSharp.Core.Functions;
    using RSharp.Core.Language;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("RSharp Version 0.0.1 alpha");

            Parser parser = new Parser(new ConsoleReader());
            Context context = new Context();
            context.SetValue("c", new MakeVector());

            for (var expr = parser.ParseExpression(); expr != null; expr = parser.ParseExpression())
            {
                var value = expr.Evaluate(context);

                if (value is Vector)
                    foreach (var line in ((Vector)value).ToLines())
                        Console.WriteLine(line);
                else if (value != null)
                    Console.WriteLine(value.ToString());

                Console.Out.Flush();
            }
        }

        private class ConsoleReader : TextReader
        {
            int lastch;

            public override int Read()
            {
                if (this.lastch == 0 || this.lastch > 0 && ((char)this.lastch) == '\n')
                {
                    Console.Write("> ");
                    Console.Out.Flush();
                }

                this.lastch = Console.In.Read();

                return this.lastch;
            }
        }
    }
}
