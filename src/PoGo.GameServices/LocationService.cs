using PoGo.ApiClient.Interfaces;
using POGOProtos.Data;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using System;

namespace PoGo.GameServices
{

    /// <summary>
    /// Manages the game logic for your current location and what is nearby.
    /// </summary>
    public class LocationService : GameServiceBase
    {

        #region Private Members

        private ObservableCollectionPlus<PokemonData> _catchablePokemon = default(ObservableCollectionPlus<PokemonData>);
        private Geoposition _currentPosition = null;
        private Geolocator _geolocator = null;
        private ObservableCollectionPlus<PokemonData> _nearbyPokemon = default(ObservableCollectionPlus<PokemonData>);
        private ObservableCollectionPlus<PokemonData> _nearbyPokestops = default(ObservableCollectionPlus<PokemonData>);

        #endregion

        #region Properties

        /// <summary>
        /// An <see cref="ObservableCollectionPlus{PokemonData}"/> containing all of the Pokemon that are close enough
        /// to the user to be caught from the <see cref="CurrentPosition"/>. Observable.
        /// </summary>
        public ObservableCollectionPlus<PokemonData> CatchablePokemon
        {
            get { return _catchablePokemon; }
            set { Set(ref _catchablePokemon, value); }
        }

        /// <summary>
        /// The most recently-reported position reported by the Geolocator. Observable.
        /// </summary>
        public Geoposition CurrentPosition
        {
            get { return _currentPosition; }
            private set { Set(ref _currentPosition, value); }
        }

        /// <summary>
        /// An <see cref="ObservableCollectionPlus{PokemonData}"/> containing all of the Pokemon that are within "radar"
        /// range of the <see cref="CurrentPosition"/>. Observable.
        /// </summary>
        public ObservableCollectionPlus<PokemonData> NearbyPokemon
        {
            get { return _nearbyPokemon; }
            set { Set(ref _nearbyPokemon, value); }
        }

        /// <summary>
        /// An <see cref="ObservableCollectionPlus{PokemonData}"/> containing all of the Pokestops close enough to the
        /// <see cref="CurrentPosition"/> to be visible. Observable.
        /// </summary>
        public ObservableCollectionPlus<PokemonData> NearbyPokestops
        {
            get { return _nearbyPokestops; }
            set { Set(ref _nearbyPokestops, value); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the <see cref="PokedexService"/>. 
        /// </summary>
        /// <param name="apiClient">The <see cref="IPokemonGoApiClient"/> instance to use for any Pokemon Go API requests.</param>

        public LocationService(IPokemonGoApiClient apiClient) : base(apiClient)
        {
            CatchablePokemon = new ObservableCollectionPlus<PokemonData>();
            NearbyPokemon = new ObservableCollectionPlus<PokemonData>();
            NearbyPokestops = new ObservableCollectionPlus<PokemonData>();
            _geolocator = new Geolocator
            {
                DesiredAccuracy = PositionAccuracy.High,
                DesiredAccuracyInMeters = 5,
                ReportInterval = 1000,
                MovementThreshold = 5
            };
            // @robertmclaws to do: Should we break this out into a separate function so it can be unregistered?
            _geolocator.PositionChanged += async (Geolocator sender, PositionChangedEventArgs args) => 
            {
                CurrentPosition = await sender.GetGeopositionAsync();
            };
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Starts updating the <see cref="CurrentPosition"/> at the <see cref="Geolocator.ReportInterval"/>.
        /// </summary>
        public async Task BeginReportingPositionAsync()
        {
            CurrentPosition = CurrentPosition ?? await _geolocator.GetGeopositionAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void ResetState()
        {
            CatchablePokemon.Clear();
            NearbyPokemon.Clear();
            NearbyPokestops.Clear();
            // @robertmclaws: Should we re-initialize the Geolocator here?
        }

        /// <summary>
        /// Updates the MovementThreshold for the <see cref="Geolocator"/>.
        /// </summary>
        /// <param name="newMovementThreshold"></param>
        public void UpdateMovementThreshold(float newMovementThreshold)
        {
            _geolocator.MovementThreshold = newMovementThreshold;
        }

        #endregion

    }

}