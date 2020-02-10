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
            await testSetup.TestTemplateAsync(1).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task ClasslibAsync()
        {
            await testSetup.TestTemplateAsync(2).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task MstestAsync()
        {
            await testSetup.TestTemplateAsync(3).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task NunitAsync()
        {
            await testSetup.TestTemplateAsync(4).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task NunittestAsync()
        {
            await testSetup.TestTemplateAsync(5).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task XunitAsync()
        {
            await testSetup.TestTemplateAsync(6).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task PageAsync()
        {
            await testSetup.TestTemplateAsync(7).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task ViewimportsAsync()
        {
            await testSetup.TestTemplateAsync(8).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task ViewstartAsync()
        {
            await testSetup.TestTemplateAsync(9).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task webAsync()
        {
            await testSetup.TestTemplateAsync(10).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task MvcAsync()
        {
            await testSetup.TestTemplateAsync(11).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task Console2Async()
        {
            await testSetup.TestTemplateAsync(12).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task WebappAsync()
        {
            await testSetup.TestTemplateAsync(13).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task AngularAsync()
        {
            await testSetup.TestTemplateAsync(14).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task ReactAsync()
        {
            await testSetup.TestTemplateAsync(15).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task ReactreduxAsync()
        {
            await testSetup.TestTemplateAsync(16).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task RazorclasslibAsync()
        {
            await testSetup.TestTemplateAsync(17).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task WebapiAsync()
        {
            await testSetup.TestTemplateAsync(18).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task GlobaljsonAsync()
        {
            await testSetup.TestTemplateAsync(19).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task NugetconfigAsync()
        {
            await testSetup.TestTemplateAsync(20).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task WebconfigAsync()
        {
            await testSetup.TestTemplateAsync(21).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task SlnAsync()
        {
            await testSetup.TestTemplateAsync(22).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task DoubleTestAsync()
        {
            await testSetup.TestTemplateAsync(1);
            await testSetup.TestTemplateAsync(1);
            Assert.Equal("A Project with this Name already exists!", testSetup.CurrentLog);
        }
    }
}