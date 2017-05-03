using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FsiRun
{

    class Program
    {
        static ProcessStartInfo GetStartInfo(string cmd, string args) => new ProcessStartInfo
        {
            CreateNoWindow = false,
            UseShellExecute = false,
            FileName = cmd,
            Arguments = args
        };

        static int Main(string[] args)
        {
            var fsitemplate = @"{0}\Microsoft SDKs\F#\{1}\Framework\v4.0\fsi.exe";
            var pgmfiles = Environment.GetEnvironmentVariable("programfiles(x86)");
            var versions = new[] { "4.1", "4.0" };
            var fsiPath = versions.Select(v => string.Format(fsitemplate, pgmfiles, v))
                .Where(File.Exists).FirstOrDefault();
            if (fsiPath == null)
            {
                // just hope it's on path
                fsiPath = "fsi.exe";
            }

            var si = GetStartInfo(fsiPath, string.Join(" ", args));
            var p = Process.Start(si);
            p.WaitForExit();
            return p.ExitCode;
        }
    }
}
