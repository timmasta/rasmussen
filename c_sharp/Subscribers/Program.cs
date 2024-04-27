
class Program
{
    //4% fixed tax rate
    const double taxRate = .04;
    static int months;
    static void Main(string[] args)
    {        
        //array for subscription types, 12-15-17 per month
        string[] subscriptionTypes = ["Ice Cream", "Bacon", "Peanut Butters"];
        //array for shipping type, 5-10-30 dollars
        string[] shippingPriority = ["Regular", "Expedited", "Overnight"];
        bool quitMainLoop = false;
        bool quitSubLoop = false;
        bool quitShippingLoop;
        bool firstEntryValid = false;
        



        //display the welcome message
        printGreeting();

        Customer customer = new()
        {
            SubscriptionCount = 0,
            SubscriptionTotal = 0
        };

        while (!quitMainLoop)//get customer information
        {
            string userInput;
            //int months;
            setCustomerName();
            printCustomerName();
            while (!quitSubLoop)//get order information
            {
                quitShippingLoop = false;//initialize here in case this is not the first time in the loop                
                Print("Enter an option for the subscription type:");
                for (int i = 0; i < subscriptionTypes.Length; i++)
                {
                    Print((i + 1).ToString() + ": " + subscriptionTypes[i]);
                }
                userInput = Console.ReadLine();
                if (userInput == "1")
                {
                    months = getSubscriptionLength();
                    customer.SubscriptionTotal += 12 * months;
                    firstEntryValid = true;
                }
                else if (userInput == "2")
                {
                    months = getSubscriptionLength();
                    customer.SubscriptionTotal += 15 * months;
                    firstEntryValid = true;
                }
                else if (userInput == "3")
                {
                    months = getSubscriptionLength();
                    customer.SubscriptionTotal += 17 * months;
                    firstEntryValid = true;
                }
                else if (userInput == "q" || userInput == "Q")
                {
                    Print("Exiting.....");
                    quitSubLoop = true;
                    quitMainLoop = true;                    
                }
                else
                {
                    Print("Please enter a valid option (1-3)");
                }
                if (firstEntryValid)//subscription entry successful, next we get the shipping type
                {
                    while (!quitShippingLoop)
                    {
                        
                        Print("Enter the shipping type from the options below:");
                        for (int i = 0; i < shippingPriority.Length; i++)
                        {
                            Print((i + 1).ToString() + ": " + shippingPriority[i]);
                        }
                        userInput = Console.ReadLine();
                        if (userInput == "1")
                        {                            
                            customer.SubscriptionTotal += 5 * months;
                            customer.SubscriptionCount += 1;
                            quitShippingLoop = true;
                        }
                        else if (userInput == "2")
                        {
                            customer.SubscriptionTotal += 10 * months;
                            customer.SubscriptionCount += 1;
                            quitShippingLoop = true;
                        }
                        else if (userInput == "3")
                        {
                            customer.SubscriptionTotal += 30 * months;
                            customer.SubscriptionCount += 1;

                            quitShippingLoop = true;
                        }
                        else
                        {
                            Print("Please enter a valid option (1-3)");
                        }
                    }//end of shipping loop
                }
                if (!quitMainLoop)//if user quits with 'q' this is skipped
                {
                    Print("Do you want to add another subscription? (y/n)");
                    userInput = Console.ReadLine();
                    if (userInput != null && userInput != "y" && userInput != "Y")//anything but a 'y' exits the loop and prints customer information
                    {
                        quitSubLoop = true;
                        quitMainLoop = true;
                    }
                    else
                    {
                        firstEntryValid = false;//reinitialize to start the sub loops again
                    }
                }
                
            }//end of subLoop
        }//end of mainLoop


        //get tax rate, totals, and discount
        double discountedTotal = getDiscountRate(customer.SubscriptionTotal);
        double taxTotal = CalculateTax(discountedTotal);
        double taxedTotal = discountedTotal + taxTotal;
        
        Print("You have enrolled in " + customer.SubscriptionCount + " subcriptions.");
        Print("Total for subscriptions is: $" + customer.SubscriptionTotal.ToString("F2"));
        Print("The tax total is: $" + taxTotal.ToString("F2"));
        Print("The total with tax is: $" + taxedTotal.ToString("F2"));
        Print("Final Discounted Total is: $" + taxedTotal.ToString("F2") + " You saved $" + (customer.SubscriptionTotal - discountedTotal).ToString("F2"));


        void Print(string message)
        {
            Console.WriteLine(message);
        }

        static double CalculateTax(double subtotal)
        {
            double tax;
            tax = taxRate * subtotal;
            return tax;
        }

        void setCustomerName()
        {
            //get the first and last name, trimming whitespace to avoid unexpected behavior with spaces
            Print("Enter your first name: ");
            customer.FirstName = Console.ReadLine()?.Trim();

            Print("Enter your last name: ");
            customer.LastName = Console.ReadLine()?.Trim();
        }

        void printCustomerName()
        {
            Print(customer.FirstName + " " + customer.LastName);
        }

        void printGreeting()
        {
            Print("Welcome to the Subscribers program.");
            Print("You will be asked to enter the subscriber's first and last name.");
            Print("You can then enter as many orders as you like for that subscriber.");
            Print("Enter 'Q' to exit the program.");
        }

        double getDiscountRate(double totalWithTax)
        {
            //>50 = 5%, >100 = 7%, >150 = 10%
            double discountRate = 0;
            if (totalWithTax > 150)
            {
                discountRate = .1;
            }
            else if (totalWithTax > 100)
            {
                discountRate = .07;
            }
            else if (totalWithTax > 50)
            {
                discountRate = .05;
            }
            totalWithTax *= (1 - discountRate);
            return totalWithTax;
        }

        int getSubscriptionLength()
        {
            Print("Enter the number of months for the subscription: ");
            string userInput = Console.ReadLine();
            if (int.TryParse(userInput, out int intValue))
            {
                return intValue;
            }
            else
            {
                Print("Invalid length, defaulting to 1 month.");
                return 1;
            }

        }

    }

}

public class Customer
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int? SubscriptionCount { get; set; }
    public double SubscriptionTotal { get; set; }
}

