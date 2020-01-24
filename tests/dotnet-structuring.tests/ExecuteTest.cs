using dotnet_structuring.library;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using NUnit.Framework;


namespace dotnet_structuring.tests
{
    public class ExecuteTest
    {
        //Setup Variables
        Variables _ = new Variables();
        TempDirectory temp = new TempDirectory();
        string CurrentLog;
        private string SelectedTemplate;

        //Setup EventHandler
        private void WireEventHandlers(Execute e)
        {
            ExecutionHandler handler = new ExecutionHandler(OnIncommingEventLog);
            e.LogEvent += handler;
        }

        public void OnIncommingEventLog(object sender, EventLogger e)
        {
            CurrentLog = e.logs;
        }



        [SetUp]
        public void Setup()
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
            SelectedTemplate = "console";
            _.Options = "";
            _.NETCommand = " new " + SelectedTemplate + " " + _.Options + "-o src/" + _.ProjectName + " -n " + _.ProjectName;
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
        [Test]
        public void FullTest()
        {
            Execute OutputLogs = new Execute();
            WireEventHandlers(OutputLogs);
            OutputLogs.CreateScript(_.Directories, _.NETCommand, _.ProjectName);
            Assert.AreEqual("Done.", CurrentLog);
        }
        [Test]
        public void SecondFullTest()
        {
            Execute OutputLogs = new Execute();
            WireEventHandlers(OutputLogs);
            OutputLogs.CreateScript(_.Directories, _.NETCommand, _.ProjectName);
            Assert.AreEqual("Done.", CurrentLog);

            Directory.Delete(temp, true);
        }
    }
}
