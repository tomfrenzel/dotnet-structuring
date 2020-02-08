using System;
using System.Collections.Generic;
using System.Text;
using static dotnet_structuring.library.StructuringDelegate;


namespace dotnet_structuring.library
{
    public class EventLogger : EventArgs
    {
        public string Logs { get; set; }

    }
}
