using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_structuring.library
{
   public class Commands
    {
        public Task GenerateComands(string Directory, string Artifacts, string Build, string Docs, string Lib, string Samples, string Packages, string Test, string SelectedTemplate, string Options, string SummaryCommand)
        {
            string[] FinalCommands = { "cd " + Directory, "mkdir src", Artifacts, Build, Docs, Lib, Samples, Packages, Test, "cd src", "dotnet new " + SelectedTemplate + " " + Options };           
            for (int i = 0; i < FinalCommands.Length; i++)
            {
                if (FinalCommands[i] != null && FinalCommands[i] != "" && FinalCommands[i] != "\r\n")
                {
                    Type thisType = GetType();
                    MethodInfo theMethod = thisType.GetMethod(SummaryCommand);
                    theMethod.Invoke(this, null);
                }
            }
            
            return Task.FromResult(0);
        }
    }
}
