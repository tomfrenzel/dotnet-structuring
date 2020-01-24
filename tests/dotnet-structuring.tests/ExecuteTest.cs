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
        string CurrentLog;

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
            _.Directory = new TempDirectory();
            _.Artifacts = "artifacts";
            _.Build = "build";
            _.Docs = "docs";
            _.Lib = "lib";
            _.Samples = "samples";
            _.Packages = "packages";
            _.Test = "test";
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
        }
        [Test]
        public void FullWindowsTest()
        {
            Execute OutputLogs = new Execute();
            WireEventHandlers(OutputLogs);
            OutputLogs.CreateScript(_.Directories, _.NETCommand, _.ProjectName);
            Assert.AreEqual("Done.", CurrentLog);
        }
        [Test]
        public void SecondFullWindowsTest()
        {
            Execute OutputLogs = new Execute();
            WireEventHandlers(OutputLogs);
            OutputLogs.CreateScript(_.Directories, _.NETCommand, _.ProjectName);
            Assert.AreEqual("Done.", CurrentLog);
        }
    }
    class TempDirectory : IDisposable
    {
        public TempDirectory()
        {
            path = Path.Combine(
                Path.GetTempPath(),
                Guid.NewGuid().ToString()
            );
            Directory.CreateDirectory(path);
        }

        readonly string path;

        /// 

        /// Allows the TempDirectory to be used anywhere a string is required.
        /// 
        public static implicit operator string(TempDirectory directory)
        {
            return directory.path;
        }

        public override string ToString()
        {
            return path;
        }

        public void Dispose()
        {
            Directory.Delete(path, true);
        }

    }
}

