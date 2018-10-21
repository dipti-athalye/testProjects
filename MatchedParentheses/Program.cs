using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            var resp = GenerateParens(3);
            var resp1 = GenerateParens1(3);
            foreach (string s in resp)
            {
                Console.WriteLine(s);

            }
            Console.WriteLine("Response2");
            foreach (string s in resp1)
            {
                Console.WriteLine(s);

            }
            Console.ReadLine();
        }

        static List<string> GenerateParens(int count)
        {
            char[] str = new char[count * 2];
            List<string> list = new List<string>();
            addParen(list, count, count, str, 0);
            return list;

        }

        private static void addParen(List<string> list, int left, int right, char[] str, int idx)
        {
            if(left <0 || right<left) { return; }
            if (left == 0 && right ==0)
            {
                list.Add(new string(str));
            } else
            {
                str[idx] = '(';
                addParen(list, left - 1, right, str, idx + 1);
                str[idx] = ')';
                addParen(list, left, right - 1, str, idx + 1);
            }
        }


        static HashSet<string> GenerateParens1(int count)
        {
            HashSet<string> result = new HashSet<string>();
            if (count == 0)
            {
                result.Add("");
            } else
            {
                HashSet<string> prev = GenerateParens1(count - 1);
                foreach (string s in prev)
                {
                    for(int i= 0; i< s.Length; i++)
                    {
                        if (s[i] == '(')
                        {
                            var r = insertparen(s,i);
                            result.Add(r);
                        }
                    }
                    result.Add("()" + s);
                }
              
            }
            return result;

        }

        private static string insertparen(string s,int i)
        {
            var left = s.Substring(0, i + 1);
            var right = s.Substring(i + 1);
            string newstr = left + "()" + right;
            return newstr;
        }
    }
}
