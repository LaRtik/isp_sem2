using System;
using System.Runtime.InteropServices;

namespace MusicPlayer
{
    class Program
    {
        [DllImport("winmm.dll")]
        public static extern bool PlaySound(string sound, IntPtr hmod, int flags = 0x0001);
        static void Main(string[] args)
        {
            Console.WriteLine("Playing 'For the Damaged Coda - Blonde Redhead'");
            PlaySound("../../default.wav", IntPtr.Zero);

            while (true)
            {
                Console.WriteLine("S - stop playing music, P - play again, E - exit");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "S":
                        Console.WriteLine("Stop playing");
                        PlaySound(" ", IntPtr.Zero);
                        break;
                    case "P":
                        Console.WriteLine("Playing 'For the Damaged Coda - Blonde Redhead'");
                        PlaySound("../../default.wav", IntPtr.Zero);
                        break;
                    case "E":
                        Console.WriteLine("Good bye!");
                        return;
                    default:
                        Console.WriteLine("Incorrect input. Try again.");
                        break;
                }
            }
            

        }
    }
}
