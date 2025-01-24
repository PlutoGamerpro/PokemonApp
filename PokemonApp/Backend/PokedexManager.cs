using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PokemonApp.Models;

namespace PokemonApp.Backend;

public class PokedexManager : ICRUDPokémon
{
    private bool _ContiuneProgram = false;

    public void TilføjPokémon()
    {
        Console.WriteLine("Oprettelse af Pokémon: ");

        Console.Write("Input Pokémon Navn (Pikatu, osv): ");
        string AngivPokémonNavn = Console.ReadLine();

        Console.Write("Input Pokémon Type (Ild,Vand,Elektrik, osv): ");
        string AngivPokémonType = Console.ReadLine();


        while (!_ContiuneProgram)
        {

            Console.Write("Input StyrkeNiveau ( 1-10 ): ");
            string PókemonStrykeNiveau = Console.ReadLine();

            if (double.TryParse(PókemonStrykeNiveau, out double AngivetPokémonstrykeNiveau))
            {
                Console.WriteLine("Opretter Pokemon");
                Pokemon pokemon = new Pokemon(AngivPokémonNavn, AngivPokémonType, AngivetPokémonstrykeNiveau);
                _ContiuneProgram = true;
            }
            else
            {
                Console.WriteLine("StrykeNiveauet du har angivet er ikke validt.");
                _ContiuneProgram = false;
            }

        }

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
    public void SøgningAfPokémon()
    {
        Console.WriteLine("Søgning af (Pokëmon)");
    }

}




