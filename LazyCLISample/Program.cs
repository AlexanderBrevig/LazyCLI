using System;
using LazyCLI;

namespace LazyCLISample
{
    public static class Hello
    {
        [LazyCLI]
        public static void World(string msg)
        {
            Console.WriteLine("Hello World: " + msg);
        }

        [LazyCLI("Lazy.Galaxy")]
        public static void Galaxy(string msg, string times)
        {
            for (int i = 0; i < Int32.Parse(times); i++) {
                Console.WriteLine(msg);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is a quick demo for using the LazyCLISample.\r\nYou might want to simply pass the string[] args to the HandleArgs function.\r\n");

            LazyCLI.CLI.HandleArgs(new string[] { "LazyCLISample", "Hello", "World", "This is pretty handy" });
            Console.ReadKey();

            LazyCLI.CLI.HandleArgs(new string[] { "Lazy", "Galaxy", "Anromeda", "3" });
            Console.ReadKey();
        }
    }
    
}
