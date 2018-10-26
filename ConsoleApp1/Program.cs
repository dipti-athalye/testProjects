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
            //int n = 5;
            //moveTower(n, "A", "B", "C");
            //Console.ReadLine();
            int x = -3, y = 5;
             if (oppositeSigns(x, y) == true)
                Console.Write("Signs are opposite");
            else
                Console.Write("Signs are not opposite");
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

        static bool oppositeSigns(int x, int y)
        {
            var c =  (x ^ y);
            return c< 0;
        }
    }
}
