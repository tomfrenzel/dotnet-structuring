using dotnet_structuring.library.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using static dotnet_structuring.library.StructuringDelegate;

namespace dotnet_structuring.library
{
    public class Structuring
    {
        private readonly ICustomProcess baseProcess;

        public event StructuringHandler LogEvent;

        public Structuring(ICustomProcess baseProcess)
        {
            this.baseProcess = baseProcess;
        }

        private void WriteLog(string logs)
        {
            EventLogger log = new EventLogger
            {
                Logs = logs
            };
            LogEvent.Invoke(this, log);
        }

        public async Task RunStructuringAsync(string Output, IEnumerable<string> Directories, string NETCommand, string ProjectName)
        {
            DirectoryInfo OutputDirectory = new DirectoryInfo(Output + @"\" + ProjectName);

            if (!OutputDirectory.Exists)
            {
                Directory.CreateDirectory(OutputDirectory.FullName);
                CreateDirectories(Directories, OutputDirectory);

                await Task.Factory.StartNew(() =>
                {
                    baseProcess.StartInfo.WorkingDirectory = OutputDirectory.FullName;
                    baseProcess.StartInfo.FileName = "dotnet";
                    baseProcess.StartInfo.Arguments = NETCommand;
                    baseProcess.StartInfo.UseShellExecute = false;
                    baseProcess.StartInfo.RedirectStandardOutput = true;
                    baseProcess.StartInfo.CreateNoWindow = true;
                    baseProcess.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
                    {
                        // Prepend line numbers to each line of the output.
                        WriteLog(e.Data);
                    });

                    baseProcess.EnableRaisingEvents = true;
                    baseProcess.Exited += (sender, e) =>
                    {
                        WriteLog("Done.");
                        baseProcess.Kill();
                    };
                    baseProcess.Start();
                    baseProcess.WaitForExit();
                });
            }
            else
            {
                WriteLog("A Project with this Name already exists!");
            }
        }

        private void CreateDirectories(IEnumerable<string> Directories, DirectoryInfo OutputDirectory)
        {
            foreach (string element in Directories)
            {
                if (element != null)
                {
                    var DirectoryBeingCreated = OutputDirectory + @"\" + element;

                    if (Directory.Exists(DirectoryBeingCreated))
                    {
                        WriteLog("Directory " + DirectoryBeingCreated + " already exists");
                    }
                    else
                    {
                        var result = Directory.CreateDirectory(DirectoryBeingCreated);
                        WriteLog("Directory " + result.FullName + " successfully created!");
                    }
                }
            }
        }
    }
}