using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajorityElement
{

    class MajorityElement
    {
        static void Main2(string[] args)
        {
            long inputLength = Convert.ToInt64(Console.ReadLine());
            var input1str = Console.ReadLine().Split(' ');
            long[] input1_nbr = new long[input1str.Length];
            for (long i = 0; i < input1str.Length; i++)
            {
                input1_nbr[i] = Convert.ToInt32(input1str[i]);
            }
            Array.Sort(input1_nbr);

            long output = getMajorityElement(input1_nbr);
            Console.Write(output.ToString());
            Console.ReadLine();

        }

        private static long getMajorityElement(long[] input1_nbr)
        {
            if (input1_nbr == null || input1_nbr.Length ==0)
            {
                return 1;
            }
            if (input1_nbr.Length == 1)
            {
                return 1;
            }
            long finalMaxNumber;
            long currentMaxNumber; currentMaxNumber = finalMaxNumber = input1_nbr[0];
            long maxCount = input1_nbr.Length /2;
            long count = 0;
            long resp = 0;
            for (int i = 0; i<input1_nbr.Length; i++)
            {
                if (input1_nbr[i] == currentMaxNumber)
                {
                    count++;
                } else
                {
                    if (count > maxCount)
                    {
                        resp = 1;
                        break;
                    }
                    currentMaxNumber = input1_nbr[i];
                    count = 1;
                }
            }
            resp = (count > maxCount)? 1 :  0;
            return resp;
        }
    }
}
