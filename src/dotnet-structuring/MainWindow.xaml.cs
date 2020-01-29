using dotnet_structuring.library;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public int ProccessAmount { get; private set; }
        public string Options { get; private set; }
        public string OutputDirectory { get; private set; }
        public string NETCommand { get; private set; }
        public string ProjectName { get; private set; }
        public List<string> Directories = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
        }

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

            this.Dispatcher.Invoke(() =>
            {
                CurrentLog = e.logs;
            });
            this.Dispatcher.Invoke(() => OutputBox.Text += (CurrentLog + Environment.NewLine));
            this.Dispatcher.Invoke(() => OutputBox.Text = Regex.Replace(OutputBox.Text, @"[\r\n]{2,}", Environment.NewLine));
            if (LogNum < ProccessAmount)
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
        public async void ExecButton_Click(object sender, RoutedEventArgs e)
        {
            OutputBox.Text = "";
            Execute OutputLogs = new Execute();
            this.Dispatcher.Invoke(() => pbStatus.IsIndeterminate = true);
            Style style = this.FindResource("ProgressBarWarningStripe") as Style;
            this.Dispatcher.Invoke(() => pbStatus.Style = style);
            WireEventHandlers(OutputLogs);
            await OutputLogs.CreateScript(OutputDirectory, Directories.AsEnumerable(), NETCommand, ProjectName);
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
            OutputDirectory = PathBox.Text;
            if (PathBox.Text != "")
            {
                OptionsTab.IsEnabled = true;
                FinishTab.IsEnabled = true;
            }
        }
        public void DotNetNewOptionsBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DotNetNewOptionsBox.Text != "")
            {
                string Options = DotNetNewOptionsBox.Text;
            }
        }
        public void Tab_Changed(object sender, SelectionChangedEventArgs e)
        {
            TabItem Tab = Tabs.SelectedItem as TabItem;
            var CurrentTab = Tab.Header.ToString();

            //Build  structoring script
            if (CurrentTab == "Finish")
            {
                var children = LogicalTreeHelper.GetChildren(options);

                foreach (var item in children)
                {
                    var checkbox = item as CheckBox;
                    if (checkbox != null)
                    {
                        if (checkbox.IsChecked == true)
                        {
                            Directories.Add(checkbox.Name);
                        }
                        else
                        {
                            Directories.Remove(checkbox.Name);
                        }
                    }

                }

                ProjectNameBox.Text = ProjectNameBox.Text.Replace(" ", "_");
                ProjectName = ProjectNameBox.Text;
                NETCommand = " new " + templates.SelectedTemplate + " " + Options + "-o src/" + ProjectNameBox.Text + " -n " + ProjectNameBox.Text;
                CommandSummaryBox.Text = "";
                for (int i = 1; i < Directories.Count; i++)
                {
                    if (Directories[i] != null && Directories[i] != "" && Directories[i] != Environment.NewLine)
                    {
                        CommandSummaryBox.Text += ("Create Directory: " + Directories[i] + Environment.NewLine);
                    }
                }
                CommandSummaryBox.Text += ("Execute: dotnet" + NETCommand + Environment.NewLine);
                CommandSummaryBox.Text = CommandSummaryBox.Text.Remove(CommandSummaryBox.Text.LastIndexOf(Environment.NewLine));
            }
        }
    }
}