using dotnet_structuring.library;
using dotnet_structuring.library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static dotnet_structuring.library.StructuringDelegate;

namespace dotnet_structuring.View
{
    /// <summary>
    /// Interaction logic for FinishTab.xaml
    /// </summary>
    public partial class FinishTab : UserControl
    {
        public string PlaceholderText { get; set; }
        public string ProjectType { get; private set; }
        public int ProccessAmount { get; private set; }
        public string Options { get; private set; }
        public string OutputDirectory { get; private set; }
        public string NetCommand { get; private set; }
        public string ProjectName { get; private set; }
        public string TemplateName { get; private set; }
        private int logNum;
        private string currentLog;
        public IEnumerable<Template> initializeTemplates = InitializeTemplates.Templates;
        private Template template = new Template();

        GeneralTab generalTab = new GeneralTab();
        OptionsTab optionsTab = new OptionsTab();

        private List<string> Directories = new List<string>();
        public FinishTab()
        {
            InitializeComponent();

            Directories.Clear();
            CommandSummaryBox.Text = "";
            var children = LogicalTreeHelper.GetChildren(optionsTab.options);

            foreach (var item in children)
            {
                var checkbox = item as CheckBox;
                if (checkbox != null)
                {
                    if (checkbox.IsChecked == true)
                    {
                        Directories.Add(checkbox.Content.ToString());
                        CommandSummaryBox.Text += ("Create Directory: " + checkbox.Content.ToString() + Environment.NewLine);
                    }
                }
            }
            generalTab.ProjectNameBox.Text = generalTab.ProjectNameBox.Text.Replace(" ", "_");
            ProjectName = generalTab.ProjectNameBox.Text;
            template = initializeTemplates.First(x => x.Name.Contains(generalTab.TemplateSelector.Text));
            NetCommand = $" new {template.ShortName} {Options} -o src/{generalTab.ProjectNameBox.Text} -n {generalTab.ProjectNameBox.Text}";
            CommandSummaryBox.Text += ("Execute: dotnet" + NetCommand + Environment.NewLine);
            CommandSummaryBox.Text = CommandSummaryBox.Text.Remove(CommandSummaryBox.Text.LastIndexOf(Environment.NewLine));
        }
        private void WireEventHandlers(Structuring e)
        {
            StructuringHandler handler = new StructuringHandler(OnIncommingEventLog);
            e.LogEvent += handler;
        }

        public void OnIncommingEventLog(object sender, EventLogger e)
        {
            logNum++;

            this.Dispatcher.Invoke(() =>
            {
                currentLog = e.logs;
            });
            this.Dispatcher.Invoke(() => OutputBox.Text += (currentLog + Environment.NewLine));
            this.Dispatcher.Invoke(() => OutputBox.Text = Regex.Replace(OutputBox.Text, @"[\r\n]{2,}", Environment.NewLine));
            if (logNum < ProccessAmount)
            {
                pbStatus.Value++;
            }
            if (currentLog == "Done.")
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
            Structuring OutputLogs = new Structuring();
            this.Dispatcher.Invoke(() => pbStatus.IsIndeterminate = true);
            Style style = this.FindResource("ProgressBarWarningStripe") as Style;
            this.Dispatcher.Invoke(() => pbStatus.Style = style);
            WireEventHandlers(OutputLogs);
            await OutputLogs.AsyncRunStructuring(OutputDirectory, Directories, NetCommand, ProjectName);
        }
    }
}
