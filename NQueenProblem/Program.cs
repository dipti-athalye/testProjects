using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Incomplete
namespace NQueenProblem
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        void PlaceQueens(int size,int row, int col,List<string> positions)
        {
            
                for(int c=row; c<size; c++)
                {
                    var isValid = checkValid(size, row, c);
                }
            
        }

        private bool checkValid(int size, int r, int c)
        {
            for (int r1 = 0; r1< r ;r1++ )
            {

            }

            return true;
        }
    }
}
