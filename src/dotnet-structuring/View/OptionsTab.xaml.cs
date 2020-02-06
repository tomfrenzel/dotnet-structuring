using dotnet_structuring.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace dotnet_structuring.View
{

    public partial class OptionsTab : UserControl
    {
        private OptionsData optionsData = new OptionsData();
        public string UserName
        {
            get { return (string)GetValue(UserNameProperty); }
            set { SetValue(UserNameProperty, value); }
        }

        public static readonly DependencyProperty UserNameProperty =
            DependencyProperty.Register("UserName", typeof(string), typeof(OptionsTab), new UIPropertyMetadata(null));

        public OptionsTab()
        {
            InitializeComponent();
            DataContext = this;

            DotNetNewOptionsBox.Text = optionsData.FolderPath;
        }

        public void DotNetNewOptionsBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DotNetNewOptionsBox.Text != "")
            {
               optionsData.Options = DotNetNewOptionsBox.Text;
            }
        }
    }
}
