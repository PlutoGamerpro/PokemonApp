using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace PokemonApp.Backend
{
    public class Brugermenu
    {
        BrugerLogin brugerLogin = new BrugerLogin();
        BrugerOprettelse brugerOprettelse = new BrugerOprettelse();
        PokedexManager pokedexManager = new PokedexManager();
        // Class content goes here if needed.
        public void DisplayUserMenu()
        {
            // if user don't exist then have to create
            Console.WriteLine("Menu Pokemon Userapp");
            Console.WriteLine("1. Opret bruger");
            Console.WriteLine("2. Log ind");
            Console.WriteLine("3. Se alle Pokémon");
            Console.WriteLine("4. Søg efter Pokémon");
            Console.WriteLine("5. Afslut");
            Console.Write("Vælg Mulighed 1,2,3,4,5 : ");
            // These function you don't need to be logged in.

        }
        public void OperationManager()
        {
            
            while (true)
            { // program on loop-- never need to be false... 
                DisplayUserMenu();
                // if userenter one of the options below then exits the loop 
                string BrugerInput = Console.ReadLine();
                switch (BrugerInput)
                {
                    case "1": brugerOprettelse.CreateUser(); Console.WriteLine("OpretBruger"); break;
                    case "2": brugerLogin.CheckLoginInfo(); Console.WriteLine("Login ind"); break;
                    case "3": Console.WriteLine("Se alle Pokémon"); break;
                    case "4": Console.WriteLine("Søg efter Pokémon"); break;
                    case "5": Console.WriteLine("Afslutet Program"); Environment.Exit(0); break;

                    default: Console.WriteLine("Vælg en af overstående muligheder"); break;

                }
            }

        }

        public void DisplayPokémonMuligheder()
        {
            Console.WriteLine("1: Oprettelse af Pokémon");
            Console.WriteLine("2: Redigering af Pokémon");
            Console.WriteLine("3: Sletting af Pokémon");
            Console.WriteLine("4: VisingAfPokémon");
            Console.WriteLine("5: SøgningAfPokémon");
            Console.WriteLine("6: Tilbage til Startmenu");
            Console.WriteLine("7: Afslut programmet");

            Console.Write("Vælg Mulighed 1,2,3,4,5,6,7 : ");
        }





        

        public void PokéMonOperations()
        { // add functions from pokémonmanger to each case so the becomes better ......
            Brugermenu brugermenu = new Brugermenu();

            while (true)
            {
                DisplayPokémonMuligheder();
                string BrugerInput = Console.ReadLine();
                switch (BrugerInput)
                {
                    case "1": pokedexManager.TilføjPokémon(); Console.WriteLine("Oprettelse af Pokémon"); break;
                    case "2": pokedexManager.RedigePokémon(); Console.WriteLine("Redigering af Pokémon"); break;
                    case "3": pokedexManager.SletPokémon(); Console.WriteLine("Sletting af Pokémon"); break;
                    case "4": pokedexManager.GetAllPokémonFromCSV("Pokémon.csv"); Console.WriteLine("Vising af Pokémons"); break;
                    case "5": pokedexManager.SøgningAfPokémon(); Console.WriteLine("Søgning af Pokémon"); break;
                    case "6": brugermenu.OperationManager(); Console.WriteLine("Tilbage til Startmenu"); break;
                    case "7": Environment.Exit(0); break;
                    default: Console.WriteLine("None of the options above was selected"); break;
                }
            }
        }
        

    }

}

