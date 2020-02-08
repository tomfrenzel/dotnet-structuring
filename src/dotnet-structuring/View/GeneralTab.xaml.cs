using dotnet_structuring.library;
using dotnet_structuring.library.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace dotnet_structuring.View
{
    public partial class GeneralTab : UserControl
    {
        public IEnumerable<Template> Templates { get; set; } = InitializeTemplates.Templates;

        public enum ProjectTypes
        {
            New,
            Existing
        }

        public static readonly DependencyProperty ProjectNameProperty =
           DependencyProperty.Register("ProjectName", typeof(string), typeof(GeneralTab), new UIPropertyMetadata("New Project"));

        public static readonly DependencyProperty FolderPathProperty =
            DependencyProperty.Register("FolderPath", typeof(string), typeof(GeneralTab), new UIPropertyMetadata(null));

        public static readonly DependencyProperty TypeProperty =
    DependencyProperty.Register("Type", typeof(ProjectTypes), typeof(GeneralTab), new UIPropertyMetadata(ProjectTypes.New));

        public static readonly DependencyProperty STemplateProperty =
    DependencyProperty.Register("STemplate", typeof(Template), typeof(GeneralTab), new UIPropertyMetadata(InitializeTemplates.Templates[0]));

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
        }

        //public void ProjectTypeSelector_DropDownClosed(object sender, EventArgs e)
        //{
        //    Type = (ProjectTypes)ProjectTypeSelector.SelectedIndex;
        //    if (Type == ProjectTypes.New)
        //    {
        //        ValidateAccess(true);
        //    }
        //    else
        //    {
        //        ValidateAccess(false);
        //    }
        //}

        //private void ValidateAccess(bool enabled)
        //{
        //    PathBox.IsEnabled = enabled;
        //    TemplateSelector.IsEnabled = enabled;
        //}

        private void PathBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            FolderPath = PathBox.Text;
        }
    }
}