/*
 * Lab2. Numbers
 * returns the max power of 2, that can divide [a,b]
*/
using System;

namespace Numbers
{
    class Program
    {
        static ulong GetPow(ulong number)
        {
            ulong result = 0;
            while (number > 0)
            {
                number /= 2;
                result += number;
            }
            return result;
        }

        static void Main(string[] args)
        {
            ulong firstNumber, secondNumber;
            Console.WriteLine("Enter first uint64 number (a):");
            while (!ulong.TryParse(Console.ReadLine(), out firstNumber))
            {
                Console.WriteLine("An input error occured, enter correct uint64 number:");
            }
            Console.WriteLine("Enter second uint64 number (b):");
            while (!ulong.TryParse(Console.ReadLine(), out secondNumber))
            {
                Console.WriteLine("An input error occured, enter correct uint64 number:");
            }
            Console.WriteLine("The max power of 2, that can divide [a,b] is {0} (it is 2^{0})", GetPow(secondNumber) - GetPow(firstNumber - 1));
        }
    }
}
