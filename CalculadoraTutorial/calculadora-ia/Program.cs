<<<<<<< HEAD
﻿using System.Data.SqlTypes;
=======
﻿// Program.cs
>>>>>>> 6d975693133da94bccf3c827efe25fad3337113c
using System.Text.RegularExpressions;
using CalculatorLibrary;

namespace CalculatorProgram
{

    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
<<<<<<< HEAD
            int useCalculator = -1;
            Console.WriteLine("Console Calculator in C#\r");
            Console.WriteLine("------------------------\n");
            Calculator calculator = new Calculator();
            while (!endApp)
            {
                useCalculator++;
                Console.WriteLine($"Using Calculator for {useCalculator} times\n");
=======
            // Display title as the C# console calculator app.
            Console.WriteLine("Console Calculator in C#\r");
            Console.WriteLine("------------------------\n");

            Calculator calculator = new Calculator();
            while (!endApp)
            {
                // Declare variables and set to empty.
                // Use Nullable types (with ?) to match type of System.Console.ReadLine
>>>>>>> 6d975693133da94bccf3c827efe25fad3337113c
                string? numInput1 = "";
                string? numInput2 = "";
                double result = 0;

<<<<<<< HEAD
=======
                // Ask the user to type the first number.
>>>>>>> 6d975693133da94bccf3c827efe25fad3337113c
                Console.Write("Type a number, and then press Enter: ");
                numInput1 = Console.ReadLine();

                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write("This is not valid input. Please enter an integer value: ");
                    numInput1 = Console.ReadLine();
                }

<<<<<<< HEAD
=======
                // Ask the user to type the second number.
>>>>>>> 6d975693133da94bccf3c827efe25fad3337113c
                Console.Write("Type another number, and then press Enter: ");
                numInput2 = Console.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.Write("This is not valid input. Please enter an integer value: ");
                    numInput2 = Console.ReadLine();
                }

<<<<<<< HEAD
=======
                // Ask the user to choose an operator.
>>>>>>> 6d975693133da94bccf3c827efe25fad3337113c
                Console.WriteLine("Choose an operator from the following list:");
                Console.WriteLine("\ta - Add");
                Console.WriteLine("\ts - Subtract");
                Console.WriteLine("\tm - Multiply");
                Console.WriteLine("\td - Divide");
<<<<<<< HEAD
                Console.WriteLine("\tsq - Square");
                Console.WriteLine("\tp - Power");
                Console.WriteLine("\t10 - 10x");
                Console.WriteLine("\tsin - Seno");
                Console.WriteLine("\ncos - Cosseno");
                Console.WriteLine("\ttan - Tangente");
=======
>>>>>>> 6d975693133da94bccf3c827efe25fad3337113c
                Console.Write("Your option? ");

                string? op = Console.ReadLine();

<<<<<<< HEAD
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
=======
                // Validate input is not null, and matches the pattern
                if (op == null || ! Regex.IsMatch(op, "[a|s|m|d]"))
                {
                   Console.WriteLine("Error: Unrecognized input.");
                }
>>>>>>> 6d975693133da94bccf3c827efe25fad3337113c
                else
                { 
                   try
                   {
<<<<<<< HEAD
                       result = calculator.DoOperation(cleanNum1, cleanNum2, op!); 
=======
                       result = calculator.DoOperation(cleanNum1, cleanNum2, op); 
>>>>>>> 6d975693133da94bccf3c827efe25fad3337113c
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

<<<<<<< HEAD
                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n");
=======
                // Wait for the user to respond before closing.
                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n"); // Friendly linespacing.
>>>>>>> 6d975693133da94bccf3c827efe25fad3337113c
            }
            calculator.Finish();
            return;
        }
    }
}