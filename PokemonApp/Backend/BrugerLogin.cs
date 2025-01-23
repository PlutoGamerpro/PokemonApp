using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PokemonApp.Interfaces;

namespace PokemonApp.Backend;

public class BrugerLogin : IBrugerLogin
{
    public void CheckLoginInfo() {
        Console.WriteLine("Log in processe");

        Console.Write("Input Brugernavn: ");
        string DitBrugerNavn = Console.ReadLine();

        Console.Write("Input Adgangskode: ");
        string DitPassword = Console.ReadLine();

        CheckIfUserExist(DitBrugerNavn, DitPassword);

    }
    // This is not finished still need to be finished. 
    public bool CheckIfUserExist(string DitBrugerNavn, string DitPassword)
     {
        // filen csv skal læses for at kunne lave denne logic
        if (DitBrugerNavn.Length == 5 && DitPassword.Length == 5)
        {
            return true;
        }
        else
        { 
            return false; 
        }
       
   
        

     }
}
