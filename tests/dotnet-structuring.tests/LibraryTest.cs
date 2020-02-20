using dotnet_structuring.library;
using dotnet_structuring.library.Helpers.Logging;
using dotnet_structuring.library.Interfaces;
using dotnet_structuring.library.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace dotnet_structuring.tests
{
    public class LibraryTest
    {
        private readonly Logging logging = new Logging();
        public string NetCommand { get; private set; }
        public string ProjectName { get; private set; }
        public string OutputDirectory { get; private set; }
        private string path { get; set; }
        private static readonly List<string> directories = new List<string>();
        private readonly string tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

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
        public async Task TestTemplatesAsync(Template Template)
        {
            // Arrange
            CustomProcess Process = new CustomProcess();
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
            NetCommand = $" new {Template.ShortName}  -o src/ {ProjectName} -n {ProjectName}";
            var Structuring = new Structuring(Process);

            // Act
            logging.WireEventHandlers(Structuring);
            await Structuring.RunStructuringAsync(OutputDirectory, directories, NetCommand, ProjectName);

            // Assert
            Assert.Equal("dotnet", Process.StartInfo.FileName);
            Assert.Contains($"new {Template.ShortName}", Process.StartInfo.Arguments);

            // Cleanup
            logging.CurrentLog = string.Empty;
            Directory.Delete(tempPath, true);
        }

        [Fact]
        [Trait("Category", "IntegrationTest")]
        public async Task ExecutionTestAsync()
        {
            // Arrange
            StandardProcess Process = new StandardProcess();
            Template Template = InitializeTemplates.Templates[1];
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
            NetCommand = $" new {Template.ShortName}  -o src/ {ProjectName} -n {ProjectName}";
            var Structuring = new Structuring(Process);

            // Act
            logging.WireEventHandlers(Structuring);
            await Structuring.RunStructuringAsync(OutputDirectory, directories, NetCommand, ProjectName);
            await Structuring.RunStructuringAsync(OutputDirectory, directories, NetCommand, ProjectName);

            // Assert
            Assert.Equal("A Project with this Name already exists!", logging.CurrentLog);

            // Cleanup
            logging.CurrentLog = string.Empty;
            Directory.Delete(tempPath, true);
        }
    }
}