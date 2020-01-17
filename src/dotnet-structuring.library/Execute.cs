using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RunProcessAsTask;

namespace dotnet_structuring.library
{
    public delegate void ExecutionHandler(object sender, EventLogger e);

    public class EventLogger : EventArgs
    {
        public string[] logs;
    }

    public class Execute
    {
        public event ExecutionHandler LogEvent;
        private void FireEvent(string[] logs)
        {
            EventLogger log = new EventLogger();
            log.logs = logs;

            LogEvent?.Invoke(this, log);

            log = null;
        }
        public Execute()
        {

        }
        public async void CreateScriptAsync(string[] Directories, string Command, string ProjectName)
        {

            var currentWorkingDir = Directories[0] + @"\";
            List<string> DirectoryOutputList = new List<string>();
            List<string> CommandOutputList = new List<string>();
            string[] output = new string[] { };


            //Execute structoring script
            //repeat as many times as there are objects inside the array
            for (int i = 1; i < Directories.Length; i++)
            {
                //make sure that the selected object isn't No. 10 (dotnet new command)
                var DirectoryBeingCreated = currentWorkingDir + Directories[i];
                //only execute if currentWorkingDir isn't the same as currentWorkingDir + commands[i]
                if (DirectoryBeingCreated != currentWorkingDir)
                {
                    if (Directory.Exists(DirectoryBeingCreated))
                    {
                        DirectoryOutputList.Add("Directory " + DirectoryBeingCreated + " already exists");

                    }
                    else
                    {
                        var result = Directory.CreateDirectory(DirectoryBeingCreated);
                        DirectoryOutputList.Add("Directory " + result.FullName + " successfully created!");

                    }
                }
            }
            FireEvent(DirectoryOutputList.ToArray());
            if (!Directory.Exists(currentWorkingDir + @"src\" + ProjectName))
            {
                var processStartInfo = new ProcessStartInfo
                {
                    WorkingDirectory = currentWorkingDir,
                    FileName = "dotnet",
                    Arguments = Command,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                };
                using (var cancellationTokenSource = new CancellationTokenSource())
                {
                    var processResults = await ProcessEx.RunAsync(processStartInfo);
                    //File.WriteAllText("C:/log.txt", processResults.StandardOutput);
                    for (int r = 0; r < processResults.StandardOutput.Length; r++)
                    {
                        CommandOutputList.Add(processResults.StandardOutput[r]);
                    }
                }
            }
            else
            {
                CommandOutputList.Add("A Project with this Name already exists!");
            }
            FireEvent(CommandOutputList.ToArray());

        }


    }
}
