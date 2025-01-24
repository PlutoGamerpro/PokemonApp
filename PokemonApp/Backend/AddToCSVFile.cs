using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualBasic;
using PokemonApp.Models;

namespace PokemonApp.Backend;

public class AddToCSVFile
{


    public void CreateCsvFile(string fileName) /// method to create file....
    {
        try
        {
            // Get the directory of the current executable (your project directory)
            string projectDirectory = Directory.GetCurrentDirectory();
            string folderPath = Path.Combine(projectDirectory, "CSV");

            // Check if the folder exists, if not, create it
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
                Console.WriteLine("CSV folder created.");
            }

            // Combine folder path with the file name
            string filePath = Path.Combine(folderPath, fileName);

            // Create or open the file
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Write the header (first line with column names)
                writer.WriteLine("Username,Password");

                // Write some example data
                writer.WriteLine("user1,password1");
                writer.WriteLine("user2,password2");
                writer.WriteLine("user3,password3");

                // Success message after file creation
                Console.WriteLine($"File created successfully at {filePath}");
            }
        }
        catch (Exception ex)
        {
            // Handle errors (e.g., file path issues, access issues)
            Console.WriteLine($"Failed to create the file. Error: {ex.Message}");
        }
    }


    public void AddPokémonToCSV(string fileName, Pokemon tilføjPokémon)
    {
        try
        {
            // Get the directory of the current executable (your project directory)
            string projectDirectory = Directory.GetCurrentDirectory();
            string folderPath = Path.Combine(projectDirectory, "CSV");

            // Combine folder path with the file name
            string filePath = Path.Combine(folderPath, fileName);

            // Log the file path for clarity
            Console.WriteLine($"Working with file: {filePath}");

            // Check if the file exists, if not, create it and add headers
            if (!File.Exists(filePath))
            {
                using (StreamWriter writer = new StreamWriter(filePath, false))  // false to overwrite
                {
                    // Write the header with consistent formatting
                    writer.WriteLine("Id,Name,Type,StyrkeNiveau");
                }
            }

            // Append the Pokémon data to the file without extra spaces
            using (StreamWriter writer = new StreamWriter(filePath, true))  // true to append
            {
                writer.WriteLine($"{tilføjPokémon.Id},{tilføjPokémon.Navn},{tilføjPokémon.Type},{tilføjPokémon.StyrkeNiveau}");
            }

            Console.WriteLine($"Pokemon {tilføjPokémon.Navn} ({tilføjPokémon.Id}) added to CSV.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to add Pokémon to the file. Error: {ex.Message}");
        }
    }
    public void AddUserToCSV(string fileName, User TilføjBruger)
    {
        try
        {
            // Get the directory of the current executable (your project directory)
            string projectDirectory = Directory.GetCurrentDirectory();
            string folderPath = Path.Combine(projectDirectory, "CSV");

            // Combine folder path with the file name
            string filePath = Path.Combine(folderPath, fileName);

            // Log the file path for clarity
            Console.WriteLine($"Working with file: {filePath}");

            // Check if the file exists, if not, create it and add headers
            if (!File.Exists(filePath))
            {
                using (StreamWriter writer = new StreamWriter(filePath, false))  // false to overwrite
                {
                    // Write the header based on User properties
                    writer.WriteLine("Id,Navn,Adgangskode");
                }
            }

            // Write the User data on the same line with appropriate spacing
            using (StreamWriter writer = new StreamWriter(filePath, true))  // true to append
            {
                writer.WriteLine($"{TilføjBruger.Id},{TilføjBruger.Navn},{TilføjBruger.Adgangskode}");
            }

            Console.WriteLine($"User {TilføjBruger.Id}, {TilføjBruger.Navn} added to CSV.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to add user to the file. Error: {ex.Message}");
        }
    }
}
