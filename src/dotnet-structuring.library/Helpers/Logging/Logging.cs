using System;
using System.Collections.Generic;
using System.Text;

namespace dotnet_structuring.library.Helpers.Logging
{
    public class Logging
    {
        public delegate void StructuringHandler(object sender, string log);

        public string CurrentLog { get; set; }

        public void WireEventHandlers(Structuring structuring)
        {
            StructuringHandler handler = new StructuringHandler(OnIncommingEventLog);
            structuring.LogEvent += handler;
        }

        public void OnIncommingEventLog(object sender, string log)
        {
            CurrentLog = log;
        }
    }
}