using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace OracleFix
{
    public class Options
    {
        public event ProgressCallback ProgressCallback;

        public bool RecurseDirectories { get; set; }
        public bool MakeCommandsPublic { get; set; }
        public string RootFolder { get; set; }
        public string FileFilter { get; set; }
        public bool MakeBackup { get; set; }
        public bool FixNullTests { get; set;}
        public bool FixCasts { get; set;}
        public void UpdateProgress(ProgressCallbackArgs pea) {
            if (ProgressCallback != null)
                ProgressCallback(null, pea);
        }

        public Options() {}
        public Options(string[] args) {
            //By default the folder is the current directory
            RootFolder = Directory.GetCurrentDirectory();
            for (int i = 0; i < args.Count(); i++) {
                string arg = args[i].ToUpper();
                if (arg.StartsWith("/FOLDER")) {
                    RootFolder = args[i+1];
                    i++;
                    continue;
                }
                if (arg.StartsWith("/FIXCASTS")) {
                    FixCasts = true;
                    continue;
                }
                if (arg.StartsWith("/FIXNULLTESTS")) {
                    FixNullTests = true;
                    continue;
                }
                if (arg.StartsWith("/PUBLICCOMMANDS")) {
                    MakeCommandsPublic = true;
                    continue;
                }
                if (arg.StartsWith("/MAKEBACKUP")) {
                    MakeBackup = true;
                    continue;
                }
                if (arg.StartsWith("/RECURSE")) {
                    RecurseDirectories = true;
                    continue;
                }
            }
        }
    }

    public delegate void ProgressCallback(object sender, ProgressCallbackArgs args);

    public class ProgressCallbackArgs {
        public ProgressCallbackArgs() {}
        public ProgressCallbackArgs(string status) {
            Status = status;
        }
        public ProgressCallbackArgs(string status,int percent) {
            Status = status;
            PercentComplete = percent;
        }
        public string Status { get; set; }
        public int PercentComplete { get; set; }
    }
}
