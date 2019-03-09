using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RomanNumProject;

namespace RomanNumProjectCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter \"quit\" to exit");
            const string EXIT = "quit";


            while (true)
            {
                string input = Console.ReadLine();
                string[] vals = input.Split(' ');

                if (vals[0].Equals(EXIT))
                {
                    Console.WriteLine("Exiting program");
                    break;
                }
                else if (vals[0].Equals("toroman"))
                {
                    if (vals.Length == 2)
                    {
                        string read = vals[1];
                        
                    }
                    else
                    {
                        Console.WriteLine("Not enough arguments: toroman <number>");
                    }
                }
                else if (vals[0].Equals("todecimal"))
                {

                    if (vals.Length == 2)
                    {

                        string roman = vals[1];
                        toDecimal(roman)
                      
                    }
                    else
                    {
                        Console.WriteLine("Not enough arguments: todecimal <roman>");
                    }
                }
                else if (vals[0].Equals("countdown"))
                {

                    if (vals.Length == 2)
                    {

                        string num = vals[1];
                        int value;

                        if (!int.TryParse(num, out value))
                        {
                            Console.WriteLine("Could not read the number.");
                            Console.ReadKey();
                            continue;
                        }

                        countDown(value);
                    }
                    else
                    {
                        Console.WriteLine("Not enough arguments: countdown <number>");
                    }
                }
                else if (vals[0].Equals("help"))
                {
                    Console.WriteLine("RomanNum help menu");
                    Console.WriteLine("toroman <number> - Converts a decimal number to a roman numeral");
                    Console.WriteLine("todecimal <roman> - Converts a roman numeral to a decimal number");
                    Console.WriteLine("countdown <number> - Displays all roman numerals from the given number to 1");
                    Console.WriteLine("help - Displays this help menu");
                }
                else
                {
                    Console.WriteLine("Unknown command");
                }
            }
        }


        static void toRoman(string read)
        {
            int value;

            if (!int.TryParse(read, out value))
            {
                Console.WriteLine("Could not read the number.");
                Console.ReadKey();
                return;
            }


            string romans = RomanConverter.toRoman(value);

            int convValue = RomanConverter.ToDecimal(romans);
            Console.WriteLine("Roman Numeral: " + romans);
            Console.WriteLine("Decimal Value: " + convValue);
        }

        static void toDecimal(string roman)
        {
            try
            {
                int convValue = RomanConverter.ToDecimal(roman);
                string romans = RomanConverter.toRoman(convValue);
                Console.WriteLine("Roman Numeral: " + romans);
                Console.WriteLine("Decimal Value: " + convValue);
            }
            catch (System.ArgumentException ex)
            {

                Console.WriteLine("Unrecognized character in the sequence");
            }

        }

        static void standard() {

            Console.WriteLine("Give me a number");
            string input = Console.ReadLine();
            int value;

            if (!int.TryParse(input, out value))
            {
                Console.WriteLine("Could not read the number.");
                Console.ReadKey();
                return;
            }


            string romans = RomanConverter.toRoman(value);

            int convValue = RomanConverter.ToDecimal(romans);
            Console.WriteLine("Roman Numeral: " + romans);
            Console.WriteLine("Decimal Value: " + convValue);
        }


        static void countDown(int count) {
            for (int i = count; i > 0; i--) {
                string romans = RomanConverter.toRoman(i);
                int value = RomanConverter.ToDecimal(romans);


                Console.WriteLine($"{i,4} {romans,15} {value,4}");

            }
        }
    }
}
