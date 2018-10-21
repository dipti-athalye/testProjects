using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputstr = "abc";
            int n = inputstr.Length;
            List<string> output = new List<string>();
            output = getPermutations1(inputstr);
            foreach (var str in output.Distinct())
            {
                Console.WriteLine(str);
            }
            Console.ReadLine();
        }

        private static List<string> getPermutations(string inputstr, int n)
        {
            List<string> output = new List<string>();
            if (inputstr.Length == 0)
            {
                output.Add(""); // c

            }
            else
            {
                var excludeChar = inputstr.Substring(0, 1); // a, b
                var remaining = inputstr.Substring(1);
                var resp = getPermutations(remaining, n); // "bc", 2, c,1
                output.AddRange(resp);
                foreach (string x in resp)
                {
                    for (int j = 0; j <= x.Length; j++)
                    {
                        var start = x.Substring(0, j);
                        var end = x.Substring(j);
                        string newperm = start + excludeChar + end;
                        output.Add(newperm);
                    }
                }
            }
            return output;
        }

        private static List<string> getPermutations1(string inputstr)
        {
            List<string> output = new List<string>();
            var n = inputstr.Length;
            if (inputstr.Length == 0)
            {
                output.Add(""); // c

            }
            else
            {
                for (int x = 0; x < n; x++)
                {
                    var excludeChar = inputstr.Substring(0, x); // a
                    var remaining = inputstr.Substring(x + 1);// bc
                    var resp = getPermutations1(excludeChar+remaining); // "bc", 2, c,1
                   
                    foreach (string s in resp)
                    {
                        output.Add(inputstr[x] + s);
                    }
                }
            }
            return output;
        }
    }
}
