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

        public List<string> Directories;

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

        internal void StandardSetup()
        {
            ProjectName = "TestProject";
            OutputDirectory = temp;
            string Artifacts = "artifacts";
            string Build = "build";
            string Docs = "docs";
            string Lib = "lib";
            string Samples = "samples";
            string Packages = "packages";
            string Test = "test";
            Options = "";

            Directories.Add(Artifacts);
            Directories.Add(Build);
            Directories.Add(Docs);
            Directories.Add(Lib);
            Directories.Add(Samples);
            Directories.Add(Packages);
            Directories.Add(Test);

        }
        internal async Task StandardTest(int i)
        {
            StandardSetup();
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
            await _.StandardTest(1);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public async void classlib()
        {
            await _.StandardTest(2);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public async void mstest()
        {
            await _.StandardTest(3);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public async void nunit()
        {
            await _.StandardTest(4);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public async void nunittest()
        {
            await _.StandardTest(5);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public async void xunit()
        {
            await _.StandardTest(6);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public async void page()
        {
            await _.StandardTest(7);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public async void viewimports()
        {
            await _.StandardTest(8);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public async void viewstart()
        {
            await _.StandardTest(9);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public async void web()
        {
            await _.StandardTest(10);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public async void mvc()
        {
            await _.StandardTest(11);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public async void console2()
        {
            await _.StandardTest(12);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public async void webapp()
        {
            await _.StandardTest(13);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public async void angular()
        {
            await _.StandardTest(14);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public async void react()
        {
            await _.StandardTest(15);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public async void reactredux()
        {
            await _.StandardTest(16);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public async void razorclasslib()
        {
            await _.StandardTest(17);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public async void webapi()
        {
            await _.StandardTest(18);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public async void globaljson()
        {
            await _.StandardTest(19);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public async void nugetconfig()
        {
            await _.StandardTest(20);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public async void webconfig()
        {
            await _.StandardTest(21);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public async void sln()
        {
            await _.StandardTest(22);
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
            await _.StandardTest(1);
            await _.StandardTest(1);
            Assert.Equal("A Project with this Name already exists!", _.CurrentLog);
        }
    }
}

