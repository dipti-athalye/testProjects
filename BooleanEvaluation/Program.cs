using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooleanEvaluation
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "1^0|0|1";
            Dictionary<string, int> map = new Dictionary<string, int>();
            var res = countEval(input, false,map);
            Console.WriteLine(res);
            Console.ReadLine();
        }

        private static int countEval(string input, bool result, Dictionary<string, int> map)
        {
           if( input.Length == 0) { return 0; }
           if (input.Length == 1) { if (Convert.ToBoolean(Convert.ToInt16(input)) ==  result) { return 1; } else { return 0; } }
           if (map.ContainsKey(result + input)) { return map[result + input]; }
            int ways = 0;
            for (int i =1; i<input.Length;i+=2)
            {
                char c = input[i];
                string left = input.Substring(0, i);
                string right = input.Substring(i + 1);

                int leftTrue = countEval(left, true,map);
                int leftFalse = countEval(left, false, map);
                int rightTrue = countEval(right, true, map);
                int rightFalse = countEval(right, false,map);
                int total = (leftTrue + leftFalse) * (rightTrue + rightFalse);

                int totalTrue = 0; 

                if (c == '&')
                {
                    totalTrue = leftTrue * rightTrue;
                } else if (c== '|')
                {
                    totalTrue = (leftTrue * rightTrue) + (leftTrue * rightFalse) + (leftFalse * rightTrue);
                } else if (c== '^')
                {
                    totalTrue = (leftTrue * rightFalse) + (rightTrue * leftFalse);
                }

                int subWays = result ? totalTrue : total - totalTrue;
                ways += subWays;
            }

            map[result + input] = ways;
            return ways;
        }
    }
}
