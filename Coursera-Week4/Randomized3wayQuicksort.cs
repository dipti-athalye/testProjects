using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursera_Week4
{
    class Randomized3wayQuicksort
    {
        static void Main(string[] args)
        {
            var inputCount = Console.ReadLine();
            var input1str = Console.ReadLine().Split(' ');
            long[] input1_nbr = new long[input1str.Length];
            for (long i = 0; i < input1str.Length; i++)
            {
                input1_nbr[i] = Convert.ToInt64(input1str[i]);
            }
            Randomized_quickSort(input1_nbr, 0, input1_nbr.Length -1);

            for (long i= 0; i<input1_nbr.Length; i++){
                Console.Write(input1_nbr[i].ToString() + ' ');
            }
            Console.ReadLine();

        }

        private static void Randomized_quickSort(long[] input1_nbr, int l, int r)
        {
            if ( l >= r)
            {
                return;
            }
            Random random = new Random();
            int k = random.Next(l, r);
            // swap k and r
            swap(ref input1_nbr[k], ref input1_nbr[r]);
            int i = 0, j = 0;
            Partition2(input1_nbr, l, r, ref i, ref j);

            Randomized_quickSort(input1_nbr, l, i);
            Randomized_quickSort(input1_nbr, j, r);

        }
        private static void swap<T>(ref T l, ref T r)
        {
            T temp;
            temp = l;
            l = r;
            r = temp;
        }

        private static void Partition2(long[] input1_nbr, int l, int r, ref int i, ref int j)
        {
            if (r - l <= 1)
            {
                if (input1_nbr[l] > input1_nbr[r])
                {
                    swap(ref input1_nbr[l], ref input1_nbr[r]);
                }
                i = l;
                j = r;
                return;
            }
            int m = l;
            long pivot = input1_nbr[r];
            while (m <= r)
            {
                if (input1_nbr[m] < pivot)
                {
                    swap(ref input1_nbr[l], ref input1_nbr[m]);
                    m++;
                    l++;
                }
                 else if (input1_nbr[m] == pivot)
                {
                    m++;
                }
                else if (input1_nbr[m] > pivot)
                {
                    swap(ref input1_nbr[m], ref input1_nbr[r]);
                    r--;
                       
                }

            }
            i = l - 1;
            j = m;

        }
    }
}
