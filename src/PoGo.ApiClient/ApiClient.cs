using PoGo.ApiClient.Interfaces;
using PoGo.ApiClient.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PoGo.ApiClient
{
    public class PokemonGoApiClient : IPokemonGoApiClient
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<List<PokemonData>> GetPokedexInventoryAsync()
        {
            return Task.FromResult(new List<PokemonData>()
            {
                new PokemonData("Abra"),
                new PokemonData("Cadabra"),
                new PokemonData("Alakazam")
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<List<PokemonData>> GetPokemonInventoryAsync()
        {
            return Task.FromResult(new List<PokemonData>()
            {
                new PokemonData("Alakazam")
            });
        }
    }
}
