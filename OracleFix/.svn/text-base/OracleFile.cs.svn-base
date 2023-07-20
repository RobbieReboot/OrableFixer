
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace OracleFix {

    //DONE: add the using directive 
    //TODO: Map rest of oracle types.
    //DONE: Tag fixed files to preven ANY processing
    //DONE: Remember user prefs.

    // using Oracle.DataAccess.Types;

    public class OracleFile
    {
        private readonly List<string> fileLines = new List<string>();
        private const string commentLine = "\t\t\t//BUG: Fixed by the Orable File Fixer!";
        private Options Options { get; set;}
        public int TotalLines { get { return fileLines.Count; }}
        public int CommandCollectionsFixes { get; set; }
        public int IDbCommandFixes { get; set; }
        public int NullCheckWithAdapterFixes { get; set; }
        public int NullCheckWithCommandFixes { get; set; }
        public int CastFixes { get; set; }
        public int NullableCastFixes { get; set;}
        public string CurrentFile { get; set;}

        public OracleFile(string fileName) {
            CurrentFile = fileName;
            Open(fileName);
        }
        public bool IsAlreadyModified() {
            if (
                (fileLines[4].Contains("OrableFixer"))
                )
                    return true;
            return false;
        }
        public bool ContainsTableAdapters() {
            if (
                (fileLines[11].Contains("TableAdapter"))
                )
                    return true;
            return false;
        }

        private void Open(string fileName) {
            fileLines.AddRange(File.ReadAllLines(fileName));
        }
        public void Save(string fileName) {
            File.WriteAllLines(fileName,fileLines.ToArray());
        }

        public void Fix(Options options) {
            if ( (IsAlreadyModified()) || (!ContainsTableAdapters()))
                return;
            for (int lineNo = 0; lineNo < fileLines.Count; lineNo++) {
                if (options.MakeCommandsPublic) {
                    if (FixIDbCommandCollections(lineNo))
                        continue;
                    if (FixCommandCollections(lineNo))
                        continue;
                }
                if (options.FixNullTests) {
                    if (FixNullCheckWithAdapter(lineNo)) {
                        lineNo += 2;
                        continue;
                    }
                    if (FixNullCheckWithCommand(lineNo)) {
                        lineNo += 2;
                        continue;
                    }
                }
                if (options.FixCasts) {
                    if (FixCasts(lineNo))
                        continue;
                    if (FixNullableCasts(lineNo))
                        continue;
                }
            }
            InsertNewUsingDirectives();
            InsertModifiedTag();
        }

        private void InsertModifiedTag() {
            fileLines[4] = string.Format("//     Modified by OrableFixer on {0}", DateTime.Now);
        }

        private void InsertNewUsingDirectives() {
            if (string.IsNullOrEmpty(fileLines[15])) {
                fileLines.Insert(15,string.Empty);
                fileLines.Insert(15, "using Oracle.DataAccess.Types;");
                fileLines.Insert(15,string.Empty);
            }
        }

        private bool FixIDbCommandCollections(int lineNo) {
            const string dbCommandString = "protected global::System.Data.IDbCommand[] CommandCollection";
            if (fileLines[lineNo].Trim().StartsWith(dbCommandString)) {
                //change the protected part to public
                fileLines[lineNo] = fileLines[lineNo].Replace("protected", "public");
                IDbCommandFixes++;
                return true;
            }
            return false;
        }

        private bool FixCommandCollections(int lineNo) {
            const string dbCommandString = "protected global::Oracle.DataAccess.Client.OracleCommand[] CommandCollection";
            if (fileLines[lineNo].Trim().StartsWith(dbCommandString)) {
                //change the protected part to public
                fileLines[lineNo] = fileLines[lineNo].Replace("protected", "public");
                CommandCollectionsFixes++;
                return true;
            }
            return false;
        }

        private bool FixNullCheckWithAdapter(int lineNo) {
            var reg = new Regex(@"^\s*if\s*\(\(\(this\.Adapter\.SelectCommand\.Parameters\[(?<paramId>\d+)\]");
            Match m = reg.Match(fileLines[lineNo]);
            if (m.Success) {
                //if the comparison is for an Object then the dbnull check seems ok.
                if (fileLines[lineNo + 2].Contains("global::System.DBNull.Value"))
                    return true;
                NullCheckWithAdapterFixes++;
                //erase the offending lines & replace with proper null check
                fileLines[lineNo++] = commentLine;
                fileLines[lineNo] = string.Format(
                    "\t\t\tif (((INullable)this.Adapter.SelectCommand.Parameters[{0}].Value).IsNull) {{",
                    m.Groups["paramId"].Value);
                return true;
            }
            return false;
        }



        private bool FixNullCheckWithCommand(int lineNo) {
            var reg = new Regex(@"^\s*if\s*\(\(\(command\.Parameters\[(?<paramId>\d+)\]");
            Match m2 = reg.Match(fileLines[lineNo]);
            if (m2.Success) {
                //if the comparison is for an Object then the dbnull check seems ok.
                if (fileLines[lineNo+2].Contains("global::System.DBNull.Value"))
                    return true;
                NullCheckWithCommandFixes++;
                //erase the offending lines & replace with proper null check
                fileLines[lineNo++] = commentLine;
                fileLines[lineNo] = string.Format(
                    "\t\t\tif (((INullable)command.Parameters[{0}].Value).IsNull) {{",m2.Groups["paramId"].Value);
                return true;
            }
            return false;
        }


        private bool FixCasts(int lineNo) {
            var reg = new Regex(@"(?<indentLevel>\s*)(?<varName>\w+)\s*=\s*\(\((?<typeName>\w+)\)\((?<cmd>[\w+\.]+)\[(?<paramIndex>\d+)\]\.Value\)\);");
//            var reg = new Regex(@"(?<indentLevel>\s*)(?<varName>\w+)\s*=\s*\(\((?<typeName>\w+)\)\(this\.Adapter\.SelectCommand\.Parameters\[(?<paramIndex>\d+)\]\.Value");
            Match m = reg.Match(fileLines[lineNo]);
            if (m.Success && m.Groups.Count == 6 && !fileLines[lineNo].Contains("(object)")) {
                fileLines[lineNo] = string.Format(
                    "{0}{1} = (({2})({3})({6}[{4}].Value));\t{5}",
                    m.Groups["indentLevel"].Value,
                    m.Groups["varName"].Value,
                    m.Groups["typeName"].Value,
                    ClrTypeToOracleType(m.Groups["typeName"].Value),
                    m.Groups["paramIndex"].Value,
                    commentLine,
                    m.Groups["cmd"]);
                CastFixes++;
                return true;
            }
            return false;
        }

        private bool FixNullableCasts(int lineNo) {
            //Fix the nullables casts too. line 233
            var reg = new Regex(@"(?<indentLevel>\s*)(?<varName>\w+)\s*=\s*new\s*\w+::\w+\.\w+<\w+>\(\(\((?<typeName>\w+)\)\(this\.Adapter\.SelectCommand\.Parameters\[(?<paramIndex>\d+)\]\.Value\)\)\);");
            Match m = reg.Match(fileLines[lineNo]);
            if (m.Success && m.Groups.Count == 5 && !fileLines[lineNo].Contains("(object)")) {
                fileLines[lineNo] = string.Format(
                    "{0}{1} = new global::System.Nullable<{2}>(({2})({3})(this.Adapter.SelectCommand.Parameters[{4}].Value));\t{5}",
                    m.Groups["indentLevel"].Value,
                    m.Groups["varName"].Value,
                    m.Groups["typeName"].Value,
                    ClrTypeToOracleType(m.Groups["typeName"].Value),
                    m.Groups["paramIndex"].Value,commentLine);
                NullableCastFixes++;
                return true;
            }
            var reg2 = new Regex(@"(?<indentLevel>\s*)(?<varName>\w+)\s*=\s*new\s*\w+::\w+\.\w+<\w+>\(\(\((?<typeName>\w+)\)\(command\.Parameters\[(?<paramIndex>\d+)\]\.Value\)\)\);");
            m = reg2.Match(fileLines[lineNo]);
            if (m.Success && m.Groups.Count == 5 && !fileLines[lineNo].Contains("(object)")) {
                fileLines[lineNo] = string.Format(
                    "{0}{1} = new global::System.Nullable<{2}>(({2})({3})(command.Parameters[{4}].Value));\t{5}",
                    m.Groups["indentLevel"].Value,
                    m.Groups["varName"].Value,
                    m.Groups["typeName"].Value,
                    ClrTypeToOracleType(m.Groups["typeName"].Value),
                    m.Groups["paramIndex"].Value,commentLine);
                NullableCastFixes++;
                return true;
            }
            return false;
        }

        private static string ClrTypeToOracleType(string clrType) {
            switch(clrType) {
                case "string" :
                    return "OracleString";
                case "decimal" :
                    return "OracleDecimal";
                default:
                    return "UnknownType";
            }
        }
    }
}