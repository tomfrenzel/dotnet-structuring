using dotnet_structuring.library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace dotnet_structuring
{
    class TempDirectory : IDisposable
    {
        public TempDirectory()
        {
            path = Path.Combine(
                Path.GetTempPath(),
                Guid.NewGuid().ToString()
            );
            Directory.CreateDirectory(path);
        }

        readonly string path;

        public static implicit operator string(TempDirectory directory)
        {
            return directory.path;
        }
        public void Dispose()
        {
            Directory.Delete(path, true);
        }
    }

 
}