using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonApp;

public interface ICRUDPokémon
{
    public void TilføjPokémon(){}
    public void RedigérPokémon(){}
    public void SletPokémon(){}
    public void VisingAfPokémon(){}
    public void SøgningAfPokémon(){}

}
