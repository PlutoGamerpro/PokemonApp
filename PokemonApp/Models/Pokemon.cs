using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonApp.Models;

public class Pokemon
{
    public int Id { get; set; }
    public static int NextId = 1;
    public string Navn { get; set; }
    public string Type { get; set; }
    public double StyrkeNiveau { get; set; }

    public Pokemon(string navn, string type, double styrkeNiveau)
    {
        Id = NextId++;
        Navn = navn;
        Type = type;
        StyrkeNiveau = styrkeNiveau;
    }

}
