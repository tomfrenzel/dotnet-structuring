using Microsoft.Win32.SafeHandles;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;

namespace dotnet_structuring.library.Interfaces
{
    public interface ICustomProcess : IDisposable
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        ProcessPriorityClass PriorityClass { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        bool PriorityBoostEnabled { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        long PeakWorkingSet64 { get; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Obsolete("This property has been deprecated.  Please use System.Diagnostics.Process.PeakWorkingSet64 instead.  http://go.microsoft.com/fwlink/?linkid=14202")]
        int PeakWorkingSet { get; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        long PeakVirtualMemorySize64 { get; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Obsolete("This property has been deprecated.  Please use System.Diagnostics.Process.PeakVirtualMemorySize64 instead.  http://go.microsoft.com/fwlink/?linkid=14202")]
        int PeakVirtualMemorySize { get; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        long PeakPagedMemorySize64 { get; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Obsolete("This property has been deprecated.  Please use System.Diagnostics.Process.PrivateMemorySize64 instead.  http://go.microsoft.com/fwlink/?linkid=14202")]
        int PrivateMemorySize { get; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Obsolete("This property has been deprecated.  Please use System.Diagnostics.Process.PeakPagedMemorySize64 instead.  http://go.microsoft.com/fwlink/?linkid=14202")]
        int PeakPagedMemorySize { get; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Obsolete("This property has been deprecated.  Please use System.Diagnostics.Process.PagedSystemMemorySize64 instead.  http://go.microsoft.com/fwlink/?linkid=14202")]
        int PagedSystemMemorySize { get; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        long PagedMemorySize64 { get; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Obsolete("This property has been deprecated.  Please use System.Diagnostics.Process.PagedMemorySize64 instead.  http://go.microsoft.com/fwlink/?linkid=14202")]
        int PagedMemorySize { get; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        long NonpagedSystemMemorySize64 { get; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Obsolete("This property has been deprecated.  Please use System.Diagnostics.Process.NonpagedSystemMemorySize64 instead.  http://go.microsoft.com/fwlink/?linkid=14202")]
        int NonpagedSystemMemorySize { get; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        ProcessModuleCollection Modules { get; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        IntPtr MinWorkingSet { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        long PagedSystemMemorySize64 { get; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        long PrivateMemorySize64 { get; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        TimeSpan PrivilegedProcessorTime { get; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        string ProcessName { get; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        long WorkingSet64 { get; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Obsolete("This property has been deprecated.  Please use System.Diagnostics.Process.WorkingSet64 instead.  http://go.microsoft.com/fwlink/?linkid=14202")]
        int WorkingSet { get; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        long VirtualMemorySize64 { get; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Obsolete("This property has been deprecated.  Please use System.Diagnostics.Process.VirtualMemorySize64 instead.  http://go.microsoft.com/fwlink/?linkid=14202")]
        int VirtualMemorySize { get; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        TimeSpan UserProcessorTime { get; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        TimeSpan TotalProcessorTime { get; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        ProcessThreadCollection Threads { get; }

        [Browsable(false)]
        [DefaultValue(null)]
        ISynchronizeInvoke SynchronizingObject { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        DateTime StartTime { get; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        ProcessStartInfo StartInfo { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        StreamReader StandardOutput { get; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        StreamWriter StandardInput { get; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        StreamReader StandardError { get; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        int SessionId { get; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        SafeProcessHandle SafeHandle { get; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        bool Responding { get; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        IntPtr ProcessorAffinity { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        IntPtr MaxWorkingSet { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        string MainWindowTitle { get; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        IntPtr MainWindowHandle { get; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        string MachineName { get; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        int Id { get; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        bool HasExited { get; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        int HandleCount { get; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        IntPtr Handle { get; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        DateTime ExitTime { get; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        int ExitCode { get; }

        [Browsable(false)]
        [DefaultValue(false)]
        bool EnableRaisingEvents { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        int BasePriority { get; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        ProcessModule MainModule { get; }

        [Category("Behavior")]
        event EventHandler Exited;

        [Browsable(true)]
        event DataReceivedEventHandler ErrorDataReceived;

        [Browsable(true)]
        event DataReceivedEventHandler OutputDataReceived;

        void BeginErrorReadLine();

        void BeginOutputReadLine();

        void CancelErrorRead();

        void CancelOutputRead();

        void Close();

        bool CloseMainWindow();

        void Kill();

        void Refresh();

        bool Start();

        string ToString();

        bool WaitForExit(int milliseconds);

        void WaitForExit();

        bool WaitForInputIdle();

        bool WaitForInputIdle(int milliseconds);

        void OnExited();

        string CustomProcessName { get; }
    }
}