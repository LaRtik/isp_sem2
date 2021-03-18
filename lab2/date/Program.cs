/*
 * Lab2
 * Prints the names of months in selected language
*/
using System;
using System.Globalization;

namespace Date
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // to delete ? in output
            CultureInfo language = null;
            while (language == null)
            {
                try
                {
                    Console.WriteLine("Enter the language (ru - Russian, fr - French, be - Belarusian and so on..):");
                    Console.WriteLine("(if the language doesn't exists, English language will be selected or input ERROR occured)");
                    language = CultureInfo.GetCultureInfo(Console.ReadLine());
                }
                catch (CultureNotFoundException)
                {
                    Console.WriteLine("An input error has occured. Please try again.");
                }
            }
            CultureInfo.CurrentCulture = language;

            DateTime date = new DateTime();
            for (int i = 0; i < 12; i++)
            {
                Console.WriteLine(date.AddMonths(i).ToString("MMMM"));
            }
        }
    }
}