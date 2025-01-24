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
            AddToCSVFile addToCSVFile = new AddToCSVFile();

            Console.Write("Input StyrkeNiveau ( 1-10 ): ");
            string PókemonStrykeNiveau = Console.ReadLine();
            bool ValidInput = false;
            while (!ValidInput)
            {
                if (double.TryParse(PókemonStrykeNiveau, out double AngivetPokémonstrykeNiveau))
                {
                    if (AngivetPokémonstrykeNiveau >= 1 && AngivetPokémonstrykeNiveau <= 10)
                    {

                        Console.WriteLine("Opretter Pokemon");
                        Pokemon pokemon = new Pokemon(AngivPokémonNavn, AngivPokémonType, AngivetPokémonstrykeNiveau);
                        _ContiuneProgram = true;
                        addToCSVFile.AddPokémonToCSV("Pokémon.csv", pokemon);
                    }
                }
                else
                {
                    Console.WriteLine("StrykeNiveauet du har angivet er ikke validt.");
                    _ContiuneProgram = false;
                }
            }

        }

    }
    public void RedigePokémon()
    {
        string JaNej;
        Console.WriteLine("Rediger Pokémon processe");

        // Step 1: Find Pokémonen ved ID eller navn
        Console.Write("Indtast Pokémon navn eller ID for at finde Pokémon: ");
        string input = Console.ReadLine();

        // Find Pokémonen i CSV-filen
        Pokemon existingPokemon = FindPokémonInCSV(input);

        if (existingPokemon == null)
        {
            Console.WriteLine("Pokémon blev ikke fundet.");
            return;
        }

        // Step 2: Rediger Pokémonen, hvis den findes
        Console.WriteLine($"Found Pokémon: {existingPokemon.Navn}, Type: {existingPokemon.Type}, StyrkeNiveau: {existingPokemon.StyrkeNiveau}");

        // Rediger navn, hvis ønsket
        Console.WriteLine("Vil du ændre Pokémon navn?");
        Console.Write("JA / NEJ: ");
        JaNej = Console.ReadLine().ToLower();
        if (JaNej == "ja")
        {
            Console.WriteLine("Indtast nyt navn: ");
            string nytNavn = Console.ReadLine();
            existingPokemon.Navn = nytNavn;
        }

        // Rediger type, hvis ønsket
        Console.WriteLine("Vil du ændre Pokémon Type?");
        Console.Write("JA / NEJ: ");
        JaNej = Console.ReadLine().ToLower();
        if (JaNej == "ja")
        {
            Console.WriteLine("Indtast ny type: ");
            string nyType = Console.ReadLine();
            existingPokemon.Type = nyType;
        }

        // Rediger styrkeniveau, hvis ønsket
        Console.WriteLine("Vil du ændre Pokémon styrkeniveau?");
        Console.Write("JA / NEJ: ");
        JaNej = Console.ReadLine().ToLower();
        if (JaNej == "ja")
        {
            Console.WriteLine("Indtast nyt styrkeniveau (0 - 10): ");
            string styrkeniveauInput = Console.ReadLine();
            bool validInput = false;
            while (!validInput)
            {
                if (double.TryParse(styrkeniveauInput, out double newStyrkeNiveau) && newStyrkeNiveau >= 1 && newStyrkeNiveau <= 10)
                {
                    existingPokemon.StyrkeNiveau = newStyrkeNiveau;
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Ugyldigt styrkeniveau. Indtast venligst et nummer mellem 1 og 10.");
                    styrkeniveauInput = Console.ReadLine();
                }
            }
        }

        // Step 3: Gem ændringerne tilbage i CSV-filen
        UpdatePokémonInCSV("Pokémon.csv", existingPokemon);

        Console.WriteLine("Pokémon blev succesfuldt ændret.");
    }

    public Pokemon FindPokémonInCSV(string searchInput)
    {
        string projectDirectory = Directory.GetCurrentDirectory();
        string folderPath = Path.Combine(projectDirectory, "CSV");
        string filePath = Path.Combine(folderPath, "Pokémon.csv");

        if (!File.Exists(filePath))
        {
            Console.WriteLine("CSV filen findes ikke.");
            return null;
        }

        List<Pokemon> pokemonList = new List<Pokemon>();

        // Læs filen og find Pokémonen
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            reader.ReadLine(); // Skip header
            while ((line = reader.ReadLine()) != null)
            {
                var data = line.Split(',');
                int id = int.Parse(data[0]);
                string navn = data[1];
                string type = data[2];
                double styrkeNiveau = double.Parse(data[3]);

                // Vi søger efter Pokémon ved navn eller ID
                if (navn.Equals(searchInput, StringComparison.OrdinalIgnoreCase) || id.ToString() == searchInput)
                {
                    return new Pokemon(navn, type, styrkeNiveau);
                }
            }
        }

        return null; // Hvis Pokémon ikke blev fundet
    }

    public void UpdatePokémonInCSV(string fileName, Pokemon updatedPokemon)
    {
        string projectDirectory = Directory.GetCurrentDirectory();
        string folderPath = Path.Combine(projectDirectory, "CSV");
        string filePath = Path.Combine(folderPath, fileName);

        List<Pokemon> pokemonList = new List<Pokemon>();
        bool updated = false;

        // Læs filen og opret en liste af Pokémon
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            reader.ReadLine(); // Skip header
            while ((line = reader.ReadLine()) != null)
            {
                var data = line.Split(',');
                int id = int.Parse(data[0]);
                string navn = data[1];
                string type = data[2];
                double styrkeNiveau = double.Parse(data[3]);

                // Hvis vi finder den Pokémon, vi skal opdatere, opdater den
                if (id == updatedPokemon.Id)
                {
                    pokemonList.Add(updatedPokemon);
                    updated = true;
                }
                else
                {
                    pokemonList.Add(new Pokemon(navn, type, styrkeNiveau));
                }
            }
        }

        // Skriv den opdaterede liste tilbage til filen
        using (StreamWriter writer = new StreamWriter(filePath, false)) // 'false' for at overskrive
        {
            writer.WriteLine("Id,Navn,Type,StyrkeNiveau"); // Header
            foreach (var pokemon in pokemonList)
            {
                writer.WriteLine($"{pokemon.Id},{pokemon.Navn},{pokemon.Type},{pokemon.StyrkeNiveau}");
            }
        }

        if (updated)
        {
            Console.WriteLine("Pokémon blev opdateret i CSV filen.");
        }
        else
        {
            Console.WriteLine("Pokémon blev ikke opdateret.");
        }
    }
    public void SletPokémon()
    {
        Console.WriteLine("Slet Pokémon processe");

        // Brugeren indtaster navn eller ID på den Pokémon, der skal slettes
        Console.Write("Indtast Pokémon navn eller ID for at slette Pokémon: ");
        string input = Console.ReadLine();

        // Find Pokémonen i CSV-filen
        Pokemon existingPokemon = FindPokémonInCSV(input);

        if (existingPokemon == null)
        {
            Console.WriteLine("Pokémon blev ikke fundet.");
            return;
        }

        // Bekræftelse før sletning
        Console.WriteLine($"Er du sikker på, at du vil slette Pokémon: {existingPokemon.Navn}?");
        Console.Write("JA / NEJ: ");
        string confirmation = Console.ReadLine().ToLower();

        if (confirmation == "ja")
        {
            // Slet Pokémonen fra CSV-filen
            RemovePokémonFromCSV("Pokémon.csv", existingPokemon);
            Console.WriteLine($"Pokémon {existingPokemon.Navn} blev slettet.");
        }
        else
        {
            Console.WriteLine("Sletning annulleret.");
        }
    }

    public void RemovePokémonFromCSV(string fileName, Pokemon pokemonToDelete)
    {
        string projectDirectory = Directory.GetCurrentDirectory();
        string folderPath = Path.Combine(projectDirectory, "CSV");
        string filePath = Path.Combine(folderPath, fileName);

        List<Pokemon> pokemonList = new List<Pokemon>();

        // Læs filen og opret en liste af Pokémon uden den, der skal slettes
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            reader.ReadLine(); // Skip header
            while ((line = reader.ReadLine()) != null)
            {
                var data = line.Split(',');
                int id = int.Parse(data[0]);
                string navn = data[1];
                string type = data[2];
                double styrkeNiveau = double.Parse(data[3]);

                // Hvis Pokémonens ID eller navn matcher, spring den over
                if (pokemonToDelete.Id != id)
                {
                    pokemonList.Add(new Pokemon(navn, type, styrkeNiveau));
                }
            }
        }

        // Skriv den opdaterede liste tilbage til filen
        using (StreamWriter writer = new StreamWriter(filePath, false)) // 'false' for at overskrive
        {
            writer.WriteLine("Id,Navn,Type,StyrkeNiveau"); // Header
            foreach (var pokemon in pokemonList)
            {
                writer.WriteLine($"{pokemon.Id},{pokemon.Navn},{pokemon.Type},{pokemon.StyrkeNiveau}");
            }
        }
    }

    public List<Pokemon> GetAllPokémonFromCSV(string fileName)
    {
        string projectDirectory = Directory.GetCurrentDirectory();
        string folderPath = Path.Combine(projectDirectory, "CSV");
        string filePath = Path.Combine(folderPath, fileName);

        List<Pokemon> pokemonList = new List<Pokemon>();

        // Læs Pokémon data fra filen
        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                reader.ReadLine(); // Skip header
                while ((line = reader.ReadLine()) != null)
                {
                    var data = line.Split(',');
                    int id = int.Parse(data[0]);
                    string navn = data[1];
                    string type = data[2];
                    double styrkeNiveau = double.Parse(data[3]);

                    pokemonList.Add(new Pokemon(navn, type, styrkeNiveau));
                }
            }
        }
        else
        {
            Console.WriteLine("CSV filen findes ikke.");
        }

        return pokemonList;
    }

    public void SøgningAfPokémon()
    {
        Console.WriteLine("Søgning af (Pokémon)");

        // Brugeren indtaster et navn eller ID på Pokémon
        Console.Write("Indtast Pokémon navn eller ID for at søge: ");
        string input = Console.ReadLine();

        // Find Pokémonen i CSV-filen
        Pokemon foundPokemon = FindPokémonInCSV(input);

        if (foundPokemon == null)
        {
            Console.WriteLine("Pokémon blev ikke fundet.");
        }
        else
        {
            // Vis den fundne Pokémon
            Console.WriteLine($"Pokémon fundet: ID: {foundPokemon.Id}, Navn: {foundPokemon.Navn}, Type: {foundPokemon.Type}, StyrkeNiveau: {foundPokemon.StyrkeNiveau}");
        }
    }

}




