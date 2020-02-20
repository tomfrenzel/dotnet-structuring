using dotnet_structuring.library;
using dotnet_structuring.library.Models;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using static dotnet_structuring.library.Helpers.Logging.Logging;
using static dotnet_structuring.View.GeneralTab;

namespace dotnet_structuring.View
{
    public class Options
    {
        public string Name { get; set; }
        public bool IsChecked { get; set; }
    }

    public partial class FinishTab : UserControl
    {
        public int ProccessAmount { get; private set; }

        public string NetCommand { get; private set; }

        private int logNum;
        private string currentLog;
        private IEnumerable<Template> initializeTemplates = InitializeTemplates.Templates;

        public static readonly DependencyProperty ProjectNameProperty =
            DependencyProperty.Register("ProjectName", typeof(string), typeof(FinishTab), new UIPropertyMetadata("New Project"));

        public static readonly DependencyProperty FolderPathProperty =
            DependencyProperty.Register("FolderPath", typeof(string), typeof(FinishTab), new UIPropertyMetadata(null));

        public static readonly DependencyProperty TypeProperty =
    DependencyProperty.Register("Type", typeof(ProjectTypes), typeof(FinishTab), new UIPropertyMetadata(ProjectTypes.New));

        public static readonly DependencyProperty STemplateProperty =
    DependencyProperty.Register("STemplate", typeof(Template), typeof(FinishTab), new UIPropertyMetadata(InitializeTemplates.Templates[0]));

        public static readonly DependencyProperty ArtifactsProperty =
    DependencyProperty.Register("Artifacts", typeof(bool), typeof(FinishTab), new UIPropertyMetadata(false));

        public static readonly DependencyProperty BuildProperty =
    DependencyProperty.Register("Build", typeof(bool), typeof(FinishTab), new UIPropertyMetadata(false));

        public static readonly DependencyProperty DocsProperty =
    DependencyProperty.Register("Docs", typeof(bool), typeof(FinishTab), new UIPropertyMetadata(false));

        public static readonly DependencyProperty LibProperty =
    DependencyProperty.Register("Lib", typeof(bool), typeof(FinishTab), new UIPropertyMetadata(false));

        public static readonly DependencyProperty PackagesProperty =
    DependencyProperty.Register("Packages", typeof(bool), typeof(FinishTab), new UIPropertyMetadata(false));

        public static readonly DependencyProperty SamplesProperty =
    DependencyProperty.Register("Samples", typeof(bool), typeof(FinishTab), new UIPropertyMetadata(false));

        public static readonly DependencyProperty TestsProperty =
    DependencyProperty.Register("Test", typeof(bool), typeof(FinishTab), new UIPropertyMetadata(false));

        public ProjectTypes Type
        {
            get { return (ProjectTypes)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }

        public string ProjectName
        {
            get { return (string)GetValue(ProjectNameProperty); }
            set { SetValue(ProjectNameProperty, value); }
        }

        public string FolderPath
        {
            get { return (string)GetValue(FolderPathProperty); }
            set { SetValue(FolderPathProperty, value); }
        }

        public Template STemplate
        {
            get { return (Template)GetValue(STemplateProperty); }
            set { SetValue(STemplateProperty, value); }
        }

        public bool Artifacts
        {
            get { return (bool)GetValue(ArtifactsProperty); }
            set { SetValue(ArtifactsProperty, value); }
        }

        public bool Build
        {
            get { return (bool)GetValue(BuildProperty); }
            set { SetValue(BuildProperty, value); }
        }

        public bool Docs
        {
            get { return (bool)GetValue(DocsProperty); }
            set { SetValue(DocsProperty, value); }
        }

        public bool Lib
        {
            get { return (bool)GetValue(LibProperty); }
            set { SetValue(LibProperty, value); }
        }

        public bool Packages
        {
            get { return (bool)GetValue(PackagesProperty); }
            set { SetValue(PackagesProperty, value); }
        }

        public bool Samples
        {
            get { return (bool)GetValue(SamplesProperty); }
            set { SetValue(SamplesProperty, value); }
        }

        public bool Test
        {
            get { return (bool)GetValue(TestsProperty); }
            set { SetValue(TestsProperty, value); }
        }

        private readonly List<string> Directories = new List<string>();

        public FinishTab()
        {
            InitializeComponent();

            Directories.Clear();
            CommandSummaryBox.Text = "";
        }

        public void WireEventHandlers(Structuring e)
        {
            StructuringHandler handler = new StructuringHandler(OnIncommingEventLog);
            e.LogEvent += handler;
        }

        public void OnIncommingEventLog(object sender, string e)
        {
            logNum++;
            this.Dispatcher.Invoke(() =>
            {
                currentLog = e;
                OutputBox.Text += (currentLog + Environment.NewLine);
                OutputBox.Text = Regex.Replace(OutputBox.Text, @"[\r\n]{2,}", Environment.NewLine);

                if (logNum < ProccessAmount)
                {
                    pbStatus.Value++;
                }
                if (currentLog == "Done.")
                {
                    pbStatus.IsIndeterminate = true;
                    pbStatus.Value = 1;
                    Style style = this.FindResource("ProgressBarSuccess") as Style;
                    pbStatus.Style = style;
                }
            });
        }

        public async void ExecButton_Click(object sender, RoutedEventArgs e)
        {
            StandardProcess process = new StandardProcess();
            OutputBox.Text = "";
            Structuring OutputLogs = new Structuring(process);
            this.Dispatcher.Invoke(() =>
            {
                pbStatus.IsIndeterminate = true;
                Style style = this.FindResource("ProgressBarWarningStripe") as Style;
                pbStatus.Style = style;
            });
            WireEventHandlers(OutputLogs);
            await OutputLogs.RunStructuringAsync(FolderPath, Directories, NetCommand, ProjectName);
        }

        private void PreviewButton_Click(object sender, RoutedEventArgs e)
        {
            CommandSummaryBox.Text = "";
            if (Artifacts == true)
            {
                Directories.Add("artifacts");
                CommandSummaryBox.Text += ("Create Directory: artifacts" + Environment.NewLine);
            }
            if (Build == true)
            {
                Directories.Add("build");
                CommandSummaryBox.Text += ("Create Directory: build" + Environment.NewLine);
            }
            if (Docs == true)
            {
                Directories.Add("docs");
                CommandSummaryBox.Text += ("Create Directory: docs" + Environment.NewLine);
            }
            if (Lib == true)
            {
                Directories.Add("lib");
                CommandSummaryBox.Text += ("Create Directory: lib" + Environment.NewLine);
            }
            if (Packages == true)
            {
                Directories.Add("packages");
                CommandSummaryBox.Text += ("Create Directory: packages" + Environment.NewLine);
            }
            if (Samples == true)
            {
                Directories.Add("samples");
                CommandSummaryBox.Text += ("Create Directory: samples" + Environment.NewLine);
            }
            if (Test == true)
            {
                Directories.Add("test");
                CommandSummaryBox.Text += ("Create Directory: test" + Environment.NewLine);
            }

            if (STemplate != null)
            {
                NetCommand = $" new {STemplate.ShortName} -o src/{ProjectName} -n {ProjectName}";
                CommandSummaryBox.Text += ("Execute: dotnet" + NetCommand + Environment.NewLine);
                CommandSummaryBox.Text = CommandSummaryBox.Text.Remove(CommandSummaryBox.Text.LastIndexOf(Environment.NewLine));
            }
        }
    }
}