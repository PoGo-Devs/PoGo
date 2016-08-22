using PoGo.ApiClient;
using PoGo.ApiClient.Wrappers;
using PoGo.GameServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using Windows.ApplicationModel;
using Windows.UI.Xaml.Navigation;

namespace PoGo.Windows.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {

        #region Private Members

        string _Value = "Gas";
        PokedexService _pokedexService = null;

        #endregion

        #region Properties

        public string Value
        {
            get { return _Value; }
            set { Set(ref _Value, value); }
        }

        /// <summary>
        /// The <see cref="PokedexService"/> instance we can bind to.
        /// </summary>
        public PokedexService PokedexService
        {
            get { return _pokedexService; }
            set { Set(ref _pokedexService, value); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>RWM: DO NOT call this constructor at runtime!</remarks>
        public MainPageViewModel()
        {
            if (DesignMode.DesignModeEnabled)
            {
                Value = "Designtime value";
                if (PokedexService == null)
                {
                    PokedexService = new PokedexService(new PokemonGoApiClient(null, null, null));
                }
                PokedexService.PokedexInventory.Add(new PokemonData("Abra"));
                PokedexService.PokedexInventory.Add(new PokemonData("Pikachu"));
                PokedexService.PokemonInventory.Add(new PokemonData("Abra"));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pokedexService"></param>
        /// <remarks>RWM: This is the constructor you call at runtime.</remarks>
        public MainPageViewModel(PokedexService pokedexService) : this()
        {
            PokedexService = pokedexService;
        }

        #endregion

        #region Navigation Event Handlers

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            if (suspensionState.Any())
            {
                Value = suspensionState[nameof(Value)]?.ToString();
            }
            PokedexService.GetPokedexInventory();
            PokedexService.GetPokemonInventory();
            await Task.CompletedTask;
        }

        public override async Task OnNavigatedFromAsync(IDictionary<string, object> suspensionState, bool suspending)
        {
            if (suspending)
            {
                suspensionState[nameof(Value)] = Value;
            }
            await Task.CompletedTask;
        }

        public override async Task OnNavigatingFromAsync(NavigatingEventArgs args)
        {
            args.Cancel = false;
            await Task.CompletedTask;
        }

        #endregion

        #region Navigation Commands

        public void GotoDetailsPage() =>
            NavigationService.Navigate(typeof(Views.DetailPage), Value);

        public void GotoSettings() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 0);

        public void GotoPrivacy() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 1);

        public void GotoAbout() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 2);

        #endregion

    }
}

