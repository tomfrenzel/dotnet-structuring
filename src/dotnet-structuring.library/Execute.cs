using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

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
            EventLogger log = new EventLogger();
            log.logs = logs;

            LogEvent.Invoke(this, log);

            log = null;
        }
        public Execute()
        {

        }
        public void CreateScript(string[] Directories, string Command, string ProjectName, bool test)
        {

            var currentWorkingDir = Directories[0] + @"\";
            List<string> DirectoryOutputList = new List<string>();
            List<string> CommandOutputList = new List<string>();
            string[] output = new string[] { };


            //Execute structoring script
            //repeat as many times as there are objects inside the array
            for (int i = 1; i < Directories.Length; i++)
            {
                if (Directories[i] != null)
                {
                    var DirectoryBeingCreated = currentWorkingDir + Directories[i];

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
                Process p = new Process();

                p.StartInfo.WorkingDirectory = currentWorkingDir;
                p.StartInfo.FileName = "dotnet";
                p.StartInfo.Arguments = Command;
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
                    FireEvent(Environment.NewLine);
                    FireEvent("Done.");
                    p.Kill();

                });
                if (test == true)
                {
                    p.WaitForExit();
                }
                
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
