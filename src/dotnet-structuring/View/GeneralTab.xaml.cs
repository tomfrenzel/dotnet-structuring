using dotnet_structuring.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace dotnet_structuring.View
{
    public partial class GeneralTab : UserControl
    {
        private GeneralData generalData = new GeneralData();

        public GeneralTab()
        {
            DataContext = generalData;
            InitializeComponent();
        }

        private void SelectPathButton_Click(object sender, RoutedEventArgs e)
        {
            using var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            PathBox.Text = dialog.SelectedPath.ToString();
        }

        public void ProjectTypeSelector_DropDownClosed(object sender, EventArgs e)
        {
            generalData.Type = (ProjectTypes)ProjectTypeSelector.SelectedIndex;
            if (generalData.Type == ProjectTypes.New)
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
            generalData.FolderPath = PathBox.Text;
        }
    }
}