using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_structuring.library
{
    public delegate void ExecutionHandler(object sender, EventLogger e);

    public class EventLogger : EventArgs
    {
        public string logs;
    }

    public class Execute
    {
        public event ExecutionHandler LogEvent;
        private void FireEvent(string logs)
        {
            EventLogger log = new EventLogger
            {
                logs = logs
            };

            LogEvent.Invoke(this, log);

            log = null;
        }
        public Execute()
        {

        }

        public async Task CreateScript(string OutputDirectory, IEnumerable<string> Directories, string NETCommand, string ProjectName)
        {

            var currentWorkingDir = OutputDirectory + @"\";
            List<string> DirectoryOutputList = new List<string>();
            List<string> CommandOutputList = new List<string>();
            string[] output = new string[] { };


            //Execute structoring script
            //repeat as many times as there are objects inside the array
            for (int i = 0; i < Directories.Count(); i++)
            {
                if (Directories.ElementAt(i) != null)
                {
                    var DirectoryBeingCreated = currentWorkingDir + Directories.ElementAt(i);

                    if (Directory.Exists(DirectoryBeingCreated))
                    {
                        FireEvent("Directory " + DirectoryBeingCreated + " already exists");
                    }
                    else
                    {
                        var result = Directory.CreateDirectory(DirectoryBeingCreated);
                        FireEvent("Directory " + result.FullName + " successfully created!");
                    }
                }
               
                
            }
            if (!Directory.Exists(currentWorkingDir + @"src\" + ProjectName))
            {
                await Task.Factory.StartNew(() =>
                {
                    Process p = new Process();

                    p.StartInfo.WorkingDirectory = currentWorkingDir;
                    p.StartInfo.FileName = "dotnet";
                    p.StartInfo.Arguments = NETCommand;
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.CreateNoWindow = true;
                    p.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
                    {
                        // Prepend line numbers to each line of the output.
                        FireEvent(e.Data);

                    });
                    p.Start();

                    p.BeginOutputReadLine();
                    p.EnableRaisingEvents = true;
                    p.Exited += new EventHandler((sender, e) =>
                    {
                        //FireEvent(Environment.NewLine);
                        FireEvent("Done.");
                        p.Kill();

                    });
                    p.WaitForExit();
                });
               
                //if (test == true)
                //{
                //    p.WaitForExit();
                //}

            }
            else
            {
                FireEvent("A Project with this Name already exists!");
                FireEvent(Environment.NewLine);
                FireEvent("Done.");
            }
        }
    }
}
