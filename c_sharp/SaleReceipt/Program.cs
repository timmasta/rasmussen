using System.Text.RegularExpressions;
namespace SalesReceipt
{
    namespace SalesReceipt
    {
        class Program
        {
            //4% fixed tax rate
            const double taxRate = .04;
            static double[] items = new double[5];
            static string[] productNames = { "Black Dirt", "Wood Mulch", "Rubber Mulch", "Pea Rock", "River Rock" };
            static double[] productPrices = { 10.0, 20.0, 30.0, 35.0, 40.0 };




            static void Main(string[] args)
            {
                PrintGreeting();
                FileManager.CheckForFile();
                Customer customer = new();

                bool exitLoop = false;
                string? userInput;
                int userChoice;
                while (!exitLoop)
                {
                    PrintOptions();
                    userInput = Console.ReadLine();
                    if(userInput != null && int.TryParse(userInput, out userChoice))
                    {
                        switch (userChoice)
                        {
                            case 1://add new
                                AddCustomerRecord(customer);
                                FileManager.SaveNewCustomer(customer);
                                break;
                            case 2://edit customer (if it is found)
                                Console.WriteLine("Enter a name to search for");
                                string? searchName = Console.ReadLine();
                                if(searchName != null)
                                {
                                    if (FileManager.FindCustomer(searchName))
                                    {
                                        Console.WriteLine($"{searchName} was found and deleted, enter new customer info:");
                                        FileManager.RemoveCustomer(searchName);
                                        AddCustomerRecord(customer);
                                        FileManager.SaveNewCustomer(customer);
                                    }
                                    else
                                    {
                                        Console.WriteLine($"{searchName} was not found, please enter as a new customer.");
                                    }
                                }                                
                                break;
                            case 3://prompt the user to enter items, then output the receipt to the screen                                
                                customer.ItemsTotal = EnterItems();
                                OutputCustomerInfo(customer);
                                //save the data to the csv file
                                FileManager.SaveNewCustomer(customer);                                
                                double taxAmount = CalculateTax(customer.ItemsTotal);
                                OutputSalesReceipt(customer, taxAmount);//calculates the tax, sub-total, and total and displays them
                                exitLoop = true;
                                break;
                            case 4:
                                exitLoop = true;//exit program loop
                                break;
                            default:
                                Console.WriteLine("Please enter a valid option (1-4).");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter numbers only to select your option.");
                    }//end of user input
                }//end of while loop that gets user choices
            }//end of main()

            //end of main loop and beginning of functions
            static void PrintGreeting()
            {
                Console.WriteLine("Welcome to the Sales Receipt Application!");
                Console.WriteLine("");
                Console.WriteLine("You will have the options to add or edit customers,");
                Console.WriteLine("or select 'Enter Sale' to enter the items purchased and see a receipt.");
                Console.WriteLine("All customer information is stored in 'sales-records.csv'.");
                Console.WriteLine("");
            }

            static void PrintOptions()
            {
                Console.WriteLine("Enter an option below:");
                Console.WriteLine("======================");
                Console.WriteLine("(1)-Enter a new customer");
                Console.WriteLine("(2)-Edit and existing customer");
                Console.WriteLine("(3)-Enter a sale and generate a receipt");
                Console.WriteLine("(4)-Exit");
                Console.WriteLine("");
            }

            static double CalculateTax(double subtotal)
            {
                double tax;
                tax = taxRate * subtotal;
                return tax;
            }

            

            static Customer AddCustomerRecord(Customer newCustomer)
            {
                    newCustomer.FirstName = Validate.ValidateEnteredString("Enter your first name: ");//any string is acceptable, this function just validates something was entered
                newCustomer.LastName = Validate.ValidateEnteredString("Enter your last name: ");
                newCustomer.Phone = Validate.GetAndValidateNumber();//loops and makes sure phone number is 10 digits before continuing
                newCustomer.Email = Validate.GetAndValidateEmail();//loops to check email address format before continuing       
                newCustomer.StAddress = Validate.ValidateEnteredString("Enter your street address: ");
                
                return newCustomer;
            }

            static double EnterItems()
            {
                double itemTotalCost = 0;
                // Display available products
                Console.WriteLine("Available Products:");
                for (int i = 0; i < productNames.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {productNames[i]} - ${productPrices[i]}");
                }

                // Loop 5 times for the items the customer purchased
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"Enter the index of item #{i + 1}:");
                    string? userInput = Console.ReadLine();
                    if (int.TryParse(userInput, out int itemIndex) && itemIndex >= 1 && itemIndex <= productNames.Length)//validates input can be parsed and the index is in range
                    {
                        //index is valid, so we add the indexed value to the total
                        itemTotalCost += productPrices[itemIndex - 1];
                        items[i] = productPrices[itemIndex - 1];
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid index.");
                        i--; // Decrement i to repeat the current iteration
                    }
                }
                return itemTotalCost;
            }
            private static void OutputCustomerInfo(Customer customer)
            {
                Console.WriteLine("Customer Information");
                Console.WriteLine("========================");
                Console.WriteLine("Name: " + customer.FirstName + ":" + customer.LastName);
                Console.WriteLine("Phone: " + customer.Phone);
                Console.WriteLine("Address: " + customer.StAddress);
                Console.WriteLine("Email: " + customer.Email);
                Console.WriteLine("");
            }

            private static void OutputSalesReceipt(Customer customer, double taxTotal)
            {
                Console.WriteLine("Sales Receipt");
                Console.WriteLine("=============");
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Item #" + i.ToString() + ": " + items[i]);
                }
                Console.WriteLine("Items Subtotal: $" + customer.ItemsTotal.ToString("F2"));
                Console.WriteLine("Tax Amount: $" + taxTotal.ToString("F2"));
                Console.WriteLine("Items Total Cost: $" + (customer.ItemsTotal + taxTotal).ToString("F2"));
            }
        }

        

    }
}
