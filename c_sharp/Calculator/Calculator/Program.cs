//calculator
//takes two integers and lets the user choose from 4 operators



class Program
{
    static void Main(string[] args)
    {
        string? userInput;
        double firstNumber = 0;
        double secondNumber = 0;
        bool exitLoop = false;

        printGreeting();//print an introduction to the program

        //loop to get the first nummber from the user
        while (!exitLoop)
        {
            print("Enter the first number:");
            userInput = Console.ReadLine();
            try
            {
                firstNumber = double.Parse(userInput);
                exitLoop = true; // firstNumber saved we can move on
            }
            catch (FormatException)
            {
                print("Entry is invalid - only numbers are allowed");//loop again for a valid number
            }
        }

        exitLoop = false;//rest to false for a new loop

        //loop to get the first nummber from the user
        while (!exitLoop)
        {
            print("Enter the second number:");
            userInput = Console.ReadLine();
            try
            {
                secondNumber = double.Parse(userInput);
                exitLoop = true; // secondNumber saved we can move on
            }
            catch (FormatException)
            {
                print("Entry is invalid - only numbers are allowed");//loop again for a valid number
            }
        }

        double result = doMath(firstNumber, secondNumber);
        print("The result is: " + result.ToString());


        //beginning of functions
        void print(string message)
        {
            Console.WriteLine(message);
        }

        void printGreeting()
        {
            print("========================================");
            print("Welcome to Tim's Calculator Console App!");
            print("You will be asked to enter 2 numbers.");
            print("Then you will choose an operator from the options of:");
            print("Add (+), Subtract (-), Multiply (*), Divide (/)");
            print("===============================================");
        }

        double doMath(double num1, double num2)
        {
            //get the user's operator of choice and return the result of the equation
            string? input;
            while (true)
            {
                print("Enter an operator:");
                print("1 - Add (+):");
                print("2 - Subtract (-):");
                print("3 - Multiply (*):");
                print("4 - Divide (/):");
                input = Console.ReadLine();
                if (input != null)
                {
                    switch (input[0])//we will just take the first character
                    {
                        case '1':
                            return num1 + num2;
                        case '2':
                            return num1 - num2;
                        case '3':
                            return num1 * num2;
                        case '4':
                            if (num2 != 0)
                            {
                                return num1 / num2;
                            }
                            else
                            {
                                print("The 2nd number is 0, we cannot divide by zero.");
                                break;
                            }
                        default:
                            print("Invalid operator option entered.");
                            break;

                    }
                }
            }

        }//end of doMath function
    }//end of main function
}//end of program

