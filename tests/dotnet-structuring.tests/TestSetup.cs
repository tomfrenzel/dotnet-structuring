using dotnet_structuring.library;
using dotnet_structuring.library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using static dotnet_structuring.library.StructuringDelegate;

namespace dotnet_structuring.tests
{
    public class TestSetup
    {
        //Setup Variables
        private readonly Template templates = new Template();
        private readonly TempDirectory temp = new TempDirectory();
        public string CurrentLog { get; set; }
        public string Options { get; private set; }
        public string NETCommand { get; private set; }
        public string ProjectName { get; private set; }
        public string OutputDirectory { get; private set; }

        private static List<string> Directories = new List<string>();

        //Setup EventHandler
        public void WireEventHandlers(Structuring e)
        {
            StructuringHandler handler = new StructuringHandler(OnIncommingEventLog);
            e.LogEvent += handler;
        }

        public void OnIncommingEventLog(object sender, EventLogger e)
        {
            CurrentLog = e.logs;
        }

        internal async Task TestTemplate(int i)
        {
            ProjectName = "TestProject";
            OutputDirectory = temp;
            Directories.Add("artifacts");
            Directories.Add("build");
            Directories.Add("docs");
            Directories.Add("lib");
            Directories.Add("samples");
            Directories.Add("packages");
            Directories.Add("test");

            string slelctedTemplate = templates.items[i].ShortName;

            NETCommand = " new " + slelctedTemplate + " " + Options + "-o src/" + ProjectName + " -n " + ProjectName;
            Structuring RunStructuring = new Structuring();
            WireEventHandlers(RunStructuring);
            await RunStructuring.AsyncRunStructuring(OutputDirectory, Directories, NETCommand, ProjectName);
        }
    }
}