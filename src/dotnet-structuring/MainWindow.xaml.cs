﻿using dotnet_structuring.library;
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
        public string PlaceholderText { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        Variables Variables = new Variables();
        Execute Execute = new library.Execute();
        int LogNum;
        string CurrentLog;
        private void WireEventHandlers(Execute e)
        {
            ExecutionHandler handler = new ExecutionHandler(OnIncommingEventLog);
            e.LogEvent += handler;
        }

        public void OnIncommingEventLog(object sender, EventLogger e)
        {
            LogNum++;

            this.Dispatcher.Invoke(() => CurrentLog = e.logs);
            this.Dispatcher.Invoke(() => OutputBox.AppendText(CurrentLog + Environment.NewLine));
            if (LogNum < Variables.ProccessAmount)
            {
                pbStatus.Value++;
            }
            else if (LogNum > Variables.ProccessAmount)
            {
                this.Dispatcher.Invoke(() => pbStatus.IsIndeterminate = false);
                Style style = this.FindResource("ProgressBarWarningStripe") as Style;
                this.Dispatcher.Invoke(() => pbStatus.Style = style);
               

            }
            if (CurrentLog == "Done.")
            {
                this.Dispatcher.Invoke(() => pbStatus.IsIndeterminate = true);
                this.Dispatcher.Invoke(() => pbStatus.Value = 1);
                Style style = this.Dispatcher.Invoke(() => this.FindResource("ProgressBarSuccess") as Style);
                this.Dispatcher.Invoke(() => pbStatus.Style = style);
            }
        }
        public void ExecButton_Click(object sender, RoutedEventArgs e)
        {
            OutputBox.Clear();
            Execute OutputLogs = new Execute();
            WireEventHandlers(OutputLogs);
            OutputLogs.CreateScript(Variables.Directories, Variables.NETCommand, Variables.ProjectName);
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
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                PathBox.Text = dialog.SelectedPath.ToString();

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
                Variables.Artifacts = "artifacts";
                Variables.ProccessAmount++;
            }
            else
            {
                Variables.Artifacts = "";
                Variables.ProccessAmount--;
            }
        }
        public void BuildCheckBox_Changed(object sender, RoutedEventArgs e)
        {
            if (BuildCheckBox.IsChecked == true)
            {
                Variables.Build = "build";
                Variables.ProccessAmount++;
            }
            else
            {
                Variables.Build = "";
                Variables.ProccessAmount--;
            }
        }
        public void DocsCheckBox_Changed(object sender, RoutedEventArgs e)
        {
            if (DocsCheckBox.IsChecked == true)
            {
                Variables.Docs = "docs";
                Variables.ProccessAmount++;
            }
            else
            {
                Variables.Docs = "";
                Variables.ProccessAmount--;
            }
        }
        public void LibCheckBox_Changed(object sender, RoutedEventArgs e)
        {
            if (LibCheckBox.IsChecked == true)
            {
                Variables.Lib = "lib";
                Variables.ProccessAmount++;
            }
            else
            {
                Variables.Lib = "";
                Variables.ProccessAmount--;
            }
        }
        public void PackagesCheckBox_Changed(object sender, RoutedEventArgs e)
        {
            if (PackagesCheckBox.IsChecked == true)
            {
                Variables.Packages = "packages";
                Variables.ProccessAmount++;
            }
            else
            {
                Variables.Packages = "";
                Variables.ProccessAmount--;
            }
        }
        public void SamplesCheckBox_Changed(object sender, RoutedEventArgs e)
        {
            if (SamplesCheckBox.IsChecked == true)
            {
                Variables.Samples = "samples";
                Variables.ProccessAmount++;
            }
            else
            {
                Variables.Samples = "";
                Variables.ProccessAmount--;
            }
        }
        public void TestCheckBox_Changed(object sender, RoutedEventArgs e)
        {
            if (TestCheckBox.IsChecked == true)
            {
                Variables.Test = "test";
                Variables.ProccessAmount++;
            }
            else
            {
                Variables.Test = "";
                Variables.ProccessAmount--;
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
                Variables.Directories = new string[] { Variables.Directory, "src", Variables.Artifacts, Variables.Build, Variables.Docs, Variables.Lib, Variables.Samples, Variables.Packages, Variables.Test };
                ProjectNameBox.Text = ProjectNameBox.Text.Replace(" ", "_");
                Variables.ProjectName = ProjectNameBox.Text;
                Variables.NETCommand = " new " + Variables.SelectedTemplate + " " + Variables.Options + "-o src/" + ProjectNameBox.Text + " -n " + ProjectNameBox.Text;
                CommandSummaryBox.Clear();
                for (int i = 1; i < Variables.Directories.Length; i++)
                {
                    if (Variables.Directories[i] != null && Variables.Directories[i] != "" && Variables.Directories[i] != Environment.NewLine)
                    {
                        CommandSummaryBox.AppendText("Create Directory: " + Variables.Directories[i] + Environment.NewLine);
                    }
                }
                CommandSummaryBox.AppendText("Execute: dotnet" + Variables.NETCommand + Environment.NewLine);
                CommandSummaryBox.Text = CommandSummaryBox.Text.Remove(CommandSummaryBox.Text.LastIndexOf(Environment.NewLine));
            }
        }
    }
}