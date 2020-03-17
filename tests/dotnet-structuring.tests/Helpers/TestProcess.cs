using dotnet_structuring.library.Interfaces;
using System.Diagnostics;

namespace dotnet_structuring.tests.Helpers
{
    public class TestProcess : Process, IProcess
    {
        public TestProcess() : base()
        {
        }

        public new bool Start()
        {
            return true;
        }

        public new void WaitForExit()
        {
        }

        public new void BeginOutputReadLine()
        {
        }
    }
}