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
        public void Console()
        {
            testSetup.TestTemplate(1);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public void Classlib()
        {
            testSetup.TestTemplate(2);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public void Mstest()
        {
            testSetup.TestTemplate(3);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public void Nunit()
        {
            testSetup.TestTemplate(4);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public void Nunittest()
        {
            testSetup.TestTemplate(5);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public void Xunit()
        {
            testSetup.TestTemplate(6);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public void Page()
        {
            testSetup.TestTemplate(7);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public void Viewimports()
        {
            testSetup.TestTemplate(8);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public void Viewstart()
        {
            testSetup.TestTemplate(9);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public void Web()
        {
            testSetup.TestTemplate(10);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public void Mvc()
        {
            testSetup.TestTemplate(11);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public void Console2()
        {
            testSetup.TestTemplate(12);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public void Webapp()
        {
            testSetup.TestTemplate(13);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public void Angular()
        {
            testSetup.TestTemplate(14);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public void React()
        {
            testSetup.TestTemplate(15);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public void Reactredux()
        {
            testSetup.TestTemplate(16);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public void Razorclasslib()
        {
            testSetup.TestTemplate(17);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public void Webapi()
        {
            testSetup.TestTemplate(18);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public void Globaljson()
        {
            testSetup.TestTemplate(19);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public void Nugetconfig()
        {
            testSetup.TestTemplate(20);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public void Webconfig()
        {
            testSetup.TestTemplate(21);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }

        [Fact]
        public void Sln()
        {
            testSetup.TestTemplate(22);
            Assert.Equal("Done.", testSetup.CurrentLog);
        }
    }

    [Collection("Trigger else Statements")]
    public class TriggerElse
    {
        private readonly TestSetup testSetup = new TestSetup();

        [Fact]
        public void DoubleTest()
        {
            testSetup.TestTemplate(1);
            testSetup.TestTemplate(1);
            Assert.Equal("A Project with this Name already exists!", testSetup.CurrentLog);
        }
    }
}