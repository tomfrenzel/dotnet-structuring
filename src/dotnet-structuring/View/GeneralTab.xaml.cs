using dotnet_structuring.library;
using dotnet_structuring.library.Models;
using dotnet_structuring.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace dotnet_structuring.View
{
    public partial class GeneralTab : UserControl
    {
        public ProjectTypes Type { get; set; } = ProjectTypes.New;
        public string FolderPath { get; set; } = String.Empty;
        public string ProjectName { get; set; } = "New Project";
        public IEnumerable<Template> Templates { get; set; } = InitializeTemplates.Templates;
        public Template STemplate { get; set; } = InitializeTemplates.Templates[0];
    

    public enum ProjectTypes
    {
        New,
        Existing
    }
        public string IncommingData
        {
            get { return (string)GetValue(IncommingDataProperty); }
            set { SetValue(IncommingDataProperty, value); }
        }

        public static readonly DependencyProperty IncommingDataProperty =
    DependencyProperty.Register("IncommingData", typeof(string), typeof(GeneralTab), new UIPropertyMetadata(null));

      

        public GeneralTab()
        {
            DataContext = this;
            InitializeComponent();
        }

        private void SelectPathButton_Click(object sender, RoutedEventArgs e)
        {
            using var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            PathBox.Text = dialog.SelectedPath.ToString();


            //To apply IncommingData to an Object
            ProjectNameBox.Text = IncommingData;
        }

        public void ProjectTypeSelector_DropDownClosed(object sender, EventArgs e)
        {
            Type = (ProjectTypes)ProjectTypeSelector.SelectedIndex;
            if (Type == ProjectTypes.New)
            {
                ValidateAccess(true);
            }
            else
            {
                ValidateAccess(false);
            }
        }

        private void ValidateAccess(bool enabled)
        {
            PathBox.IsEnabled = enabled;
            TemplateSelector.IsEnabled = enabled;
        }

        private void PathBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            FolderPath = PathBox.Text;
        }
    }
}