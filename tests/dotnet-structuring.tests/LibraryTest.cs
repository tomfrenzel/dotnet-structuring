using dotnet_structuring.library;
using dotnet_structuring.library.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using static dotnet_structuring.library.StructuringDelegate;
using Moq;
using System.Diagnostics;
using dotnet_structuring.library.Interfaces;

namespace dotnet_structuring.tests
{
    public class LibraryTest : IDisposable
    {
        private readonly ICustomProcess process;
        public string CurrentLog { get; set; }
        public string NetCommand { get; private set; }
        public string ProjectName { get; private set; }
        public string OutputDirectory { get; private set; }
        private string path { get; set; }
        private static readonly List<string> directories = new List<string>();
        private readonly string tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

        internal void WireEventHandlers(Structuring e)
        {
            StructuringHandler handler = new StructuringHandler(OnIncommingEventLog);
            e.LogEvent += handler;
        }

        internal void OnIncommingEventLog(object sender, EventLogger e)
        {
            CurrentLog = e.Logs;
        }

        internal async Task TestTemplateAsync(string SelectedTemplate, ICustomProcess process)
        {
            ProjectName = "TestProject";
            OutputDirectory = tempPath;
            directories.Add("artifacts");
            directories.Add("build");
            directories.Add("docs");
            directories.Add("lib");
            directories.Add("samples");
            directories.Add("packages");
            directories.Add("test");

            Directory.CreateDirectory(tempPath);

            NetCommand = $" new {SelectedTemplate}  -o src/ {ProjectName} -n {ProjectName}";            
            var Structuring = new Structuring(process);
            WireEventHandlers(Structuring);
            await Structuring.RunStructuringAsync(OutputDirectory, directories, NetCommand, ProjectName);            
        }

        public static IEnumerable<object[]> TemplatesGettingTested()
        {
            foreach (Template template in InitializeTemplates.Templates)
            {
                yield return new object[] { template };
            }
        }

        [Theory]
        [Trait("Category", "UnitTest")]
        [MemberData(nameof(TemplatesGettingTested))]
        public async Task TestTemplates(Template Template)
        {
            CustomProcess process = new CustomProcess();
            await TestTemplateAsync(Template.ShortName, process);
            Assert.Equal("dotnet", process.StartInfo.FileName);
            Assert.Contains($"new {Template.ShortName}", process.StartInfo.Arguments);
           // Assert.Contains("Start", calledMethods);
            CurrentLog = string.Empty;
        }

        [Fact]
        [Trait ("Category", "IntegrationTest")]
        public async Task TestExeptions()
        {
            StandardProcess process = new StandardProcess();

            Template Template = InitializeTemplates.Templates[1];
            await TestTemplateAsync(Template.ShortName, process);
            await TestTemplateAsync(Template.ShortName, process);
            Assert.Equal("A Project with this Name already exists!", CurrentLog);
            CurrentLog = string.Empty;
        }
        public void Dispose()
        {
            Directory.Delete(tempPath, true);
        }
    }
}
