using System.Threading.Tasks;
using Xunit;

namespace dotnet_structuring.tests
{
    [Collection("Create all types of .NET Applications")]
    //The test name equals the Template being created during the Test
    public class FullTest
    {
        private readonly TestSetup testSetup = new TestSetup();

        [Fact]
        public async Task Console()
        {
            await testSetup.TestTemplateAsync(1);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task Classlib()
        {
            await testSetup.TestTemplateAsync(2);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task Mstest()
        {
            await testSetup.TestTemplateAsync(3);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task Nunit()
        {
            await testSetup.TestTemplateAsync(4);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task Nunittest()
        {
            await testSetup.TestTemplateAsync(5);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task Xunit()
        {
            await testSetup.TestTemplateAsync(6);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task Page()
        {
            await testSetup.TestTemplateAsync(7);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task Viewimports()
        {
            await testSetup.TestTemplateAsync(8);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task Viewstart()
        {
            await testSetup.TestTemplateAsync(9);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task Web()
        {
            await testSetup.TestTemplateAsync(10);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task Mvc()
        {
            await testSetup.TestTemplateAsync(11);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task Console2()
        {
            await testSetup.TestTemplateAsync(12);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task Webapp()
        {
            await testSetup.TestTemplateAsync(13);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task Angular()
        {
            await testSetup.TestTemplateAsync(14);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task React()
        {
            await testSetup.TestTemplateAsync(15);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task Reactredux()
        {
            await testSetup.TestTemplateAsync(16);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task Razorclasslib()
        {
            await testSetup.TestTemplateAsync(17);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task Webapi()
        {
            await testSetup.TestTemplateAsync(18);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task Globaljson()
        {
            await testSetup.TestTemplateAsync(19);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task Nugetconfig()
        {
            await testSetup.TestTemplateAsync(20);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task Webconfig()
        {
            await testSetup.TestTemplateAsync(21);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task Sln()
        {
            await testSetup.TestTemplateAsync(22);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }
    }

    [Collection("Trigger else Statements")]
    public class TriggerElse
    {
        private readonly TestSetup testSetup = new TestSetup();

        [Fact]
        public async Task DoubleTestAsync()
        {
            await testSetup.TestTemplateAsync(1);
            await testSetup.TestTemplateAsync(1);
            Assert.Equal("A Project with this Name already exists!", testSetup.CurrentLog);
        }
    }
}