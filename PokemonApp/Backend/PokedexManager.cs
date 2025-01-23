using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonApp.Backend;

public class PokedexManager : ICRUDPokémon
{

    public void TilføjPokémon()
    {
        Console.WriteLine("Oprettelse af Pokémon: ");

        Console.Write("Input Pokémon Navn (Pikatu, osv): ");
        string AngivPokémonNavn = Console.ReadLine();

        Console.Write("Input Pokémon Type (Ild,Vand,Elektrik, osv): ");
        string AngivPokémonType = Console.ReadLine();

        Console.Write("Input StyrkeNiveau ( 1-10 ): ");
        string AngivPókemonStrykeNiveau = Console.ReadLine();

    }
    public void RedigePokémon()
    {
        Console.WriteLine("Rediger Pokémon processe");


    }
    public void SletPokémon()
    {
        Console.WriteLine("Slet Pokémon processe");


    }
    public void VisingAfPokémon() // kræver ikke login (rimlig sikker på det)
    {
        Console.WriteLine("Visning af (Pokémon)");

    }
    public void SøgningAfPokémon() {
        Console.WriteLine("Søgning af (Pokëmon)");
    }

   




