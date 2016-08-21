using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoGo.ApiClient.Wrappers
{
    public class PokemonData
    {

        public string Name { get; set; }

        public PokemonData(string name)
        {
            Name = name;
        }

    }

}