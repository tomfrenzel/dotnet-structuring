using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RunProcessAsTask;

namespace dotnet_structuring.library
{
    public class Execute
    {
        public async Task<string[]> CreateScriptAsync(string commands)
        {
            using (StreamWriter outputFile = new StreamWriter(System.IO.Path.Combine("dotnet-structoring.bat")))
            {
                outputFile.WriteLine(commands);

            }

            //Execute structoring script
            var processStartInfo = new ProcessStartInfo
            {
                FileName = "dotnet-structoring.bat",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };

            using (var cancellationTokenSource = new CancellationTokenSource())
            {
                var processResults = await ProcessEx.RunAsync(processStartInfo);
                //File.WriteAllText("C:/log.txt", processResults.StandardOutput);
                return processResults.StandardOutput;
            }
        }

    }
}
