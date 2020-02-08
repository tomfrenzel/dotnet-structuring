using System;
using System.Collections.Generic;
using System.Text;
using static dotnet_structuring.library.StructuringDelegate;


namespace dotnet_structuring.library
{
    public class EventLogger : EventArgs
    {
        public string Logs { get; set; }
        public string CurrentLog { get; set; }

        public void WireEventHandlers(Structuring e)
        {
            StructuringHandler handler = new StructuringHandler(OnIncommingEventLog);
            e.LogEvent += handler;
        }
        public void OnIncommingEventLog(object sender, EventLogger e)
        {
            CurrentLog = e.Logs;
        }
    }
}
