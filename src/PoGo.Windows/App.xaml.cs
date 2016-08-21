using Autofac;
using PoGo.ApiClient;
using PoGo.ApiClient.Interfaces;
using PoGo.GameServices;
using PoGo.Windows.Services.SettingsServices;
using PoGo.Windows.ViewModels;
using PoGo.Windows.Views;
using System;
using System.Threading.Tasks;
using Template10.Services.NavigationService;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace PoGo.Windows
{
    /// Documentation on APIs used in this page:
    /// https://github.com/Windows-XAML/Template10/wiki

    [Bindable]
    sealed partial class App : Template10.Common.BootStrapper
    {

        #region Private Members



        #endregion

        #region Properties

        /// <summary>
        /// The Autofac Container instance to use for the application.
        /// </summary>
        public static IContainer Container { get; private set; }

        #endregion

        #region Constructor

        public App()
        {
            InitializeComponent();
            SplashFactory = (e) => new Views.Splash(e);

            #region App settings

            var _settings = Services.SettingsServices.SettingsService.Instance;
            RequestedTheme = _settings.AppTheme;
            CacheMaxDuration = _settings.CacheMaxDuration;
            ShowShellBackButton = _settings.UseShellBackButton;

            #endregion
        }

        #endregion

        #region Lifecycle Overrides

        public override async Task OnInitializeAsync(IActivatedEventArgs args)
        {
            var builder = new ContainerBuilder();

            //RWM: Register API Client
            builder.RegisterType<PokemonGoApiClient>().As<IPokemonGoApiClient>();

            //RWM: Register GameServices, making sure you call the right constructor.
            builder.Register(context => new PokedexService(context.Resolve<IPokemonGoApiClient>())).As<PokedexService>();

            //RWM: Register ViewModels
            builder.RegisterType<MainPageViewModel>();

            //RWM: Build the container.
            Container = builder.Build();
            
            //RWM: This is not necessarily the right way to do this. There needs to be a way to dispose of the container.
            Container.BeginLifetimeScope();
            await Task.CompletedTask;
        }

        public override async Task OnStartAsync(StartKind startKind, IActivatedEventArgs args)
        {
            // long-running startup tasks go here

            NavigationService.Navigate(typeof(MainPage));
            await Task.CompletedTask;
        }

        /// <summary>
        /// This is basically a ViewModelLocator.
        /// </summary>
        /// <param name="page"></param>
        /// <param name="navigationService"></param>
        /// <returns></returns>
        public override INavigable ResolveForPage(Page page, NavigationService navigationService)
        {
            if (page is MainPage)
            {
                return Container.Resolve<MainPageViewModel>();
            }
            else
                return base.ResolveForPage(page, navigationService);
        }

        #endregion

    }
}

