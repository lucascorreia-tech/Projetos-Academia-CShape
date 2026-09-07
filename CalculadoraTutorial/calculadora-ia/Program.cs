using System.Text.RegularExpressions;
using CalculatorLibrary;

namespace CalculatorProgram
{

    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            int useCalculator = -1;
            Console.WriteLine("Console Calculator in C#\r");
            Console.WriteLine("------------------------\n");
            Calculator calculator = new Calculator();
            while (!endApp)
            {
                useCalculator++;
                Console.WriteLine($"Using Calculator for {useCalculator} times\n");
                string? numInput1 = "";
                string? numInput2 = "";
                double result = 0;

                Console.Write("Type a number, and then press Enter: ");
                numInput1 = Console.ReadLine();

                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write("This is not valid input. Please enter an integer value: ");
                    numInput1 = Console.ReadLine();
                }

                Console.Write("Type another number, and then press Enter: ");
                numInput2 = Console.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.Write("This is not valid input. Please enter an integer value: ");
                    numInput2 = Console.ReadLine();
                }

                Console.WriteLine("Choose an operator from the following list:");
                Console.WriteLine("\ta - Add");
                Console.WriteLine("\ts - Subtract");
                Console.WriteLine("\tm - Multiply");
                Console.WriteLine("\td - Divide");
                Console.WriteLine("\tsq - Square");
                Console.WriteLine("\tp - Power");
                Console.WriteLine("\t10 - 10x");
                Console.WriteLine("\tsin - Seno");
                Console.WriteLine("\ncos - Cosseno");
                Console.WriteLine("\ttan - Tangente");
                Console.Write("Your option? ");

                string? op = Console.ReadLine();

                if (op == null || !Regex.IsMatch(op, "[a|s|m|d|sq|p]"))
                {
                   Console.WriteLine("Error: Unrecognized input.");
                }

                if (Regex.IsMatch(op!, "[10|sq|tan|cos|sin]"))
                { 
                    Console.WriteLine("Choose um number");
                    Console.WriteLine("1 - number 1");
                    Console.WriteLine("2 - Number 2");
                    
                    string? numberOp = Console.ReadLine();

                    if (numberOp == null || !Regex.IsMatch(numberOp, "[1|2]"))
                    {
                        Console.WriteLine("Error: Unrecognized input.");
                        
                    }

                    double number = numberOp == "1" ? cleanNum1 : numberOp == "2" ? cleanNum2: 0;

                    result = calculator.DoOtherOperation(number, op!);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in a mathematical error. \n");
                    }
                    else Console.WriteLine("Your result: {0:0.##}\n", result);
                }    
                else
                { 
                   try
                   {
                       result = calculator.DoOperation(cleanNum1, cleanNum2, op!); 
                       if (double.IsNaN(result))
                       {
                           Console.WriteLine("This operation will result in a mathematical error.\n");
                       }
                       else Console.WriteLine("Your result: {0:0.##}\n", result);
                   }
                   catch (Exception e)
                   {
                       Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                   }
                }
                Console.WriteLine("------------------------\n");

                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n");
            }
            calculator.Finish();
            return;
        }
    }
}