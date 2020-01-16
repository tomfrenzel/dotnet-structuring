using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_structuring.library
{
    public class Execute
    {
        public string CreateScript(string commands)
        {
            string ConsoleOutput;
            using (StreamWriter outputFile = new StreamWriter(System.IO.Path.Combine("dotnet-structoring.bat")))
            {
                outputFile.WriteLine(commands);

            }

            //Execute structoring script
            using (Process compiler = new Process())
            {
                compiler.StartInfo.FileName = "dotnet-structoring.bat";
                //compiler.StartInfo.Arguments = "dir";
                compiler.StartInfo.UseShellExecute = false;
                compiler.StartInfo.RedirectStandardOutput = true;
                compiler.StartInfo.CreateNoWindow = true;
                compiler.Start();

                compiler.WaitForExit();
                ConsoleOutput = compiler.StandardOutput.ReadToEnd();
            }
            return ConsoleOutput;
        }
       
    }
}
