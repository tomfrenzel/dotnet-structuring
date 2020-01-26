using dotnet_structuring.library;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using NUnit.Framework;


namespace dotnet_structuring.tests
{
    public class Test
    {
        //Setup Variables
        Variables _ = new Variables();
        Templates __ = new Templates();
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
        [Test]
        public void FullTest()
        {
            for (int i = 1; i <= 22; i++)
            {
                __.SelcectTemplate(i);
                _.NETCommand = " new " + __.SelectedTemplate + " " + _.Options + "-o src/" + __.SelectedTemplate.Replace(" ", "_") + " -n " + __.SelectedTemplate.Replace(" ", "_");

                Execute OutputLogs = new Execute();
                WireEventHandlers(OutputLogs);
                OutputLogs.CreateScript(_.Directories, _.NETCommand, _.ProjectName, true);
            }
            Assert.AreEqual("Done.", CurrentLog);
        }
        [Test]
        public void CauseErrors()
        {
            __.SelcectTemplate(1);
            _.NETCommand = " new " + __.SelectedTemplate + " " + _.Options + "-o src/" + __.SelectedTemplate.Replace(" ", "_") + " -n " + __.SelectedTemplate.Replace(" ", "_");

            Execute OutputLogs = new Execute();
            WireEventHandlers(OutputLogs);
            OutputLogs.CreateScript(_.Directories, _.NETCommand, _.ProjectName, true);
            Assert.AreEqual("Done.", CurrentLog);
            Directory.Delete(temp, true);
        }
    }
}
