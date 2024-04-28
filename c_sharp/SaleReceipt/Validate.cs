using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SalesReceipt
{
    public class Validate
    {
        public static string GetAndValidateNumber()
        {
            string? phoneNumber;
            string phoneNumberNoDashes;
            string phoneNumberRegex = @"^\d{10}$";
            bool isValidPhoneNumber;
            while (true)
            {
                Console.WriteLine("Enter your phone number: ");
                phoneNumber = Console.ReadLine();
                if (phoneNumber != null)
                {
                    phoneNumberNoDashes = Regex.Replace(phoneNumber, @"[- ]", "");
                    isValidPhoneNumber = Regex.IsMatch(phoneNumber, phoneNumberRegex);
                    if (isValidPhoneNumber)
                    {
                        string formattedPhoneNumber = Regex.Replace(phoneNumberNoDashes, @"(\d{3})(\d{3})(\d{4})", "$1-$2-$3");
                        return formattedPhoneNumber;
                    }
                    else
                    {
                        Console.WriteLine("Invalid phone number. Please enter 10 digits (with or without dashes).");
                    }
                }
                else
                {
                    Console.WriteLine("No Phone Number Entered. Please entered 10 digits (with or without dashes).");
                }
            }
        }

        public static string ValidateEnteredString(string message)
        {
            string? userInput;
            while (true)
            {
                Console.WriteLine($"{message}");
                userInput = Console.ReadLine();
                if (userInput != null && userInput != "")
                {
                    return userInput;
                }
                else
                {
                    Console.WriteLine("No Input detected. Please enter a valid string.");
                }
            }


        }

        public static string GetAndValidateEmail()
        {
            string? emailEntered;
            string emailRegex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            bool isValidEmail;
            while (true)
            {
                Console.WriteLine("Enter your email address: ");
                emailEntered = Console.ReadLine();
                if (emailEntered != null)
                {
                    isValidEmail = Regex.IsMatch(emailEntered, emailRegex);
                    if (isValidEmail)
                    {
                        return emailEntered;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Email Format. Enter the exact email address");
                    }
                }
                else
                {
                    Console.WriteLine("No Email Entered. Please enter a valid email address.");
                }
            }
        }
    }
}
