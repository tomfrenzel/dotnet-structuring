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
        public async Task console()
        {
            await testSetup.TestTemplate(1).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task classlib()
        {
            await testSetup.TestTemplate(2).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task mstest()
        {
            await testSetup.TestTemplate(3).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task nunit()
        {
            await testSetup.TestTemplate(4).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task nunittest()
        {
            await testSetup.TestTemplate(5).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task xunit()
        {
            await testSetup.TestTemplate(6).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task page()
        {
            await testSetup.TestTemplate(7).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task viewimports()
        {
            await testSetup.TestTemplate(8).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task viewstart()
        {
            await testSetup.TestTemplate(9).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task web()
        {
            await testSetup.TestTemplate(10).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task mvc()
        {
            await testSetup.TestTemplate(11).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task console2()
        {
            await testSetup.TestTemplate(12).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task webapp()
        {
            await testSetup.TestTemplate(13).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task angular()
        {
            await testSetup.TestTemplate(14).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task react()
        {
            await testSetup.TestTemplate(15).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task reactredux()
        {
            await testSetup.TestTemplate(16).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task razorclasslib()
        {
            await testSetup.TestTemplate(17).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task webapi()
        {
            await testSetup.TestTemplate(18).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task globaljson()
        {
            await testSetup.TestTemplate(19).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task nugetconfig()
        {
            await testSetup.TestTemplate(20).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task webconfig()
        {
            await testSetup.TestTemplate(21).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public async Task sln()
        {
            await testSetup.TestTemplate(22).ConfigureAwait(false);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }
    }

    [Collection("Trigger else Statements")]
    public class TriggerELSE
    {
        private readonly TestSetup testSetup = new TestSetup();

        [Fact]
        public async Task DoubleTest()
        {
            await testSetup.TestTemplate(1);
            await testSetup.TestTemplate(1);
            Assert.Equal("A Project with this Name already exists!", testSetup.CurrentLog);
        }
    }
}