LazyCLI
=======

Easily enable your static functions to be CLI callable! 
Just add an annotation, and call a method in your Main.

Easily install with NuGet using Package Manager Console:

    PM> Install-Package LazyCLI

[![endorse](http://api.coderwall.com/alexanderbrevig/endorsecount.png)](http://coderwall.com/alexanderbrevig)

About this library: http://coderwall.com/p/ghlaga

Example
-------

I find that the best way to describe something is to show it, so here it is!

Notice that the default behavior of the CLI attribute is to require the namespace, the class and the method to be part of the command. So the static void World function is accessible through string[]{"CLI", "Hello", "World", "msg here"}.
The static void Galaxy is available through its alias of string[]{"CLI2", "Galaxy", "msg here", "2"}

    using System;
    using LazyCLI;
    namespace CLI
    {
        public static class Hello
        {
            [LazyCLI]
            public static void World(string msg)
            {
                Console.WriteLine("Hello World: " + msg);
            }
    
            [LazyCLI("CLI2.Galaxy")]
            public static void Galaxy(string msg, string times)
            {
                for (int i = 0; i < Int32.Parse(times); i++)
                {
                    Console.WriteLine(msg);
                }
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("This is a quick demo for using the CLIAttribute.\r\nYou might want to simply pass the string[] args to the HandleArgs function.\r\n");
    
                /// Will print: 'Hello World: This is pretty handy'
                LazyCLI.CLI.HandleArgs(new string[] { "CLI", "Hello", "World", "This is pretty handy" });
                Console.ReadKey();
    
                /// Will print:
                ///   Andromeda
                ///   Andromeda
                ///   Andromeda
                LazyCLI.CLI.HandleArgs(new string[] { "CLI2", "Galaxy", "Anromeda", "3" });
                Console.ReadKey();
            }
        }
    }

Sample printout

    This is a quick demo for using the CLIAttribute.
    You might want to simply pass the string[] args to the HandleArgs function.
    
    Hello World: This is pretty handy
    Anromeda
    Anromeda
    Anromeda
