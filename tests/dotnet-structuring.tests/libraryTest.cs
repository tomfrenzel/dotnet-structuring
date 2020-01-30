using dotnet_structuring.library;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;


namespace dotnet_structuring.tests
{
    public class TestSetup
    {
        //Setup Variables
        Templates __ = new Templates();
        TempDirectory temp = new TempDirectory();
        public string CurrentLog { get; set; }
        public string Options { get; private set; }
        public string NETCommand { get; private set; }
        public string ProjectName { get; private set; }
        public string OutputDirectory { get; private set; }

        static List<string> Directories = new List<string>();

        //Setup EventHandler
        public void WireEventHandlers(Execute e)
        {
            ExecutionHandler handler = new ExecutionHandler(OnIncommingEventLog);
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

            __.SelcectTemplate(i);
            NETCommand = " new " + __.SelectedTemplate + " " + Options + "-o src/" + __.SelectedTemplate.Replace(" ", "_") + " -n " + __.SelectedTemplate.Replace(" ", "_");
            Execute ExecuteClass = new Execute();
            WireEventHandlers(ExecuteClass);
            await ExecuteClass.CreateScript(OutputDirectory, Directories, NETCommand, ProjectName);
        }
    }
    [Collection("Create All types of .NET Applications")]
    public class FullTest
    {
        TestSetup _ = new TestSetup();
        [Fact]
        public async void console()
        {
            await _.TestTemplate(1);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public async void classlib()
        {
            await _.TestTemplate(2);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public async void mstest()
        {
            await _.TestTemplate(3);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public async void nunit()
        {
            await _.TestTemplate(4);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public async void nunittest()
        {
            await _.TestTemplate(5);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public async void xunit()
        {
            await _.TestTemplate(6);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public async void page()
        {
            await _.TestTemplate(7);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public async void viewimports()
        {
            await _.TestTemplate(8);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public async void viewstart()
        {
            await _.TestTemplate(9);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public async void web()
        {
            await _.TestTemplate(10);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public async void mvc()
        {
            await _.TestTemplate(11);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public async void console2()
        {
            await _.TestTemplate(12);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public async void webapp()
        {
            await _.TestTemplate(13);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public async void angular()
        {
            await _.TestTemplate(14);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public async void react()
        {
            await _.TestTemplate(15);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public async void reactredux()
        {
            await _.TestTemplate(16);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public async void razorclasslib()
        {
            await _.TestTemplate(17);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public async void webapi()
        {
            await _.TestTemplate(18);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public async void globaljson()
        {
            await _.TestTemplate(19);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public async void nugetconfig()
        {
            await _.TestTemplate(20);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public async void webconfig()
        {
            await _.TestTemplate(21);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public async void sln()
        {
            await _.TestTemplate(22);
            Assert.Equal("Done.", _.CurrentLog);
        }

    }
    [Collection("Trigger else Statements")]
    public class TriggerELSE
    {
        TestSetup _ = new TestSetup();
        [Fact]
        public async void DoubleTest()
        {
            await _.TestTemplate(1);
            await _.TestTemplate(1);
            Assert.Equal("A Project with this Name already exists!", _.CurrentLog);
        }
    }
}

