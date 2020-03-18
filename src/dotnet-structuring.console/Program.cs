using dotnet_structuring.library;
using dotnet_structuring.library.Models;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using static dotnet_structuring.library.Helpers.Logging;

namespace dotnet_structuring.console
{
    internal class Program
    {
        private static readonly List<string> Directories = new List<string>();

        public static void Main(string[] args)
        {
            new Program().Setup(args);
        }

        private void Setup(string[] args)
        {
            // Create a root command with some options
            var rootCommand = new RootCommand();
            var teamplateOption = new Option(
                             "--template",
                             "Choose a Template of the 'dotnet new' command")
            {
                Argument = new Argument<string>(getDefaultValue: () => "console")
            };
            var nameOption = new Option(
                        "--name",
                        "Name of the Project being created")
            {
                Argument = new Argument<string>(getDefaultValue: () => "NewApp")
            };
            var outputOption = new Option(
                        "--output",
                        "Output Directory")
            {
                Argument = new Argument<string>(getDefaultValue: () => @"C:\Develop")
            };
            var artifactsOption = new Option(
                        "-a",
                        "Create artifacts Directory")
            {
                Argument = new Argument<bool>(getDefaultValue: () => false)
            };
            artifactsOption.AddAlias("--artifacts");
            var buildOption = new Option(
                        "-b",
                        "Create build Directory")
            {
                Argument = new Argument<bool>(getDefaultValue: () => false)
            };
            buildOption.AddAlias("--build");
            var docsOption = new Option(
                        "-d",
                        "Create docs Directory")
            {
                Argument = new Argument<bool>(getDefaultValue: () => true),
            };
            docsOption.AddAlias("--docs");
            var libOption = new Option(
                        "-l",
                        "Create lib Directory")
            {
                Argument = new Argument<bool>(getDefaultValue: () => false)
            };
            libOption.AddAlias("--lib");
            var samplesOption = new Option(
                        "-s",
                        "Create samples Directory")
            {
                Argument = new Argument<bool>(getDefaultValue: () => false)
            };
            samplesOption.AddAlias("--samples");
            var packagesOption = new Option(
                        "-p",
                        "Create packages Directory")
            {
                Argument = new Argument<bool>(getDefaultValue: () => false)
            };
            packagesOption.AddAlias("--packages");
            var testOption = new Option(
                        "-t",
                        "Create test Directory")
            {
                Argument = new Argument<bool>(getDefaultValue: () => false)
            };
            testOption.AddAlias("--test");
            var newCommand = new Command("new")
                {
                teamplateOption,
                nameOption,
                outputOption,
                artifactsOption,
                buildOption,
                docsOption,
                libOption,
                samplesOption,
                packagesOption,
                testOption
                };
            rootCommand.Add(newCommand);
            rootCommand.Description = "dotnet-structuring";
            newCommand.Handler = CommandHandler.Create(@delegate);

            // Parse the incoming args and invoke the handler
            rootCommand.InvokeAsync(args).Wait();
        }

        public delegate void SetupDelegate(string template, string name, string output, bool a, bool b, bool d, bool l, bool s, bool p, bool t);

        public static void Run(string template, string name, string output, bool a, bool b, bool d, bool l, bool s, bool p, bool t)
        {
            string NETCommand;

            if (a)
            {
                Directories.Add("artifacts");
            }
            if (b)
            {
                Directories.Add("build");
            }
            if (d)
            {
                Directories.Add("docs");
            }
            if (l)
            {
                Directories.Add("lib");
            }
            if (s)
            {
                Directories.Add("samples");
            }
            if (p)
            {
                Directories.Add("packages");
            }
            if (t)
            {
                Directories.Add("test");
            }

            NETCommand = $" new {template} -o src/{name} -n {name}";
            StandardProcess process = new StandardProcess();
            Structuring execute = new Structuring(process);
            WireEventHandlers(execute);
            execute.RunStructuringAsync(output, Directories, NETCommand, name).Wait();
        }

        private readonly SetupDelegate @delegate = Run;

        public static void WireEventHandlers(Structuring structuring)
        {
            StructuringHandler handler = new StructuringHandler(OnIncommingEventLog);
            structuring.LogEvent += handler;
        }

        public static void OnIncommingEventLog(object sender, string eventMessage)
        {
            Console.WriteLine(eventMessage + Environment.NewLine);
        }
    }
}