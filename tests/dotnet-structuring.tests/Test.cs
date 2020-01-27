using dotnet_structuring.library;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Xunit;


namespace dotnet_structuring.tests
{
    public class TestSetup
    {
        //Setup Variables
        Variables _ = new Variables();
        Templates __ = new Templates();
        TempDirectory temp = new TempDirectory();
        public string CurrentLog { get; set; }

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
            _.ProjectName = "TestProject";
            _.Directory = temp;
            _.Artifacts = "artifacts";
            _.Build = "build";
            _.Docs = "docs";
            _.Lib = "lib";
            _.Samples = "samples";
            _.Packages = "packages";
            _.Test = "test";
            _.Options = "";
            _.Directories = new string[]
            {
             _.Directory,
             _.Artifacts,
             _.Build,
             _.Docs,
             _.Lib,
             _.Samples,
             _.Packages,
             _.Test,
            };
        }
        internal void StandardTest(int i)
        {
            StandardSetup();
            __.SelcectTemplate(i);
            _.NETCommand = " new " + __.SelectedTemplate + " " + _.Options + "-o src/" + __.SelectedTemplate.Replace(" ", "_") + " -n " + __.SelectedTemplate.Replace(" ", "_");
            Execute ExecuteClass = new Execute();
            WireEventHandlers(ExecuteClass);
            ExecuteClass.CreateScript(_.Directories, _.NETCommand, _.ProjectName, true);
        }
    }
    [Collection("Create All types of .NET Applications")]
    public class FullTest
    {
        TestSetup _ = new TestSetup();
        [Fact]
        public void console()
        {
            _.StandardTest(1);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public void classlib()
        {
            _.StandardTest(2);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public void mstest()
        {
            _.StandardTest(3);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public void nunit()
        {
            _.StandardTest(4);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public void nunittest()
        {
            _.StandardTest(5);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public void xunit()
        {
            _.StandardTest(6);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public void page()
        {
            _.StandardTest(7);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public void viewimports()
        {
            _.StandardTest(8);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public void viewstart()
        {
            _.StandardTest(9);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public void web()
        {
            _.StandardTest(10);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public void mvc()
        {
            _.StandardTest(11);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public void console2()
        {
            _.StandardTest(12);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public void webapp()
        {
            _.StandardTest(13);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public void angular()
        {
            _.StandardTest(14);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public void react()
        {
            _.StandardTest(15);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public void reactredux()
        {
            _.StandardTest(16);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public void razorclasslib()
        {
            _.StandardTest(17);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public void webapi()
        {
            _.StandardTest(18);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public void globaljson()
        {
            _.StandardTest(19);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public void nugetconfig()
        {
            _.StandardTest(20);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public void webconfig()
        {
            _.StandardTest(21);
            Assert.Equal("Done.", _.CurrentLog);
        }
        [Fact]
        public void sln()
        {
            _.StandardTest(22);
            Assert.Equal("Done.", _.CurrentLog);
        }

    }
    [Collection("Trigger else Statements")]
    public class TriggerELSE
    {
        TestSetup _ = new TestSetup();
        [Fact]
        public void DoubleTest()
        {
            _.StandardTest(1);
            _.StandardTest(1);
            Assert.Equal("A Project with this Name already exists!", _.CurrentLog);
        }
    }
}

