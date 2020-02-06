using dotnet_structuring.library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace dotnet_structuring.library
{
    public static class InitializeTemplates
    {
        public static List<Template> Templates = new List<Template>() {
            new Template() { Name = "Console Application", ShortName = "console" },
            new Template() { Name = "Class library", ShortName = "classlib" },
            new Template() { Name = "WPF Application", ShortName = "wpf" },
            new Template() { Name = "WPF Class library", ShortName = "wpflib" },
            new Template() { Name = "WPF Custom Control Library", ShortName = "wpfcustomcontrollib" },
            new Template() { Name = "WPF User Control Library", ShortName = "wpfusercontrollib" },
            new Template() { Name = "Windows Forms (WinForms) Application", ShortName = "winforms" },
            new Template() { Name = "Windows Forms (WinForms) Class library", ShortName = "winformslib" },
            new Template() { Name = "Worker Service", ShortName = "worker" },
            new Template() { Name = "Unit Test Project", ShortName = "mstest" },
            new Template() { Name = "NUnit 3 Test Project", ShortName = "nunit" },
            new Template() { Name = "NUnit 3 Test Item", ShortName = "nunit-test" },
            new Template() { Name = "xUnit Test Project", ShortName = "xunit" },
            new Template() { Name = "Razor Component", ShortName = "razorcomponent" },
            new Template() { Name = "Razor Page", ShortName = "page" },
            new Template() { Name = "MVC ViewImports", ShortName = "viewimports" },
            new Template() { Name = "MVC ViewStart", ShortName = "viewstart" },
            new Template() { Name = "Blazor Server App", ShortName = "blazorserver" },
            new Template() { Name = "ASP.NET Core Empty", ShortName = "web" },
            new Template() { Name = "ASP.NET Core Web App (Model-View-Controller)", ShortName = "mvc" },
            new Template() { Name = "ASP.NET Core Web App", ShortName = "webapp" },
            new Template() { Name = "ASP.NET Core with Angular", ShortName = "angular" },
            new Template() { Name = "ASP.NET Core with React.js", ShortName = "react" },
            new Template() { Name = "ASP.NET Core with React.js and Redux", ShortName = "reactredux" },
            new Template() { Name = "Razor Class Library", ShortName = "razorclasslib" },
            new Template() { Name = "ASP.NET Core Web API", ShortName = "webapi" },
            new Template() { Name = "ASP.NET Core gRPC Service", ShortName = "grpc" },
            new Template() { Name = "dotnet gitignore file", ShortName = "gitignore" },
            new Template() { Name = "global.json file", ShortName = "globaljson" },
            new Template() { Name = "NuGet Config", ShortName = "nugetconfig" },
            new Template() { Name = "dotnet local tool manifest file", ShortName = "tool-manifest" },
            new Template() { Name = "Web Config", ShortName = "webconfig" },
            new Template() { Name = "Solution File", ShortName = "sln" },
            new Template() { Name = "Protocol Buffer File", ShortName = "proto" }
        };
    }
}
