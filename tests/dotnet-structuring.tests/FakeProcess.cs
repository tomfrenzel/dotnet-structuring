using dotnet_structuring.library.Interfaces;
using Microsoft.Win32.SafeHandles;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;

namespace dotnet_structuring.tests
{
    public class FakeProcess : ICustomProcess
    {
        public FakeProcess()
        {
        }

        event EventHandler ICustomProcess.Exited
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        public EventHandler<string> calledMethods;
        public EventHandler Exited;

        public event DataReceivedEventHandler ErrorDataReceived;

        public event DataReceivedEventHandler OutputDataReceived;

        public ProcessPriorityClass PriorityClass { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool PriorityBoostEnabled { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public long PeakWorkingSet64 => throw new NotImplementedException();

        public int PeakWorkingSet => throw new NotImplementedException();

        public long PeakVirtualMemorySize64 => throw new NotImplementedException();

        public int PeakVirtualMemorySize => throw new NotImplementedException();

        public long PeakPagedMemorySize64 => throw new NotImplementedException();

        public int PrivateMemorySize => throw new NotImplementedException();

        public int PeakPagedMemorySize => throw new NotImplementedException();

        public int PagedSystemMemorySize => throw new NotImplementedException();

        public long PagedMemorySize64 => throw new NotImplementedException();

        public int PagedMemorySize => throw new NotImplementedException();

        public long NonpagedSystemMemorySize64 => throw new NotImplementedException();

        public int NonpagedSystemMemorySize => throw new NotImplementedException();

        public ProcessModuleCollection Modules => throw new NotImplementedException();

        public IntPtr MinWorkingSet { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public long PagedSystemMemorySize64 => throw new NotImplementedException();

        public long PrivateMemorySize64 => throw new NotImplementedException();

        public TimeSpan PrivilegedProcessorTime => throw new NotImplementedException();

        public string ProcessName => throw new NotImplementedException();

        public long WorkingSet64 => throw new NotImplementedException();

        public int WorkingSet => throw new NotImplementedException();

        public long VirtualMemorySize64 => throw new NotImplementedException();

        public int VirtualMemorySize => throw new NotImplementedException();

        public TimeSpan UserProcessorTime => throw new NotImplementedException();

        public TimeSpan TotalProcessorTime => throw new NotImplementedException();

        public ProcessThreadCollection Threads => throw new NotImplementedException();

        public ISynchronizeInvoke SynchronizingObject { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public DateTime StartTime => throw new NotImplementedException();

        public ProcessStartInfo StartInfo { get; set; }

        public StreamReader StandardOutput => throw new NotImplementedException();

        public StreamWriter StandardInput => throw new NotImplementedException();

        public StreamReader StandardError => throw new NotImplementedException();

        public int SessionId => throw new NotImplementedException();

        public SafeProcessHandle SafeHandle => throw new NotImplementedException();

        public bool Responding => throw new NotImplementedException();

        public IntPtr ProcessorAffinity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IntPtr MaxWorkingSet { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string MainWindowTitle => throw new NotImplementedException();

        public IntPtr MainWindowHandle => throw new NotImplementedException();

        public string MachineName => throw new NotImplementedException();

        public int Id => throw new NotImplementedException();

        public bool HasExited => throw new NotImplementedException();

        public int HandleCount => throw new NotImplementedException();

        public IntPtr Handle => throw new NotImplementedException();

        public DateTime ExitTime => throw new NotImplementedException();

        public int ExitCode => throw new NotImplementedException();

        public bool EnableRaisingEvents { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int BasePriority => throw new NotImplementedException();

        public ProcessModule MainModule => throw new NotImplementedException();

        ProcessPriorityClass ICustomProcess.PriorityClass { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        bool ICustomProcess.PriorityBoostEnabled { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        long ICustomProcess.PeakWorkingSet64 => throw new NotImplementedException();

        int ICustomProcess.PeakWorkingSet => throw new NotImplementedException();

        long ICustomProcess.PeakVirtualMemorySize64 => throw new NotImplementedException();

        int ICustomProcess.PeakVirtualMemorySize => throw new NotImplementedException();

        long ICustomProcess.PeakPagedMemorySize64 => throw new NotImplementedException();

        int ICustomProcess.PrivateMemorySize => throw new NotImplementedException();

        int ICustomProcess.PeakPagedMemorySize => throw new NotImplementedException();

        int ICustomProcess.PagedSystemMemorySize => throw new NotImplementedException();

        long ICustomProcess.PagedMemorySize64 => throw new NotImplementedException();

        int ICustomProcess.PagedMemorySize => throw new NotImplementedException();

        long ICustomProcess.NonpagedSystemMemorySize64 => throw new NotImplementedException();

        int ICustomProcess.NonpagedSystemMemorySize => throw new NotImplementedException();

        ProcessModuleCollection ICustomProcess.Modules => throw new NotImplementedException();

        IntPtr ICustomProcess.MinWorkingSet { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        long ICustomProcess.PagedSystemMemorySize64 => throw new NotImplementedException();

        long ICustomProcess.PrivateMemorySize64 => throw new NotImplementedException();

        TimeSpan ICustomProcess.PrivilegedProcessorTime => throw new NotImplementedException();

        string ICustomProcess.ProcessName => throw new NotImplementedException();

        long ICustomProcess.WorkingSet64 => throw new NotImplementedException();

        int ICustomProcess.WorkingSet => throw new NotImplementedException();

        long ICustomProcess.VirtualMemorySize64 => throw new NotImplementedException();

        int ICustomProcess.VirtualMemorySize => throw new NotImplementedException();

        TimeSpan ICustomProcess.UserProcessorTime => throw new NotImplementedException();

        TimeSpan ICustomProcess.TotalProcessorTime => throw new NotImplementedException();

        ProcessThreadCollection ICustomProcess.Threads => throw new NotImplementedException();

        ISynchronizeInvoke ICustomProcess.SynchronizingObject { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        DateTime ICustomProcess.StartTime => throw new NotImplementedException();

        // ProcessStartInfo ICustomProcess.StartInfo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        StreamReader ICustomProcess.StandardOutput => throw new NotImplementedException();

        StreamWriter ICustomProcess.StandardInput => throw new NotImplementedException();

        StreamReader ICustomProcess.StandardError => throw new NotImplementedException();

        int ICustomProcess.SessionId => throw new NotImplementedException();

        SafeProcessHandle ICustomProcess.SafeHandle => throw new NotImplementedException();

        bool ICustomProcess.Responding => throw new NotImplementedException();

        IntPtr ICustomProcess.ProcessorAffinity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        IntPtr ICustomProcess.MaxWorkingSet { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        string ICustomProcess.MainWindowTitle => throw new NotImplementedException();

        IntPtr ICustomProcess.MainWindowHandle => throw new NotImplementedException();

        string ICustomProcess.MachineName => throw new NotImplementedException();

        int ICustomProcess.Id => throw new NotImplementedException();

        bool ICustomProcess.HasExited => throw new NotImplementedException();

        int ICustomProcess.HandleCount => throw new NotImplementedException();

        IntPtr ICustomProcess.Handle => throw new NotImplementedException();

        DateTime ICustomProcess.ExitTime => throw new NotImplementedException();

        int ICustomProcess.ExitCode => throw new NotImplementedException();

        bool ICustomProcess.EnableRaisingEvents { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        int ICustomProcess.BasePriority => throw new NotImplementedException();

        ProcessModule ICustomProcess.MainModule => throw new NotImplementedException();

        public bool Start()
        {
            calledMethods(this, "Start");
            EventHandler blup = this.Exited;
            if (blup != null)
            {
                blup(this, null);
            }
            else
            {
                throw new ArgumentException("a event handler for exited is required");
            }
            return true;
        }

        public void WaitForExit()
        {
            calledMethods(this, "WaitForExit");
            return;
        }

        public void Kill()
        {
            calledMethods(this, "Kill");
            return;
        }

        public void BeginErrorReadLine()
        {
        }

        public void BeginOutputReadLine()
        {
        }

        public void CancelErrorRead()
        {
        }

        public void CancelOutputRead()
        {
        }

        public void Close()
        {
        }

        public bool CloseMainWindow()
        {
            return true;
        }

        public void Refresh()
        {
        }

        public bool WaitForExit(int milliseconds)
        {
            return true;
        }

        public bool WaitForInputIdle()
        {
            return true;
        }

        public bool WaitForInputIdle(int milliseconds)
        {
            return true;
        }

        public void Dispose()
        {
        }

        void ICustomProcess.BeginErrorReadLine()
        {
            throw new NotImplementedException();
        }

        void ICustomProcess.BeginOutputReadLine()
        {
            throw new NotImplementedException();
        }

        void ICustomProcess.CancelErrorRead()
        {
            throw new NotImplementedException();
        }

        void ICustomProcess.CancelOutputRead()
        {
            throw new NotImplementedException();
        }

        void ICustomProcess.Close()
        {
            throw new NotImplementedException();
        }

        bool ICustomProcess.CloseMainWindow()
        {
            throw new NotImplementedException();
        }

        void ICustomProcess.Kill()
        {
            throw new NotImplementedException();
        }

        void ICustomProcess.Refresh()
        {
            throw new NotImplementedException();
        }

        bool ICustomProcess.Start()
        {
            throw new NotImplementedException();
        }

        string ICustomProcess.ToString()
        {
            throw new NotImplementedException();
        }

        bool ICustomProcess.WaitForExit(int milliseconds)
        {
            throw new NotImplementedException();
        }

        void ICustomProcess.WaitForExit()
        {
            throw new NotImplementedException();
        }

        bool ICustomProcess.WaitForInputIdle()
        {
            throw new NotImplementedException();
        }

        bool ICustomProcess.WaitForInputIdle(int milliseconds)
        {
            throw new NotImplementedException();
        }

        void ICustomProcess.OnExited()
        {
            throw new NotImplementedException();
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }
    }
}