//Palindrome checking application
//The user will enter a string an we will put it in a queue, then analyze the string
using System.Collections;

class Program
{
    static void Main(string[] args)
    {
        string? userInput;
        Queue<char> inputQueue = new Queue<char>();        
        printGreeting();
        Print("Enter a string of characters and press enter:");
        userInput = Console.ReadLine();
        if (userInput != null)
        {
            foreach(char character in userInput)
            {
                inputQueue.Enqueue(character);
            }
        }
        if(IsPalindrome(inputQueue))
        {
            Print("Your string is a palindrome!");
        }
        else
        {
            Print("You did not enter a palindrome");
        }
        

        void Print(string message)
        {
            Console.WriteLine(message);
        }

        void printGreeting()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Print("_____________________________________");
            Console.ResetColor();
            Print("Welcome to the Palindrome Or Not application!");
            Print("You will enter a string of characters.");
            Print("The program with analyze the input.");
            Print("You will be alerted if the input passed our palindrome check.");
            Console.ForegroundColor = ConsoleColor.Blue;
            Print("__________________________________________________________________");
            Console.ResetColor();
        }

        static bool IsPalindrome(Queue<char> inputQueue)
        {
            Queue<char> forwardQueue = new Queue<char>();
            Stack<char> reverseOrder = new Stack<char>();
            char temp;
            while (inputQueue.Count > 0)
            {
                temp = inputQueue.Dequeue();
                forwardQueue.Enqueue(temp);
                reverseOrder.Push(temp);
            }
            while (reverseOrder.Count > 0)
            {
                char back = reverseOrder.Pop();
                char front = forwardQueue.Dequeue();
                if(back != front)
                {
                    return false;//1 or more characters did not match so return false
                }
            }
            return true;//all characters matched so return true
            
        }
    }
}
