using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libcsmenu.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var ent = new Dictionary<int, lcString>
            {
                {0, "Test 0"},
                {1, "Test 1"},
                {5, "Test 5"},
                {2, "Test 2"},
            }.ToDictionary(x => x.Key, x => new lcString(x.Value.Text, ConsoleColor.Green, ConsoleColor.Blue));

            Console.WriteLine("Selection: " + ConsoleEx.Select(ent, ConsoleColor.White, ConsoleColor.DarkRed, true, 5, true).Value);

            //Console.Read();
        }
    }
}
