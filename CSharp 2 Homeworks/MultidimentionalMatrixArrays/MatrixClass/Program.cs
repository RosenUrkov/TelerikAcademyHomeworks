using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixClass
{
    class Matrix
    {
        private int[,] table;

        public Matrix(int rows, int cols)
        {
            this.table = new int[rows, cols];
        }

        public int Rows
        {
            get
            {
                return this.table.GetLength(0);
            }
        }

        public int Cols
        {
            get
            {
                return this.table.GetLength(1);
            }
        }

    }



    class Program
    {
        static void Main(string[] args)
        {


        }
    }

}