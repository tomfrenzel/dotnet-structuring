using System;
using System.IO;

namespace dotnet_structuring
{
    internal class TempDirectory
    {
        public TempDirectory()
        {
            path = Path.Combine(
                Path.GetTempPath(),
                Guid.NewGuid().ToString()
            );
            Directory.CreateDirectory(path);
        }

        private readonly string path;

        public static implicit operator string(TempDirectory directory)
        {
            return directory.path;
        }
    }
}