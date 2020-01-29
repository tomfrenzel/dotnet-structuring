using dotnet_structuring.library;
using System;
using System.Linq;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using System.Collections.Generic;

namespace dotnet_structuring.console
{
    class Program
    {
        public List<string> Directories = new List<string>();

        public static int Main(string[] args)
        {
            return new Program().Run(args);
        }

        private int Run(string[] args)
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
                        Argument = new Argument<string>(getDefaultValue: () => @"C:\Dev\")
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
                    new Option(
                        "--docs",
                        "Create docs Directory")
                    {
                        Argument = new Argument<bool>(getDefaultValue: () => false)

                    },
                    new Option(
                        "--lib",
                        "Create lib Directory")
                    {
                        Argument = new Argument<bool>(getDefaultValue: () => false)

                    },
                    new Option(
                        "--samples",
                        "Create samples Directory")
                    {
                        Argument = new Argument<bool>(getDefaultValue: () => false)

                    },
                    new Option(
                        "--packages",
                        "Create packages Directory")
                        {
                        Argument = new Argument<bool>(getDefaultValue: () => false)

                    },
                       new Option(
                        "--test",
                        "Create test Directory")
                    {
                        Argument = new Argument<bool>(getDefaultValue: () => false)

                    },
                };
            rootCommand.Add(newCommand);
            rootCommand.Description = "dotnet-structuring";



            newCommand.Handler = CommandHandler.Create(handler);

            // Parse the incoming args and invoke the handler
            return rootCommand.InvokeAsync(args).Result;
        }

        public delegate void Del(string template, string name, string output, bool artifacts, bool build, bool docs, bool lib, bool samples, bool packages, bool test);
        public static async void DelegateMethod(string template, string name, string output, bool artifacts, bool build, bool docs, bool lib, bool samples, bool packages, bool test)
        {
            if (artifacts)
            {
                Directories.Add("artifacts");
            }
            if (build)
            {
                Directories.Add("build");
            }
            if (docs)
            {
                Directories.Add("docs");
            }
            if (lib)
            {
                Directories.Add("lib");
            }
            if (samples)
            {
                Directories.Add("samples");
            }
            if (packages)
            {
                Directories.Add("packages");
            }
            if (test)
            {
                Directories.Add("test");
            }

            NETCommand = " new " + template + " -o src/" + name + " -n " + name;

            Execute execute = new Execute();
            WireEventHandlers(execute);
            await execute.CreateScript(output, Directories, NETCommand, name);


            Console.WriteLine($"The selected Template is: {template}");
            Console.WriteLine($"The Project name is: {name}");
            Console.WriteLine($"The output Directory is: {output}");
            Console.WriteLine($"Build Directory being created?: {build}");
        }
        Del handler = DelegateMethod;


        string CurrentLog;

        public string NETCommand { get; private set; }

        public static void DelegateMethod(string message)
        { 
        }
        private void WireEventHandlers(Execute e)
        {
            ExecutionHandler handler = new ExecutionHandler(OnIncommingEventLog);
            e.LogEvent += handler;
        }

        public void OnIncommingEventLog(object sender, EventLogger e)
        {

            CurrentLog = e.logs;

            Console.WriteLine(CurrentLog + Environment.NewLine);
            if (CurrentLog == "Done.")
            {

            }
        }
    }
}