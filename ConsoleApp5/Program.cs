using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            //   Console.WriteLine(addOne(9));
            int resp = negate(40);
            Console.WriteLine(resp.ToString());
            Console.ReadLine();
        }

        private static int negate(int v)
        {
            int neg = 0;
            int newsign = v < 0 ? 1 : -1;
            while (v!=0)
            {
                neg += newsign;
                v += newsign;
            }
            return neg;
        }

        static int addOne(int x)
        {
            int m = 1;
          
            // Flip all the set bits  
            // until we find a 0  
            while ((x & m) == 1)
            {

                x = x ^ m;
                m <<= 1;
            }

            // flip the rightmost 0 bit  
            x = x ^ m;
            return x;
        }
    }
}
