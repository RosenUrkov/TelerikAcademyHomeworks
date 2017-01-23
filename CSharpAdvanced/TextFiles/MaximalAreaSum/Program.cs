using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximalAreaSum
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"..\..\Matrix.txt";
            int fun = MatrixReadder(path);
            using (var writer = new StreamWriter(@"..\..\BestArea.txt"))
            {
                writer.WriteLine(fun);
            }
        }

        static int MatrixReadder(string path)
        {
            int[,] matrix;
            using (var reader = new StreamReader(path))
            {

                int size = Convert.ToInt32(reader.ReadLine());
                matrix = new int[size, size];

                for (int rows = 0; rows < size; rows++)
                {
                    int[] colNumbers = reader.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                    for (int cols = 0; cols < size; cols++)
                    {
                        matrix[rows, cols] = colNumbers[cols];
                    }
                }
            }

            int result = BestArea(matrix);
            return result;
        }

        static int BestArea(int[,] matrix)
        {
            int bestArea = int.MinValue;

            for (int rows = 0; rows < matrix.GetLength(0) - 1; rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1) - 1; cols++)
                {
                    int currentArea = 0;
                    for (int templateRows = rows; templateRows < rows + 2; templateRows++)
                    {
                        for (int templateCols = cols; templateCols < cols + 2; templateCols++)
                        {
                            currentArea += matrix[templateRows, templateCols];
                        }
                    }
                    if (currentArea > bestArea)
                    {
                        bestArea = currentArea;
                    }
                }
            }

            return bestArea;
        }
    }
}
