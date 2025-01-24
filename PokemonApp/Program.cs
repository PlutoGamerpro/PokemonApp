using System;
using PokemonApp.Backend;

namespace PokemonApp.Models
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AddToCSVFile addToCSVFile = new AddToCSVFile();
            BrugerOprettelse brugerOprettelse = new BrugerOprettelse();

           // brugerOprettelse.CreateUser();
            BrugerLogin brugerLogin = new BrugerLogin();

            brugerLogin.CheckLoginInfo();

            /* Brugermenu brugermenu = new Brugermenu();
             brugermenu.OperationManager();
            */

            // example on how its works
            /*
            User newUser = new User("John Doe", "password123");// id is not included 
            addToCSVFile.AddUserToCSV("Users.csv", "John Doe", newUser);


            Pokemon pikachu = new Pokemon("Pikachu", "Electric", 10);
            addToCSVFile.AddPokémonToCSV("Pokemons.csv", pikachu);
            */
        }
    }
}
