using dotnet_structuring.library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace dotnet_structuring.tests
{

    [TestClass]
    public class ExecuteTest
    {
        Variables _ = new Variables();
        int LogNum;
        string CurrentLog;
        private void WireEventHandlers(Execute e)
        {
            ExecutionHandler handler = new ExecutionHandler(OnIncommingEventLog);
            e.LogEvent += handler;
        }

        public void OnIncommingEventLog(object sender, EventLogger e)
        {
            CurrentLog = e.logs;
        }

        [TestMethod]
        public void StandardWinTest()
        {
            _.ProjectName = "TestProject";
            _.Directory = Directory.GetCurrentDirectory() + "/temp";
            _.Artifacts = "artifacts";
            _.Build = "build";
            _.Docs = "docs";
            _.Lib = "lib";
            _.Samples = "samples";
            _.Packages = "packages";
            _.Test = "test";
            _.ProjectType = "New Project";
            _.SelectedTemplate = "console";
            _.Options = "";
            _.NETCommand = " new " + _.SelectedTemplate + " " + _.Options + "-o src/" + _.ProjectName + " -n " + _.ProjectName;
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
            Directory.CreateDirectory(_.Directory + "/temp");
            Execute OutputLogs = new Execute();
            WireEventHandlers(OutputLogs);
            OutputLogs.CreateScript(_.Directories, _.NETCommand, _.ProjectName);

            Assert.AreEqual("Done.", CurrentLog);
            Directory.Delete(_.Directory + "/test", true);
        }


    }
}

