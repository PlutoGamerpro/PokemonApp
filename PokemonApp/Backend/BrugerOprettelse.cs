using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PokemonApp.Models;

namespace PokemonApp.Backend;

public class BrugerOprettelse
{
    public void CreateUser() /// returing af object not worth it...
    {
        Console.Write("Input BrugerNavn: ");
        string BrugerNavn = Console.ReadLine();

        Console.Write("Input Adgangskode: ");
        string Adgangskode = Console.ReadLine();

        User user = new User(BrugerNavn, Adgangskode);
        Console.WriteLine("BrugerOprettet");

        AddToCSVFile addToCSVFile = new AddToCSVFile();
        addToCSVFile.AddUserToCSV("Users.csv", user);

        Console.WriteLine("Userscreated");

    }
}
