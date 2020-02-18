using dotnet_structuring.library;
using dotnet_structuring.library.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using static dotnet_structuring.library.StructuringDelegate;

namespace dotnet_structuring.tests
{
    public class LibraryTest : IDisposable
    {
        private Structuring Structuring = new Structuring();

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

        internal async Task TestTemplateAsync(string SelectedTemplate)
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
        [MemberData(nameof(TemplatesGettingTested))]
        public async Task TestTemplates(Template Template)
        {
            await TestTemplateAsync(Template.ShortName);
            Assert.Equal("Done.", CurrentLog);
            CurrentLog = string.Empty;
        }

        [Fact]
        public async Task TestExeptions()
        {
            Template Template = InitializeTemplates.Templates[1];
            await TestTemplateAsync(Template.ShortName);
            await TestTemplateAsync(Template.ShortName);
            Assert.Equal("A Project with this Name already exists!", CurrentLog);
            CurrentLog = string.Empty;
        }
        public void Dispose()
        {
            Directory.Delete(tempPath, true);
        }
    }
}
