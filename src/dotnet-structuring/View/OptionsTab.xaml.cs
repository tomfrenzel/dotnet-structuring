using dotnet_structuring.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace dotnet_structuring.View
{
    public partial class OptionsTab : UserControl
    {
        private OptionsData optionsData = new OptionsData();

        public static readonly DependencyProperty ArtifactsProperty =
DependencyProperty.Register("Artifacts", typeof(bool), typeof(OptionsTab), new UIPropertyMetadata(false));

        public static readonly DependencyProperty BuildProperty =
    DependencyProperty.Register("Build", typeof(bool), typeof(OptionsTab), new UIPropertyMetadata(false));

        public static readonly DependencyProperty DocsProperty =
    DependencyProperty.Register("Docs", typeof(bool), typeof(OptionsTab), new UIPropertyMetadata(false));

        public static readonly DependencyProperty LibProperty =
    DependencyProperty.Register("Lib", typeof(bool), typeof(OptionsTab), new UIPropertyMetadata(false));

        public static readonly DependencyProperty PackagesProperty =
    DependencyProperty.Register("Packages", typeof(bool), typeof(OptionsTab), new UIPropertyMetadata(false));

        public static readonly DependencyProperty SamplesProperty =
    DependencyProperty.Register("Samples", typeof(bool), typeof(OptionsTab), new UIPropertyMetadata(false));

        public static readonly DependencyProperty TestsProperty =
    DependencyProperty.Register("Test", typeof(bool), typeof(OptionsTab), new UIPropertyMetadata(false));

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

        public OptionsTab()
        {
            InitializeComponent();
            DataContext = this;
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