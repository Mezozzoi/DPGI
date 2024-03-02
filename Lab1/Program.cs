using System;

namespace DPGI
{
    class Program
    {
        /// <summary>
        /// Main funtion.
        /// </summary>
        /// <param name="args">App run arguments.</param>
        static void Main(string[] args)
        {
            Hello.Print();
        }
    }

    class Hello
    {
        public static void Print()
        {
            Console.WriteLine("Hello World!");
        }
    }
}
