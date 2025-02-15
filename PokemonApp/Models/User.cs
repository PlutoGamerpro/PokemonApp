using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonApp.Models;

public class User
{
    public int Id { get; set; }
    public static int  NextId = 1;
    public string Navn { get; set; }
    public string Adgangskode { get; set; }
    public string Salt { get; set; }

    public User(string navn, string adgangskode, string salt){
        Id = NextId++;
        Navn = navn;
        Adgangskode = adgangskode;
        Salt = salt;
    }
}
