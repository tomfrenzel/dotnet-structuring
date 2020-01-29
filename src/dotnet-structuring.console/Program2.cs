using dotnet_structuring.library;
using System;
using System.Linq;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using System.Collections.Generic;

namespace dotnet_structuring.console
{
    class Program2
    {
        static List<string> Directories = new List<string>();

        static string NETCommand;
        public static void Main(string[] args)
        {
            new Program2().Run(args);
        }

        private void Run(string[] args)
        {
            // Create a root command with some options
            var rootCommand = new RootCommand();

            var newCommand = new Command("new")
                {
                    new Option(
                        "-template",
                        "Choose a Template of the 'dotnet new' command")
                    {
                        Argument = new Argument<string>(getDefaultValue: () => "console")
                    },
                    new Option(
                        "-name",
                        "Name of the Project being created")
                    {
                        Argument = new Argument<string>(getDefaultValue: () => "NewApp")
                    },
                    new Option(
                        "-output",
                        "Output Directory")
                    {
                        Argument = new Argument<string>(getDefaultValue: () => @"C:\Develop\Test")
                    },
                    new Option(
                        "--artifacts",
                        "Create artifacts Directory")
                    {
                        Argument = new Argument<bool>(getDefaultValue: () => false)

                    },
                    new Option(
                        "--build",
                        "Create build Directory")
                    {
                        Argument = new Argument<bool>(getDefaultValue: () => false)

                    },
                };
            rootCommand.Add(newCommand);
            rootCommand.Description = "dotnet-structuring";



            newCommand.Handler = CommandHandler.Create<string, string, string, bool, bool>(async (template, name, output, artifacts, build) =>
            {
                if (artifacts)
                {
                    Directories.Add("artifacts");
                }
                if (build)
                {
                    Directories.Add("build");
                }

                NETCommand = " new " + template + " -o src/" + name + " -n " + name;

                Execute execute = new Execute();
                WireEventHandlers(execute);
                await execute.CreateScript(output, Directories, NETCommand, name);
            }
            );

            // Parse the incoming args and invoke the handler
            newCommand.InvokeAsync(args).Wait();
        }

        static string CurrentLog;
        public static void WireEventHandlers(Execute e)
        {
            ExecutionHandler handler = new ExecutionHandler(OnIncommingEventLog);
            e.LogEvent += handler;
        }

        public static void OnIncommingEventLog(object sender, EventLogger e)
        {

            CurrentLog = e.logs;

            Console.WriteLine(CurrentLog + Environment.NewLine);
            if (CurrentLog == "Done.")
            {

            }
        }
    }
}