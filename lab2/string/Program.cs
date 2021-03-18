/* Lab 2. StringBuilder and Random
 * returns 30 random digits of a 256-length en word (only letters)
*/

using System;
using System.Text;

namespace Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder line = new StringBuilder();
            do
            {
                Console.WriteLine("Enter a line (256 eng letters)");
                StringBuilder temp = new StringBuilder(Console.ReadLine());
                if (line.Length != 256)
                {
                    Console.WriteLine("Incorrect input! Enter a 256-length line with only en letters!");
                    continue;
                }
                bool check = true;
                for (int i = 0; i < temp.Length; i++)
                {
                    if ((temp[i] < 'A' || temp[i] > 'Z') && (temp[i] < 'a' || temp[i] > 'z'))
                    {
                        Console.WriteLine("Incorrect input! Enter a 256-length line with only en letters!");
                        check = false;
                        break;
                    }
                }
                if (check)
                {
                    line = temp;
                    break;
                }
            } while (true);
            StringBuilder ans = new StringBuilder();
            Random rnd = new Random();
            for (int i = 0; i < 30; i++)
            {
                ans.Append(line[rnd.Next() % line.Length]);
                ans.Append(' ');
            }
            Console.WriteLine("Random 30 digits:");
            Console.WriteLine(ans);
        }
        
    }
}
