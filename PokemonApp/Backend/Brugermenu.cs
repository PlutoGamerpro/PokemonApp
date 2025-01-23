namespace PokemonApp.Backend
{
    public class Brugermenu
    {
        BrugerLogin brugerLogin = new BrugerLogin();
        // Class content goes here if needed.
        public void DisplayUserMenu()
        {
            // if user don't exist then have to create
            Console.WriteLine("1. OpretUser");
            Console.WriteLine("2. Log ind");
            Console.WriteLine("3. Se alle Pokémon");
            Console.WriteLine("4. Søg efter Pokémon");
            Console.WriteLine("5. Afslut");
            // These function you don't need to be logged in.

            OperationManager(); 
        }
        public void OperationManager(){
            string BrugerInput = Console.ReadLine();
            switch(BrugerInput){
                case "1": Console.WriteLine("OpretBruger"); break;
                case "2": Console.WriteLine("Login ind"); break;
                case "3": Console.WriteLine("Se alle Pokémon"); break;
                case "4": Console.WriteLine("SearchFunction"); break;
                case "5": Console.WriteLine("Afslut Program"); Environment.Exit(0); break;

                default: Console.WriteLine("Vælg en af overstående muligheder"); break;
            }

        }
       
    }
}
