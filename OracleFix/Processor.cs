using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OracleFix
{
    public class Processor
    {
        private static Options currentOptions { get; set; }

        public static void Process(Options opts) {
            currentOptions = opts;
            ProcessFolder(opts.RootFolder,opts);
        }

        private static void Progress(string message) {
            currentOptions.UpdateProgress(new ProgressCallbackArgs(message,0));
        }

        private static void ProcessFolder(string rootDir,Options options) {
            try {
                if (options.RecurseDirectories) {
                    foreach (var dir in Directory.GetDirectories(rootDir)) {
                        ProcessFolder(dir, options);
                        ProcessFiles(options,dir);
                    }
                } else {
                    ProcessFiles(options, rootDir);
                }
            }
            catch (Exception ex) {
                options.UpdateProgress(new ProgressCallbackArgs(ex.Message,0));
            }
        }

        private static void ProcessFiles(Options options, string rootDir) {
            try {
                foreach (string file in Directory.GetFiles(rootDir, "*.designer.cs")) {
                    ProcessFile(file, options);
                }
            }
            catch (UnauthorizedAccessException uaex) {
                options.UpdateProgress(new ProgressCallbackArgs(uaex.Message, 0));
            }
        }

        private static void ProcessFiles(string folder,Options options) {
            
        }
        private static void ProcessFile(string fileName,Options options) {
            string fileHeader = string.Format("{0} : Loading ...", fileName);
            var oracleFile = new OracleFile(fileName);
            fileHeader = fileHeader + oracleFile.TotalLines + " Lines";
            options.UpdateProgress(new ProgressCallbackArgs(fileHeader));
            if (oracleFile.IsAlreadyModified()) {
                options.UpdateProgress(new ProgressCallbackArgs(string.Format("{0} is already fixed.",Path.GetFileName(fileName))));
                return;
            }
            if (!oracleFile.ContainsTableAdapters()) {
                options.UpdateProgress(new ProgressCallbackArgs(string.Format("{0} doesn't contain TableAdapters.",Path.GetFileName(fileName))));
                return;
            }
            if (options.MakeBackup) {
                var backupNo = 1;
                var backupName = Path.ChangeExtension(fileName, string.Format(".{0:000}.cs", backupNo));
                while (File.Exists(backupName)) {
                    backupNo++;
                    backupName = Path.ChangeExtension(fileName, string.Format(".{0:000}.cs", backupNo));
                }
                options.UpdateProgress(new ProgressCallbackArgs("Saving backup : "+backupName));
                oracleFile.Save(backupName);
            }
            oracleFile.Fix(options);
            options.UpdateProgress(new ProgressCallbackArgs("Saving modified file."));
            ShowStats(oracleFile);
            oracleFile.Save(fileName);
        }

        private static void ShowStats(OracleFile oracleFile) {
            if (oracleFile.IDbCommandFixes != 0) {
                currentOptions.UpdateProgress(new ProgressCallbackArgs(
                                           string.Format("Fixed {0} IDbCommandCollection{1:s;; }",
                                                         oracleFile.IDbCommandFixes,
                                                         oracleFile.IDbCommandFixes - 1)));
            }
            if (oracleFile.CommandCollectionsFixes != 0) {
                currentOptions.UpdateProgress(new ProgressCallbackArgs(
                                           string.Format("Fixed {0} IDbCommandCollection{1:s;; }",
                                                         oracleFile.CommandCollectionsFixes,
                                                         oracleFile.CommandCollectionsFixes - 1)));
            }
            if (oracleFile.NullCheckWithAdapterFixes != 0) {
                currentOptions.UpdateProgress(new ProgressCallbackArgs(
                                           string.Format("Fixed {0} Null Check{1:s ;; } on Adapter{1:s ;; }",
                                                         oracleFile.NullCheckWithAdapterFixes,
                                                         oracleFile.NullCheckWithAdapterFixes - 1)));
            }
            if (oracleFile.NullCheckWithCommandFixes != 0) {
                currentOptions.UpdateProgress(new ProgressCallbackArgs(
                                           string.Format("Fixed {0} Null Check{1:s ;; } on Command{1:s ;; }",
                                                         oracleFile.NullCheckWithCommandFixes,
                                                         oracleFile.NullCheckWithCommandFixes - 1)));
            }
            if (oracleFile.CastFixes != 0) {
                currentOptions.UpdateProgress(new ProgressCallbackArgs(
                                           string.Format("Fixed {0} Cast{1:s ;; }", oracleFile.CastFixes,
                                                         oracleFile.CastFixes - 1)));
            }
            if (oracleFile.NullableCastFixes != 0) {
                currentOptions.UpdateProgress(new ProgressCallbackArgs(
                                           string.Format("Fixed {0} Nullable Cast{1:s ;; }",
                                                         oracleFile.NullableCastFixes,
                                                         oracleFile.NullableCastFixes - 1)));
            }
        }
    }    
}
