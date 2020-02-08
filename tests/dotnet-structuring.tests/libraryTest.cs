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
        public async Task ConsoleAsync()
        {
            await testSetup.TestTemplate(1).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task ClasslibAsync()
        {
            await testSetup.TestTemplate(2).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task MstestAsync()
        {
            await testSetup.TestTemplate(3).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task NunitAsync()
        {
            await testSetup.TestTemplate(4).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task NunittestAsync()
        {
            await testSetup.TestTemplate(5).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task XunitAsync()
        {
            await testSetup.TestTemplate(6).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task PageAsync()
        {
            await testSetup.TestTemplate(7).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task ViewimportsAsync()
        {
            await testSetup.TestTemplate(8).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task ViewstartAsync()
        {
            await testSetup.TestTemplate(9).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task WebAsync()
        {
            await testSetup.TestTemplate(10).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task MvcAsync()
        {
            await testSetup.TestTemplate(11).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task Console2Async()
        {
            await testSetup.TestTemplate(12).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task WebappAsync()
        {
            await testSetup.TestTemplate(13).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task AngularAsync()
        {
            await testSetup.TestTemplate(14).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task ReactAsync()
        {
            await testSetup.TestTemplate(15).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task ReactreduxAsync()
        {
            await testSetup.TestTemplate(16).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task RazorclasslibAsync()
        {
            await testSetup.TestTemplate(17).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task WebapiAsync()
        {
            await testSetup.TestTemplate(18).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task GlobaljsonAsync()
        {
            await testSetup.TestTemplate(19).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task NugetconfigAsync()
        {
            await testSetup.TestTemplate(20).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task WebconfigAsync()
        {
            await testSetup.TestTemplate(21).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task SlnAsync()
        {
            await testSetup.TestTemplate(22).ConfigureAwait(false);
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
            await testSetup.TestTemplate(1);
            await testSetup.TestTemplate(1);
            Assert.Equal("A Project with this Name already exists!", testSetup.CurrentLog);
        }
    }
}