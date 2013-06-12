using System;
using LazyCLI;

namespace LazyCLISample
{
    public static class Hello
    {
        [LazyCLI("-hello")]
        public static void World(string msg)
        {
            Console.WriteLine("Hello World: " + msg);
        }

        [LazyCLI("-lazy.galaxy")]
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
            data = new Data();
            
            Console.WriteLine("This is a quick demo for using the LazyCLISample.\r\nYou might want to simply pass the string[] args to the HandleArgs function.\r\n");

            LazyCLI.CLI.HandleArgs(new string[] { "-hello", "World" });
            Console.ReadKey();

            LazyCLI.CLI.HandleArgs(new string[] { "-lazy.galaxy", "Anromeda", "3" });
            Console.ReadKey();

            LazyCLI.CLI.HandleArgs(new string[] { "-dev", "-user", "username", "-hello", "compound" });
            Console.WriteLine(data.DevMode + " " + data.Name);
            Console.ReadKey();

            data = new Data();
            LazyCLI.CLI.HandleArgs(new string[] { "-dev" });
            Console.WriteLine(data.DevMode + " " + data.Name);
            Console.ReadKey();
        }

        [LazyCLI("-dev")]
        public static void Dev() { data.DevMode = true; }

        [LazyCLI("-user")]
        public static void User(string nm) { data.Name = nm; }

        private static Data data;
    }

    public class Data
    {
        public string Name { get; set; }
        public bool DevMode { get; set; }
    }
}
