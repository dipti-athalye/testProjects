using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            moveTower(n, "A", "B", "C");
            Console.ReadLine();
        }

        private static void moveTower(int n, string source, string temp, string dest)
        {
            if (n == 1)
            {
                Console.WriteLine("Move " + source + " to " + dest);
            } else
            {
                moveTower(n - 1, source, dest, temp);
                Console.WriteLine("Move " + source + " to " + dest);
                moveTower(n - 1, temp, source, dest);
            }
        }
    }
}
