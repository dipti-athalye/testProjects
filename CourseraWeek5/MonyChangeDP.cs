using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseraWeek5
{
    class MonyChangeDP
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            long inputnbr = Convert.ToInt64(input);
            int[] coins = { 1, 3, 4 };
            int len = coins.Length;
            int resp = moneyChange(coins, inputnbr,len);
            Console.WriteLine(resp);
            Console.ReadLine();
        }

        private static int moneyChange(int[] coins, long inputnbr, int len)
        {
            if (inputnbr == 0)
            {
                return 1;
            }

            int[] tableOfCount = new int[inputnbr + 1];
            tableOfCount[0] = 0;
            for (int i = 1; i <= inputnbr; i++)
                tableOfCount[i] = int.MaxValue;

            for (int i= 1; i <= inputnbr ; i++) {
               for(int j = 0; j< len; j++)
                {
                    
                    if (coins[j] <= i)
                    {
                        var tempresp = tableOfCount[i - coins[j]];
                        if (tempresp != int.MaxValue && tempresp +1 <= tableOfCount[i])
                        {
                            tableOfCount[i] = tempresp + 1;
                        }
                    }
                }
            }

            return tableOfCount[inputnbr];
        }
    }
}
