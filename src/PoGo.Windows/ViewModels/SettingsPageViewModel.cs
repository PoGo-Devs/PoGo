using System;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.ApplicationModel;
using Windows.UI.Xaml;

namespace PoGo.Windows.ViewModels
{
    public class SettingsPageViewModel : ViewModelBase
    {
        public SettingsPartViewModel SettingsPartViewModel { get; } = new SettingsPartViewModel();
        public AboutPartViewModel AboutPartViewModel { get; } = new AboutPartViewModel();
    }

    public class SettingsPartViewModel : ViewModelBase
    {
        Services.SettingsServices.SettingsService _settings;

        public SettingsPartViewModel()
        {
            if (DesignMode.DesignModeEnabled)
            {
                // designtime
            }
            else
            {
                _settings = Services.SettingsServices.SettingsService.Instance;
            }
        }

        public bool UseShellBackButton
        {
            get { return _settings.UseShellBackButton; }
            set { _settings.UseShellBackButton = value; base.RaisePropertyChanged(); }
        }

        public bool UseLightThemeButton
        {
            get { return _settings.AppTheme.Equals(ApplicationTheme.Light); }
            set { _settings.AppTheme = value ? ApplicationTheme.Light : ApplicationTheme.Dark; base.RaisePropertyChanged(); }
        }

        private string _BusyText = "Please wait...";
        public string BusyText
        {
            get { return _BusyText; }
            set
            {
                Set(ref _BusyText, value);
                _ShowBusyCommand.RaiseCanExecuteChanged();
            }
        }

        DelegateCommand _ShowBusyCommand;
        public DelegateCommand ShowBusyCommand
            => _ShowBusyCommand ?? (_ShowBusyCommand = new DelegateCommand(async () =>
            {
                Views.Busy.SetBusy(true, _BusyText);
                await Task.Delay(5000);
                Views.Busy.SetBusy(false);
            }, () => !string.IsNullOrEmpty(BusyText)));
    }

    public class AboutPartViewModel : ViewModelBase
    {
        public Uri Logo => Package.Current.Logo;

        public string DisplayName => Package.Current.DisplayName;

        public string Publisher => Package.Current.PublisherDisplayName;

        public string Version
        {
            get
            {
                var v = Package.Current.Id.Version;
                return $"{v.Major}.{v.Minor}.{v.Build}.{v.Revision}";
            }
        }

        public Uri RateMe => new Uri("http://aka.ms/template10");
    }
}

