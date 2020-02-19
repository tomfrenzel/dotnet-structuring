using dotnet_structuring.library.Interfaces;
using System;
using System.Diagnostics;

namespace dotnet_structuring.library.Models
{
    public class CustomProcess : Process, ICustomProcess
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
    }
}