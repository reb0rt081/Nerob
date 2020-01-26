using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nerob.Client.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine($"<Welcome to NEROB picking system. Please choose an action:>");
            Console.WriteLine($"    <1. Stock inbound.>");
            Console.WriteLine($"    <2. Stock outbound.>");
            Console.WriteLine($"    <3. Blind count.>");

            string input = Console.ReadLine();
        }
    }
}
