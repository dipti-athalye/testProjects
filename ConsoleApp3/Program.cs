using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Program
    {
        static void Main(string[] args)
        {
            
           List<int> inputset = new List<int>();
            inputset.Add(1);
            inputset.Add(2);
            inputset.Add(3);

            getAllSubsets(inputset, new Dictionary<int, List<int>>(), 0);
        }

        static Dictionary<int, List<int>> getAllSubsets(List<int> inputset, Dictionary<int, List<int>> currentsubset, int index)
        {
            Dictionary<int, List<int>> output = new Dictionary<int, List<int>>();
            if (index == 0)
            {
                output = currentsubset;
            } else
            {
                //foreach (int i=0)
            }
            return output;

        }

        //static long getWays(long n, long[] c, int idx)
        //{
        //    if (idx >= c.Length - 1) { return 1; }
        //    long ways = 0;
        //    long denoAmt = c[idx];
        //    for (long i = 0; i * denoAmt <= n; i++)
        //    {
        //        long amtRemaining = n - (i * denoAmt);
        //        ways += getWays(amtRemaining, c, idx+1);
        //    }
        //    return ways;
        //}

        static long getWays(long[] S, int m, long n)
        {
            // If n is 0 then there is 1 solution  
            // (do not include any coin) 
            if (n == 0)
                return 1;

            // If n is less than 0 then no  
            // solution exists 
            if (n < 0)
                return 0;

            // If there are no coins and n  
            // is greater than 0, then no 
            // solution exist 
            if (m <= 0 && n >= 1)
                return 0;

            // count is sum of solutions (i)  
            // including S[m-1] (ii) excluding S[m-1] 
            return getWays(S, m - 1, n) +
                getWays(S, m, n - S[m - 1]);
        }

    }
}
