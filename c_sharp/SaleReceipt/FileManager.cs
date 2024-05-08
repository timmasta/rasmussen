using SalesReceipt;
using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

public class FileManager
{
    public FileManager()
    {
        Console.WriteLine("File Manager Class Instantiated");
    }
    public static string csvFile = "sales-records.csv";//file is local in the project directory
    public static bool CheckForFile()
    {
        // Check if the CSV file exists, create it if it doesn't
        if (!File.Exists(csvFile))
        {
            // Create the CSV file with headers
            using StreamWriter writer = new(csvFile);
            writer.WriteLine("Name, Phone, Street Address, Email");
            Console.WriteLine("File Created!");
            return true;
        }
        else if (File.Exists(csvFile))
        {
            Console.WriteLine("Save File Found");
            return true;
        }
        else
        {
            Console.WriteLine("An error occurred finding or creating the file");
            return false;
        }
    }

    public static void SaveNewCustomer(Customer newCustomer)
    {
        try
        {
            Console.WriteLine("Saving Customer info to file.");

            // Read all lines from the CSV file
            List<string> lines = new List<string>();
            using (StreamReader reader = new StreamReader(csvFile))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            // Find the first empty row
            int emptyRowIndex = -1;
            for (int i = 0; i < lines.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                {
                    emptyRowIndex = i;
                    break;
                }
            }

            // Append new customer information to the first empty row, or add as a new line if no empty row found
            if (emptyRowIndex != -1)
            {
                lines[emptyRowIndex] = $"{newCustomer.FirstName}, {newCustomer.LastName}, {newCustomer.StAddress}, {newCustomer.Email}, {newCustomer.ItemsTotal.ToString("F2")}";
            }
            else
            {
                lines.Add($"{newCustomer.FirstName}, {newCustomer.LastName}, {newCustomer.StAddress}, {newCustomer.Email}");
            }

            // Write all lines back to the CSV file
            using (StreamWriter writer = new StreamWriter(csvFile))
            {
                foreach (string line in lines)
                {
                    writer.WriteLine(line);
                }
            }
        }
        catch
        {
            Console.WriteLine("Error saving Customer info to file.");
        }
    }

    public static bool FindCustomer(string name)
    {
        try
        {
            using (StreamReader reader = new StreamReader(csvFile))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains(name))
                    {
                        return true;
                    }
                }
                return false;//name was not found
            }
        }
        catch
        {
            Console.WriteLine("An error occurred trying to read the csv file");
            return false;
        }

    }
    public static void RemoveCustomer(string name)
    {
        try
        {
            // Read all lines from the CSV file
            List<string> lines = new List<string>();
            using (StreamReader reader = new StreamReader(csvFile))
            {
                string? line;
                int rowCount = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    // Skip the header row
                    if (rowCount == 0)
                    {
                        lines.Add(line); // Add header row
                    }
                    else if (!line.Contains(name)) // If the line does not contain the name, keep it
                    {
                        lines.Add(line);
                    }
                    rowCount++;
                }
            }

            // Remove empty rows
            lines = lines.Where(line => !string.IsNullOrWhiteSpace(line)).ToList();

            // Write all lines back to the CSV file
            using (StreamWriter writer = new StreamWriter(csvFile))
            {
                foreach (string currentLine in lines)
                {
                    writer.WriteLine(currentLine);
                }
            }
        }
        catch
        {
            Console.WriteLine("Error removing customer entry.");
        }
    }

    public static void DisplayFileContents()
    {
        try
        {
            // Read all lines from the CSV file
            using (StreamReader reader = new StreamReader(csvFile))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
        }
    }
}
