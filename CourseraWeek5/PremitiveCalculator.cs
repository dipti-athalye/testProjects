using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseraWeek5
{
    class PremitiveCalculator
    {
        static void Main3(string[] args)
        {
            var input = Console.ReadLine();
            int inputnbr = Convert.ToInt32(input);
            //int[] coins = { 3,2, 1 };
            //int len = coins.Length;
            ////Hashtable ht = new Hashtable(inputnbr + 1);
            ////ht[0] = 0;
            ////ht[1] = 1;
            //string[] tableOfValues = new string[inputnbr + 1];
            //tableOfValues[0] = "0";
            //tableOfValues[1] = "1";
            //int resp = moneyChange(coins, inputnbr, len, tableOfValues);
            //Console.WriteLine(resp);
            //string respStr = ReplaceValues(tableOfValues, inputnbr);
            ////Console.WriteLine(tableOfValues[inputnbr].ToString());
            //Console.WriteLine(respStr.ToString());
            List<int> resp = optimal_sequence(inputnbr);
            Console.WriteLine((resp.Count -1).ToString());
            for (int i = 0; i< resp.Count;i++)
            {
                Console.Write(resp[i] + " ");
            }
            Console.ReadLine();
        }
        private static List<int> optimal_sequence(int n)
        {
            List<int> sequence = new List<int>();

            int[] arr = new int[n + 1];

            for (int i = 1; i < arr.Length; i++)
            {
                arr[i] = arr[i - 1] + 1;
                if (i % 2 == 0) arr[i] = Math.Min(1 + arr[i / 2], arr[i]);
                if (i % 3 == 0) arr[i] = Math.Min(1 + arr[i / 3], arr[i]);

            }

            for (int i = n; i > 1;)
            {
                sequence.Add(i);
                if (arr[i - 1] == arr[i] - 1)
                    i = i - 1;
                else if (i % 2 == 0 && (arr[i / 2] == arr[i] - 1))
                    i = i / 2;
                else if (i % 3 == 0 && (arr[i / 3] == arr[i] - 1))
                    i = i / 3;
            }
            sequence.Add(1);

            // Collections.reverse(sequence);
            sequence.Reverse();
            return sequence;
        }
        //private static string ReplaceValues(string[] tableOfValues, int inputnbr)
        //{
        //    if (inputnbr == 1)
        //        return "1";
        //    var newInput = Convert.ToInt32(tableOfValues[inputnbr].Split(' ')[0]);
        //    return ReplaceValues(tableOfValues, newInput) + " " + inputnbr.ToString();
        //}

        //private static int moneyChange(int[] coins, int inputnbr, int len, string[] tableOfValues)
        //{
        //    if (inputnbr == 0)
        //    {
        //        return 1;
        //    }

        //    int[] tableOfCount = new int[inputnbr + 1];
           

        //    tableOfCount[0] = 0;
        //    tableOfCount[1] = 0;

        //    for (int i = 2; i <= inputnbr; i++)
        //    {
        //        tableOfCount[i] = int.MaxValue;
        //        // tableOfValues[i] = string.Empty;
        //    }

        //    for (int i = 1; i <= inputnbr; i++)
        //    {
        //        for (int j = 0; j < len; j++)
        //        {
        //            var opResp = doOpearation(coins[j], i);
        //            if (opResp <= inputnbr)
        //            {
        //                //if (tableOfValues[opResp] == null)
        //                //{
        //                //    tableOfValues[opResp] = tableOfValues[i] + " " + opResp;
        //                //   // tableOfCount[opResp] = tableOfCount[i] + 1;
        //                //}
        //                 //else if (tableOfValues[opResp] != null && tableOfValues[opResp].Length >= tableOfValues[i].Length + 1 + opResp.ToString().Length)
        //               if (tableOfCount[opResp] > tableOfCount[i] + 1)
        //                {

        //                    tableOfValues[opResp] =  i + " " + opResp;
        //                    tableOfCount[opResp] = tableOfCount[i] + 1;
        //                }

        //                if (opResp == inputnbr)
        //                    break;
        //            }
        //        }
        //    }



        //     return tableOfCount[inputnbr];
        //    //return tableOfValues[inputnbr].Split(' ').Length - 1;
        //}

        ///// <summary>
        ///// i = 1
        ///// t[2] = 1, *2 , t[3] = 1, *3 -- min
        ///// i= 2
        ///// t[4] = 2 *2*2, t[6] =2 *2*3, t[3] =2, *2+1
        ///// i=3
        ///// t[6] =2 *3*2, t[9] =2, *3*3, t[4] =2, *3+1
        ///// i =4
        ///// t[8] = 3 *2*2*2, t[12] = 3 *2*2*3, t[5] = 3 *2*2+1
        ///// i=5
        ///// t[10] = 4,
        ///// i=9
        ///// </summary>
        ///// <param name="v"></param>
        ///// <param name="i"></param>
        ///// <returns></returns>

        //private static int doOpearation(int v, int i)
        //{
        //    if (v == 2)
        //    {
        //        return i * 2;
        //    }
        //    if (v == 3)
        //    {
        //        return i * 3;
        //    }
        //    if (v == 1)
        //    {
        //        return i + 1;
        //    }
        //    return int.MaxValue;
        //}
    }
}
