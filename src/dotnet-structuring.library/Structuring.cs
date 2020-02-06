﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using static dotnet_structuring.library.StructuringDelegate;

namespace dotnet_structuring.library
{
    public class Structuring
    {
        public event StructuringHandler LogEvent;

        private void WriteLog(string logs)
        {
            EventLogger log = new EventLogger
            {
                logs = logs
            };
            LogEvent.Invoke(this, log);
        }

        public async Task AsyncRunStructuring(string Output, IEnumerable<string> Directories, string NETCommand, string ProjectName)
        {
            Output = Output + @"\" + ProjectName;
            DirectoryInfo OutputDirectory = new DirectoryInfo(Output);
            List<string> CommandOutputList = new List<string>();

            //Execute structuring script
            //repeat as many times as there are objects inside the List
            CreateDirectories(Directories, OutputDirectory);
            DirectoryInfo WorkingDir = new DirectoryInfo(OutputDirectory + @"\src\" + ProjectName);
            if (!WorkingDir.Exists)
            {
                await Task.Factory.StartNew(() =>
                {
                    Process p = new Process();

                    p.StartInfo.WorkingDirectory = OutputDirectory.FullName;
                    p.StartInfo.FileName = "dotnet";
                    p.StartInfo.Arguments = NETCommand;
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.CreateNoWindow = true;
                    p.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
                    {
                        // Prepend line numbers to each line of the output.
                        WriteLog(e.Data);
                    });
                    p.Start();

                    p.BeginOutputReadLine();
                    p.EnableRaisingEvents = true;
                    p.Exited += (sender, e) =>
                    {
                        WriteLog("Done.");
                        p.Kill();
                    };
                    p.WaitForExit();
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