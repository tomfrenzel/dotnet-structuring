using dotnet_structuring.library;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace dotnet_structuring
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        Variables Variables = new Variables();
        Execute Execute = new library.Execute();
        public async void ExecButton_Click(object sender, RoutedEventArgs e)
        {
            OutputBox.Clear();

            //Write commands to .bat File
            var result = await Execute.CreateScriptAsync(CommandSummaryBox.Text);            
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] != null && result[i] != "" && result[i] != "\r\n")
                {
                    OutputBox.AppendText(result[i] + "\r\n");
                }
            }
           // OutputBox.Append(Execute.CreateScriptAsync(CommandSummaryBox.Text)[2]);
        }
        public void ProjectTypeSelector_DropDownClosed(object sender, EventArgs e)
        {
            Variables.ProjectType = ProjectTypeSelector.Text;
            if (Variables.ProjectType == "New Project")
            {
                TemplateSelector.IsEnabled = true;
                ArtifactsCheckBox.IsEnabled = true;
                BuildCheckBox.IsEnabled = true;
                DocsCheckBox.IsEnabled = true;
                LibCheckBox.IsEnabled = true;
                PackagesCheckBox.IsEnabled = true;
                SamplesCheckBox.IsEnabled = true;
                TestCheckBox.IsEnabled = true;
                DotNetNewOptionsBox.IsEnabled = true;
            }
            else
            {
                TemplateSelector.IsEnabled = false;
                ArtifactsCheckBox.IsEnabled = false;
                BuildCheckBox.IsEnabled = false;
                DocsCheckBox.IsEnabled = false;
                LibCheckBox.IsEnabled = false;
                PackagesCheckBox.IsEnabled = false;
                SamplesCheckBox.IsEnabled = false;
                TestCheckBox.IsEnabled = false;
                DotNetNewOptionsBox.IsEnabled = false;
            }
        }

        //Declare Templates
        public void TemplateSelector_DropDownClosed(object sender, EventArgs e)
        {
            if (TemplateSelector.IsDropDownOpen == false)
            {
                switch (TemplateSelector.Text)
                {
                    case "Console Application":
                        Variables.SelectedTemplate = "console";
                        break;
                    case "Class library":
                        Variables.SelectedTemplate = "classlib";
                        break;
                    case "Unit Test Project":
                        Variables.SelectedTemplate = "mstest";
                        break;
                    case "NUnit 3 Test Project":
                        Variables.SelectedTemplate = "nunit";
                        break;
                    case "NUnit 3 Test Item":
                        Variables.SelectedTemplate = "nunit-test";
                        break;
                    case "xUnit Test Project":
                        Variables.SelectedTemplate = "xunit";
                        break;
                    case "Razor Page":
                        Variables.SelectedTemplate = "page";
                        break;
                    case "MVC ViewImports":
                        Variables.SelectedTemplate = "viewimports";
                        break;
                    case "MVC ViewStart":
                        Variables.SelectedTemplate = "viewstart";
                        break;
                    case "ASP.NET Core Empty":
                        Variables.SelectedTemplate = "web";
                        break;
                    case "ASP.NET Core Web App (Model-View-Controller)":
                        Variables.SelectedTemplate = "mvc";
                        break;
                    case "Console":
                        Variables.SelectedTemplate = "console";
                        break;
                    case "ASP.NET Core Web App":
                        Variables.SelectedTemplate = "webapp";
                        break;
                    case "ASP.NET Core with Angular":
                        Variables.SelectedTemplate = "angular";
                        break;
                    case "ASP.NET Core with React.js":
                        Variables.SelectedTemplate = "react";
                        break;
                    case "ASP.NET Core with React.js and Redux":
                        Variables.SelectedTemplate = "reactredux";
                        break;
                    case "Razor Class Library":
                        Variables.SelectedTemplate = "razorclasslib";
                        break;
                    case "ASP.NET Core Web API":
                        Variables.SelectedTemplate = "webapi";
                        break;
                    case "global.json file":
                        Variables.SelectedTemplate = "globaljson";
                        break;
                    case "NuGet Config":
                        Variables.SelectedTemplate = "nugetconfig";
                        break;
                    case "Web Config":
                        Variables.SelectedTemplate = "webconfig";
                        break;
                    case "Solution File":
                        Variables.SelectedTemplate = "sln";
                        break;

                }
            }
        }

        //Open "Select Folder" Dialog
        public void SelectPathButton_Click(object sender, RoutedEventArgs e)
        {
            var blup = new OpenFileDialog();
            blup.Filter = "Directory|*.this.directory";
            blup.ShowDialog();

            var dialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            if (dialog.ShowDialog(this).GetValueOrDefault())
            {
                PathBox.Text = dialog.SelectedPath;
            }
        }
        public void PathBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Variables.Directory = PathBox.Text;
            if (PathBox.Text != "")
            {
                OptionsTab.IsEnabled = true;
                FinishTab.IsEnabled = true;
            }
        }
        public void ArtifactsCheckBox_Changed(object sender, RoutedEventArgs e)
        {
            if (ArtifactsCheckBox.IsChecked == true)
            {
                Variables.Artifacts = "mkdir artifacts";
            }
            else
            {
                Variables.Artifacts = "";
            }
        }
        public void BuildCheckBox_Changed(object sender, RoutedEventArgs e)
        {
            if (BuildCheckBox.IsChecked == true)
            {
                Variables.Build = "mkdir build";
            }
            else
            {
                Variables.Build = "";
            }
        }
        public void DocsCheckBox_Changed(object sender, RoutedEventArgs e)
        {
            if (DocsCheckBox.IsChecked == true)
            {
                Variables.Docs = "mkdir docs";
            }
            else
            {
                Variables.Docs = "";
            }
        }
        public void LibCheckBox_Changed(object sender, RoutedEventArgs e)
        {
            if (LibCheckBox.IsChecked == true)
            {
                Variables.Lib = "mkdir lib";
            }
            else
            {
                Variables.Lib = "";
            }
        }
        public void PackagesCheckBox_Changed(object sender, RoutedEventArgs e)
        {
            if (PackagesCheckBox.IsChecked == true)
            {
                Variables.Packages = "mkdir packages";
            }
            else
            {
                Variables.Packages = "";
            }
        }
        public void SamplesCheckBox_Changed(object sender, RoutedEventArgs e)
        {
            if (SamplesCheckBox.IsChecked == true)
            {
                Variables.Samples = "mkdir samples";
            }
            else
            {
                Variables.Samples = "";
            }
        }
        public void TestCheckBox_Changed(object sender, RoutedEventArgs e)
        {
            if (TestCheckBox.IsChecked == true)
            {
                Variables.Test = "mkdir test";
            }
            else
            {
                Variables.Test = "";
            }
        }
        public void DotNetNewOptionsBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DotNetNewOptionsBox.Text != "")
            {
                Variables.Options = DotNetNewOptionsBox.Text;
            }
        }
        public void Tab_Changed(object sender, SelectionChangedEventArgs e)
        {
            TabItem Tab = Tabs.SelectedItem as TabItem;
            var CurrentTab = Tab.Header.ToString();

            //Build  structoring script
            if (CurrentTab == "Finish")
            {
                string[] FinalCommands = { "cd " + Variables.Directory, "mkdir src", Variables.Artifacts, Variables.Build, Variables.Docs, Variables.Lib, Variables.Samples, Variables.Packages, Variables.Test, "cd src", "dotnet new " + Variables.SelectedTemplate + " " + Variables.Options };
                CommandSummaryBox.Clear();
                for (int i = 0; i < FinalCommands.Length; i++)
                {
                    if (FinalCommands[i] != null && FinalCommands[i] != "" && FinalCommands[i] != "\r\n")
                    {
                        CommandSummaryBox.AppendText(FinalCommands[i] + "\r\n");
                    }
                }
                CommandSummaryBox.Text = CommandSummaryBox.Text.Remove(CommandSummaryBox.Text.LastIndexOf(Environment.NewLine));
            }
        }
    }
}