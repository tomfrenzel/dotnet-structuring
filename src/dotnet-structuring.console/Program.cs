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
            var teamplateOption = new Option("--template", "Choose a Template of the 'dotnet new' command")
            {
                Argument = new Argument<string>(getDefaultValue: () => "console")
            };

            var nameOption = new Option("--name", "Name of the Project being created")
            {
                Argument = new Argument<string>(getDefaultValue: () => "NewApp")
            };

            var outputOption = new Option("--output", "Output Directory")
            {
                Argument = new Argument<string>(getDefaultValue: () => @"C:\Develop")
            };

            var artifactsOption = new Option("--artifacts", "Create artifacts Directory")
            {
                Argument = new Argument<bool>(getDefaultValue: () => false)
            };
            artifactsOption.AddAlias("-a");

            var buildOption = new Option("--build", "Create build Directory")
            {
                Argument = new Argument<bool>(getDefaultValue: () => false)
            };
            buildOption.AddAlias("-b");

            var docsOption = new Option("--docs", "Create docs Directory")
            {
                Argument = new Argument<bool>(getDefaultValue: () => true),
            };
            docsOption.AddAlias("-d");

            var libOption = new Option("--lib", "Create lib Directory")
            {
                Argument = new Argument<bool>(getDefaultValue: () => false)
            };
            libOption.AddAlias("-l");

            var samplesOption = new Option("--samples", "Create samples Directory")
            {
                Argument = new Argument<bool>(getDefaultValue: () => false)
            };
            samplesOption.AddAlias("-s");

            var packagesOption = new Option("--packages", "Create packages Directory")
            {
                Argument = new Argument<bool>(getDefaultValue: () => false)
            };
            packagesOption.AddAlias("-p");

            var testOption = new Option("--test", "Create test Directory")
            {
                Argument = new Argument<bool>(getDefaultValue: () => false)
            };
            testOption.AddAlias("-t");
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

        public delegate void SetupDelegate(string template, string name, string output, bool artifacts, bool build, bool docs, bool lib, bool samples, bool packages, bool test);

        public static void Run(string template, string name, string output, bool artifacts, bool build, bool docs, bool lib, bool samples, bool packages, bool test)
        {
            string NETCommand;

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