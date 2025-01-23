using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PokemonApp.Models;

namespace PokemonApp.Backend;

public class BrugerOprettelse
{
    public User CreateUser()
    {
        Console.Write("Input BrugerNavn: ");
        string BrugerNavn = Console.ReadLine();
        
        Console.Write("Input Adgangskode: ");
        string Adgangskode = Console.ReadLine();

        Console.WriteLine("Bruger er oprettet");
        return new User(BrugerNavn, Adgangskode);
    
    }
}
