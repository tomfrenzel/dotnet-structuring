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
        public string CurrentTab
        {
            get;
            private set;
        }
        public string SelectedTemplate
        {
            get;
            set;
        }
        public string ProjectType
        {
            get;
            set;
        }
        public string Directory
        {
            get;
            set;
        }
        public string Artifacts
        {
            get;
            set;
        }
        public string Build
        {
            get;
            set;
        }
        public string Docs
        {
            get;
            set;
        }
        public string Lib
        {
            get;
            set;
        }
        public string Packages
        {
            get;
            set;
        }
        public string Samples
        {
            get;
            set;
        }
        public string Test
        {
            get;
            set;
        }
        public string Options
        {
            get;
            set;
        }
        public Array FinalCommands
        {
            get;
            set;
        }

        private void ExecButton_Click(object sender, RoutedEventArgs e)
        {
            OutputBox.Clear();

            //Write commands to .bat File
            using (StreamWriter outputFile = new StreamWriter(System.IO.Path.Combine("dotnet-structoring.bat")))
            {
                    outputFile.WriteLine(CommandSummaryBox.Text);
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

                    OutputBox.Text = compiler.StandardOutput.ReadToEnd();

                    compiler.WaitForExit();
                }            
        }
        public void ProjectTypeSelector_DropDownClosed(object sender, EventArgs e)
        {
            ProjectType = ProjectTypeSelector.Text;
            if (ProjectType == "New Project")
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
                        SelectedTemplate = "console";
                        break;
                    case "Class library":
                        SelectedTemplate = "classlib";
                        break;
                    case "Unit Test Project":
                        SelectedTemplate = "mstest";
                        break;
                    case "NUnit 3 Test Project":
                        SelectedTemplate = "nunit";
                        break;
                    case "NUnit 3 Test Item":
                        SelectedTemplate = "nunit-test";
                        break;
                    case "xUnit Test Project":
                        SelectedTemplate = "xunit";
                        break;
                    case "Razor Page":
                        SelectedTemplate = "page";
                        break;
                    case "MVC ViewImports":
                        SelectedTemplate = "viewimports";
                        break;
                    case "MVC ViewStart":
                        SelectedTemplate = "viewstart";
                        break;
                    case "ASP.NET Core Empty":
                        SelectedTemplate = "web";
                        break;
                    case "ASP.NET Core Web App (Model-View-Controller)":
                        SelectedTemplate = "mvc";
                        break;
                    case "Console":
                        SelectedTemplate = "console";
                        break;
                    case "ASP.NET Core Web App":
                        SelectedTemplate = "webapp";
                        break;
                    case "ASP.NET Core with Angular":
                        SelectedTemplate = "angular";
                        break;
                    case "ASP.NET Core with React.js":
                        SelectedTemplate = "react";
                        break;
                    case "ASP.NET Core with React.js and Redux":
                        SelectedTemplate = "reactredux";
                        break;
                    case "Razor Class Library":
                        SelectedTemplate = "razorclasslib";
                        break;
                    case "ASP.NET Core Web API":
                        SelectedTemplate = "webapi";
                        break;
                    case "global.json file":
                        SelectedTemplate = "globaljson";
                        break;
                    case "NuGet Config":
                        SelectedTemplate = "nugetconfig";
                        break;
                    case "Web Config":
                        SelectedTemplate = "webconfig";
                        break;
                    case "Solution File":
                        SelectedTemplate = "sln";
                        break;

                }
            }
        }

        //Open "Select Folder" Dialog
        public void SelectPathButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            if (dialog.ShowDialog(this).GetValueOrDefault())
            {
                PathBox.Text = dialog.SelectedPath;
            }
        }
        public void PathBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Directory = PathBox.Text;
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
                Artifacts = "mkdir artifacts";
            }
            else
            {
                Artifacts = "";
            }
        }
        public void BuildCheckBox_Changed(object sender, RoutedEventArgs e)
        {
            if (BuildCheckBox.IsChecked == true)
            {
                Build = "mkdir build";
            }
            else
            {
                Build = "";
            }
        }
        public void DocsCheckBox_Changed(object sender, RoutedEventArgs e)
        {
            if (DocsCheckBox.IsChecked == true)
            {
                Docs = "mkdir docs";
            }
            else
            {
                Docs = "";
            }
        }
        public void LibCheckBox_Changed(object sender, RoutedEventArgs e)
        {
            if (LibCheckBox.IsChecked == true)
            {
                Lib = "mkdir lib";
            }
            else
            {
                Lib = "";
            }
        }
        public void PackagesCheckBox_Changed(object sender, RoutedEventArgs e)
        {
            if (PackagesCheckBox.IsChecked == true)
            {
                Packages = "mkdir packages";
            }
            else
            {
                Packages = "";
            }
        }
        public void SamplesCheckBox_Changed(object sender, RoutedEventArgs e)
        {
            if (SamplesCheckBox.IsChecked == true)
            {
                Samples = "mkdir samples";
            }
            else
            {
                Samples = "";
            }
        }
        public void TestCheckBox_Changed(object sender, RoutedEventArgs e)
        {
            if (TestCheckBox.IsChecked == true)
            {
                Test = "mkdir test";
            }
            else
            {
                Test = "";
            }
        }
        public void DotNetNewOptionsBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DotNetNewOptionsBox.Text != "")
            {
                Options = DotNetNewOptionsBox.Text;
            }
        }
        public void Tab_Changed(object sender, SelectionChangedEventArgs e)
        {
            TabItem Tab = Tabs.SelectedItem as TabItem;
            CurrentTab = Tab.Header.ToString();

            //Build  structoring script
            if (CurrentTab == "Finish")
            {
                string[] FinalCommands = { "cd " + Directory, "mkdir src", Artifacts, Build, Docs, Lib, Samples, Packages, Test, "cd src", "dotnet new " + SelectedTemplate + " " + Options };
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