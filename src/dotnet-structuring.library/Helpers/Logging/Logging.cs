using System;
using System.Collections.Generic;
using System.Text;

namespace dotnet_structuring.library.Helpers.Logging
{
    public class Logging
    {
        public delegate void StructuringHandler(object sender, string e);

        public string CurrentLog { get; set; }

        public void WireEventHandlers(Structuring e)
        {
            StructuringHandler handler = new StructuringHandler(OnIncommingEventLog);
            e.LogEvent += handler;
        }

        public void OnIncommingEventLog(object sender, string e)
        {
            CurrentLog = e;
        }
    }
}