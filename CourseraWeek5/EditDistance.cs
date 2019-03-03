using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseraWeek5
{
    class EditDistance
    {
        static void Main(string[] args)
        {
            string input1 = Console.ReadLine();
            string input2 = Console.ReadLine();
            //// your code goes here 
            //string str1 = "sunday";
            //string str2 = "saturday";

            var resp = editDist(input1, input2, input1.Length, input2.Length);
        
            Console.WriteLine(resp.ToString());
            Console.ReadLine();
        }
        private static int findMin(int x, int y, int z)
        {
            if (x <= y && x <= z) return x;
            if (y <= x && y <= z) return y;
            else return z;
        }
        private static int editDist(string input1, string input2, int p1, int p2)
        {
            int[,] temp = new int[p1 + 1, p2 + 1];
            //if (p1 == 0) return p2;
            //if (p2 == 0) return p1;

            //if (input1[p1 -1] == input2[p2 -1])
            //{
            //    return editDist(input1, input2, p1 - 1, p2 - 1);
            //}
            //return 1 + findMin(editDist(input1, input2, p1, p2 - 1), editDist(input1, input2, p1 - 1, p2), editDist(input1, input2, p1 - 1, p2 - 1));

            for (int i = 0; i <= p1; i++)
            {
                for (int j = 0; j <= p2; j++)
                {
                   if(i == 0)
                    {
                        temp[i, j] = j;
                    }
                    else if (j == 0)
                    {
                        temp[i, j] = i;
                    }
                    else if (input1[i-1] == input2[j-1])
                    {
                        temp[i, j] = temp[i - 1, j - 1];
                    } else
                    {
                        temp[i, j] = 1 + findMin(temp[i, j - 1], temp[i - 1, j], temp[i - 1, j - 1]);
                    }
                }
            }
            return temp[p1, p2];
        }
    }
}
