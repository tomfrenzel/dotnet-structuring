using System;
using System.Collections.Generic;
using System.Text;

namespace dotnet_structuring.library.Helpers.Logging
{
    public class Logging
    {
        public delegate void StructuringHandler(object sender, string log);

        public string CurrentLog { get; set; }

        public void WireEventHandlers(Structuring s)
        {
            StructuringHandler handler = new StructuringHandler(OnIncommingEventLog);
            s.LogEvent += handler;
        }

        public void OnIncommingEventLog(object sender, string log)
        {
            CurrentLog = log;
        }
    }
}