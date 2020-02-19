using dotnet_structuring.library.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace dotnet_structuring.library.Models
{
    public class CustomProcess : Process, ICustomProcess
    {
        public CustomProcess() : base()
        {

        }
        public new bool Start()
        {
            
                throw new ArgumentException("a event handler for exited is required");
            
            return true;
        }
        void ICustomProcess.OnExited()
        {
            throw new NotImplementedException();
        }

    }
}
