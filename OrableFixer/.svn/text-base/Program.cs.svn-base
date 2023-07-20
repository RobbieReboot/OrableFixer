using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace OrableFixer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            
        }

        //static void RunFromCommandLine(IEnumerable<string> args) {
        //    var rootPath = Directory.GetCurrentDirectory();
        //    var recurse = false;
        //    var makeCommandsPublic = false;
            
        //    foreach (var s in args) {
        //        switch (s.Substring(0,2).ToUpper()) {
        //            case "/P" :
        //                rootPath = s.Substring(2);
        //                break;
        //            case "/R":
        //                recurse = true;
        //                break;
        //            case "/C":
        //                makeCommandsPublic = true;
        //                break;
        //            default :
        //                Console.WriteLine("Unknown parameter " + s);
        //                break;
        //        }
        //    }
        //    OracleFix.Processor.ProcessFolder(rootPath,recurse,makeCommandsPublic);
        //}


        //private static void ShowStats(OracleFile oracleFile) {
        //    if (oracleFile.IDbCommandFixes != 0) {
        //        Console.WriteLine(
        //            string.Format("Fixed {0} IDbCommandCollection{1:s;; }", oracleFile.IDbCommandFixes,
        //                          oracleFile.IDbCommandFixes - 1));
        //    }
        //    if (oracleFile.CommandCollectionsFixes != 0) {
        //        Console.WriteLine(
        //            string.Format("Fixed {0} IDbCommandCollection{1:s;; }", oracleFile.CommandCollectionsFixes,
        //                          oracleFile.CommandCollectionsFixes - 1));
        //    }
        //    if (oracleFile.NullCheckWithAdapterFixes != 0) {
        //        Console.WriteLine(
        //            string.Format("Fixed {0} Null Check{1:s ;; } on Adapter{1:s ;; }",
        //                          oracleFile.NullCheckWithAdapterFixes, oracleFile.NullCheckWithAdapterFixes - 1));
        //    }
        //    if (oracleFile.NullCheckWithCommandFixes != 0) {
        //        Console.WriteLine(
        //            string.Format("Fixed {0} Null Check{1:s ;; } on Command{1:s ;; }",
        //                          oracleFile.NullCheckWithCommandFixes, oracleFile.NullCheckWithCommandFixes - 1));
        //    }
        //    if (oracleFile.CastFixes != 0) {
        //        Console.WriteLine(
        //            string.Format("Fixed {0} Cast{1:s ;; }", oracleFile.CastFixes, oracleFile.CastFixes - 1));
        //    }
        //    if (oracleFile.NullableCastFixes != 0) {
        //        Console.WriteLine(
        //            string.Format("Fixed {0} Nullable Cast{1:s ;; }", oracleFile.NullableCastFixes,
        //                          oracleFile.NullableCastFixes - 1));
        //    }
        //}
    }
}
