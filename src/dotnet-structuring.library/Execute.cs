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
    public class Execute
    {
        public async Task<string[]> CreateScriptAsync(string[] Directories, string Command, string ProjectName)
        {
            var currentWorkingDir = Directories[0] + @"\";
            List<string> OutputList = new List<string>();
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
                        OutputList.Add("Directory " + DirectoryBeingCreated + " already exists");

                    }
                    else
                    {
                        var result = Directory.CreateDirectory(DirectoryBeingCreated);
                        OutputList.Add("Directory " + result.FullName + " successfully created!");

                    }
                }
            }

            if (!Directory.Exists(currentWorkingDir + @"src\" + ProjectName)) { 
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
                    OutputList.Add(processResults.StandardOutput[r]);
                }
            }
        }
            else
            {
                OutputList.Add("A Project with this Name already exists!");
            }
            output = OutputList.ToArray();
            return output;

        }

    }
}
