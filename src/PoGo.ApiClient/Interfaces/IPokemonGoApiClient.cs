using PoGo.ApiClient.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoGo.ApiClient.Interfaces
{
    public interface IPokemonGoApiClient
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<PokemonData>> GetPokedexInventoryAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<PokemonData>> GetPokemonInventoryAsync();


    }
}
