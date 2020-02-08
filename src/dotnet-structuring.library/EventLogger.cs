using System;

namespace dotnet_structuring.library
{
    public class EventLogger : EventArgs
    {
        public string Logs { get; set; }
    }
}