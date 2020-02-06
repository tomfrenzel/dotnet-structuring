using dotnet_structuring.library;
using dotnet_structuring.library.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using static dotnet_structuring.library.StructuringDelegate;
using dotnet_structuring.View;
using dotnet_structuring.ViewModel;

namespace dotnet_structuring
{
    public partial class MainWindow : Window
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

        private List<string> Directories = new List<string>();

        public MainWindow()
        {
            InitializeComponent();

    }

        //public void ProjectTypeSelector_DropDownClosed(object sender, EventArgs e)
        //{
        //    ProjectType = ProjectTypeSelector.Text;
        //    if (ProjectType == "New Project")
        //    {
        //        if (ProjectType == "New Project")
        //        {
        //            ValidateAccess(true);
        //        }
        //        else
        //        {
        //            ValidateAccess(false);
        //        }
        //    }
        //}

        private void ValidateAccess(bool enabled)
        {
            //PathBox.IsEnabled = enabled;
            //TemplateSelector.IsEnabled = enabled;
            //ArtifactsCheckBox.IsEnabled = enabled;
            //BuildCheckBox.IsEnabled = enabled;
            //DocsCheckBox.IsEnabled = enabled;
            //LibCheckBox.IsEnabled = enabled;
            //PackagesCheckBox.IsEnabled = enabled;
            //SamplesCheckBox.IsEnabled = enabled;
            //TestCheckBox.IsEnabled = enabled;
            //DotNetNewOptionsBox.IsEnabled = enabled;
        }
    }
}