﻿using dotnet_structuring.library.Interfaces;
using System.Diagnostics;

namespace dotnet_structuring.library.Models
{
    public class StandardProcess : Process, IProcess
    {
        public StandardProcess() : base()
        {
        }
    }
}