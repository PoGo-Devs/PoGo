using PoGo.WindowsUniversal.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace PoGo.WindowsUniversal.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Enabled;

            //DataContext = App.Container.

        }

        MainPageViewModel _viewModel;

        public MainPageViewModel ViewModel
        {
            get { return _viewModel ?? (_viewModel = (MainPageViewModel)DataContext); }
        }

    }
}
