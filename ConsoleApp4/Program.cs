using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> result = new List<string>();
            Dictionary<char, int> map = new Dictionary<char, int>();
            string input = "aabc";
            map = buildFreqTable(input);
            printPerms(map, "", input.Length, result);
            foreach(string s in result)
            {
                Console.WriteLine(s);
            }
            Console.ReadLine();

        }

        private static void printPerms(Dictionary<char, int> map, string prefix, int length, List<string> result)
        {
            if(length <= 0)
            {
                result.Add(prefix);
                return;
            } else
            {
                List<char> keys = new List<char>(map.Keys);
                foreach (char c in keys)
                {
                    int count = map[c];
                    if (count>=0)
                    {
                        map[c] = count - 1;
                        printPerms(map, prefix + c, length - 1, result);
                        map[c] = count;
                    }
                }
            }
        }

        private static Dictionary<char, int> buildFreqTable(string input)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();
            foreach(char c in input)
            {
                if (!map.ContainsKey(c))
                {
                    map.Add(c, 0);
                } else
                {
                    map[c] = map[c] + 1;
                }
            }
            return map;
        }
    }
}
