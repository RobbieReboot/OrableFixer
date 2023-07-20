using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OracleFix;

namespace OrableFixerCommandLine
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new Options(args);
            options.ProgressCallback += new ProgressCallback(opts_ProgressCallback);

            Processor.Process(options);
            Console.WriteLine("Done.");
        }
        static void opts_ProgressCallback(object sender, ProgressCallbackArgs args)
        {
            Console.WriteLine(args.Status);
        }

    }
}
