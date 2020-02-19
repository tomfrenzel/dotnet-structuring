using dotnet_structuring.library.Interfaces;
using System;
using System.Diagnostics;

namespace dotnet_structuring.library.Models
{
    public class StandardProcess : Process, ICustomProcess
    {
        public StandardProcess() : base()
        {

        }
        void ICustomProcess.OnExited()
        {
            throw new NotImplementedException();
        }
    }
}
