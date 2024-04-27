using System;

class Program
{
    //array of values that correlate with expense names
    static double[] expenses = new double[4];
    //array of expense names for display to the user
    static string[] expenseNames = { "merchandise", "employee salary", "store rent", "electricity cost" };
    const double minProfitMargin = .2;

    static void Main(string[] args)
    {
        DisplayWelcomeMessage();
        GetExpenses();
        CalculatePricePoint();
    }

    static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to Jessie's Computer shop's cost analyzer.");
        Console.WriteLine("");
        Console.WriteLine("You will be asked to enter the annual expenses for the shop");
        Console.WriteLine("All costs are factored in to determine the correct product price point.");
        Console.WriteLine("");
    }

    static void GetExpenses()
    {
        string userInput;

        for (int i = 0; i < expenses.Length; i++)
        {
            Console.WriteLine("");
            Console.WriteLine($"Enter the annual {expenseNames[i]} expense:");
            userInput = Console.ReadLine();

            if (userInput != null && double.TryParse(userInput, out expenses[i]))
            {
                Console.WriteLine($"{expenseNames[i]} cost of {userInput} accepted");
            }
            else
            {
                HandleInvalidEntry();
                i--; // To re-prompt for the same expense
            }
        }
    }

    static void CalculatePricePoint()
    {
        double totalExpenses = 0;
        foreach (double expense in expenses)
        {
            totalExpenses += expense;
        }

        if (totalExpenses > 0)
        {
            double pricePoint = ((totalExpenses / (1 - minProfitMargin)) / 5200);
            string formattedPricePoint = pricePoint.ToString("F2");
            Console.WriteLine("");
            Console.WriteLine($"The price of a PC to maintain a {(minProfitMargin * 100):F2}% margin is: ${formattedPricePoint}");
            Console.WriteLine("");
        }
        else
        {
            Console.WriteLine("No valid expenses entered.");
        }
    }

    static void HandleInvalidEntry()
    {
        Console.WriteLine("Invalid entry - only numbers are accepted");
    }
}
