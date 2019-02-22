using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Input: 5 1 5 8 12 13
///        5 8 1 23 1 11 
/// Output: 2 0 -1 0 -1 
/// In this sample, we are given an increasing sequence a0 = 1, a1 = 5, a2 = 8, a3 = 12, a4 = 13 of length five and five keys to search: 8,1,23,1,11. 
/// We see that a2 = 8 and a0 = 1, but the keys 23 and 11 do not appear in the sequence a. For this reason, we output a sequence 2,0,−1,0,−1. 
/// </summary>

namespace Coursera_Week4
{
    class Program
    {
        static void Main1(string[] args)
        {
            var input1str = Console.ReadLine().Split(' ');
            long[] input1_nbr = new long[input1str.Length - 1];
            for (long i = 1; i < input1str.Length; i++)
            {
                input1_nbr[i-1] = Convert.ToInt32(input1str[i]);
            }
            var input2str = Console.ReadLine().Split(' ');
            long[] input2_nbr = new long[input2str.Length - 1];
            for (long i = 1; i < input2str.Length; i++)
            {
                input2_nbr[i - 1] = Convert.ToInt32(input2str[i]);
            }
            long[] output = new long[input2_nbr.Length];
            for (long i = 0; i< input2_nbr.Length; i++)
            {
                output[i] = BinarySearch(input1_nbr, input2_nbr[i]);
            }

            for (long j =0; j < output.Length; j++)
            {
                Console.Write(output[j].ToString());
                Console.Write(' ');
            }
            Console.ReadLine();

        }


        private static long BinarySearch(long[] input1, long v )
        {
            long l = 0;
            long r = input1.Length - 1;
            while (l <= r)
            {
                long mid = l + (r - l) / 2;
                if (v == input1[mid])
                {
                    return mid;
                }
                if (input1[mid] < v)
                    l = mid + 1;

                else
                    r = mid - 1;
            }
            return -1;
        }
    }
}
