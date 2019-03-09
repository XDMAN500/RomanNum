using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumProject
{

    /// <summary>
    /// A collection of functions that help convert inbetween the decimal and roman number systems.
    /// </summary>
    public class RomanConverter
    {

        private static Numeral[] numerals;

        static RomanConverter() {

            numerals = new Numeral[] {
                   new Numeral('M',1000),
                   new Numeral('D',500),
                   new Numeral('C',100),
                   new Numeral('L',50),
                   new Numeral('X',10),
                   new Numeral('V',5),
                   new Numeral('I',1)

               };
        }

        /// <summary>
        /// Gets the numeral represented by the given character
        /// </summary>
        /// <param name="ch"> The roman numberal symbol</param>
        /// <exception cref="ArgumentException"> 
        /// When a symbol is not recognized as a roman numeral
        /// </exception>
        public static  Numeral GetNumeral(char ch) {
            char con = char.ToUpper(ch);
            foreach (Numeral num in numerals) {
                if (num.symbol == con) {
                    return num;
                }

            }

            throw new System.ArgumentException("Unrecognized character");

        }


        /// <summary>
        /// Converts a decimal number into a roman numeral
        /// </summary>
        /// <param name="number"> The decimal number</param>
        public static string toRoman(int number) {
            StringBuilder builder = new StringBuilder();
            int value = number;
            int numIndex = 0;

            while (value > 0) {
                Numeral num = numerals[numIndex];
                //DEBUG Console.WriteLine("  ~ Value" + value);
                //Standard check
                if (value >= num.value)
                {
                    //DEBUG Console.WriteLine("  ~ Primary" + num.symbol);
                    builder.Append(num.symbol);
                    value -= num.value;
                }
                else {
                   //DEBUG  Console.WriteLine("  ~ FSecondary " + num.symbol);
                    //Look for combinations
                    Numeral? next = null;
                    for (int search = numerals.Length - 1; search > numIndex; search--) {
                        Numeral candidate = numerals[search];
                       //DEBUG  Console.WriteLine("  ~ Try " + candidate.symbol);

                        //Prevent Stuff like VX = 5 from happening
                        if (num.value - candidate.value == candidate.value)
                        {
                           //DEBUG Console.Write("  ~ Cancel try " + candidate.symbol);
                            continue; }
                        if (value >= num.value - candidate.value) {
                            next = candidate;
                            break;
                        }
                    }


                    if (next != null)
                    { 
                        //DEBUG Console.WriteLine("  ~ SecNext " + next.Value.symbol);
                        builder.Append(next.Value.symbol).Append(num.symbol);
                        value -= num.value - next.Value.value;
                    }


                    //Move to next numeral
               
                    numIndex += 1;
                }



            }
            return builder.ToString() ;
        }


        /// <summary>
        /// Converts a roman numeral sequence into a decimal number
        /// </summary>
        /// <param name="stuff"> The roman numberal sequence</param>
        public static int ToDecimal(string stuff) {
            if (stuff.Length == 0) {
                return 0;
            }


            int value = 0;
            for (int i = 0; i < stuff.Length -1; i++) {
                Numeral norm = GetNumeral(stuff[i]);
                Numeral next = GetNumeral(stuff[i + 1]);

                if (next.value > norm.value)
                {
                    value -= norm.value;
                }
                else {
                    value += norm.value;
                }
            }

            value += GetNumeral(stuff[stuff.Length - 1]).value;

            return value;
        }
    }

    /// <summary>
    /// Represents the decimal value and character symbol of a roman numeral
    /// </summary>
    public struct Numeral{
        public readonly char symbol;
        public readonly int value;


        public Numeral(char sym, int val) {
            this.symbol = sym;
            this.value = val;
        }
    }
}
