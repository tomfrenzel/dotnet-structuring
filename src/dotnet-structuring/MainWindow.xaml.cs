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
        public string PlaceholderText { get; set; }
        public string ProjectType { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        Variables Variables = new Variables();
        Templates templates = new Templates();
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
            this.Dispatcher.Invoke(() => pbStatus.IsIndeterminate = true);
            Style style = this.FindResource("ProgressBarWarningStripe") as Style;
            this.Dispatcher.Invoke(() => pbStatus.Style = style);
            WireEventHandlers(OutputLogs);
            OutputLogs.CreateScript(Variables.Directories, Variables.NETCommand, Variables.ProjectName);
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
                templates.SelcectTemplate(TemplateSelector.SelectedIndex);
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
                Variables.NETCommand = " new " + templates.SelectedTemplate + " " + Variables.Options + "-o src/" + ProjectNameBox.Text + " -n " + ProjectNameBox.Text;
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