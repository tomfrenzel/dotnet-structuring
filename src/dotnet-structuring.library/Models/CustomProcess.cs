using dotnet_structuring.library.Interfaces;
using System.Diagnostics;

namespace dotnet_structuring.library.Models
{
    public class CustomProcess : Process, IProcess
    {
        public CustomProcess() : base()
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