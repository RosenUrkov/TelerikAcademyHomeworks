using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiral_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());
            var matrix = new int[sizeOfMatrix, sizeOfMatrix];
            string direction = "right";
            int currentRow = 0;
            int currentCol = 0;
            int counter = 1;
            int spin = 1;

            while (true)
            {
                matrix[currentRow, currentCol] = counter;

                if (counter == sizeOfMatrix * sizeOfMatrix) //(((currentRow == sizeOfMatrix / 2) && (currentCol == sizeOfMatrix / 2)))
                {
                    break;
                }

                if ((direction == "right") && (currentCol == sizeOfMatrix - spin))
                {
                    direction = "down";
                }
                else if ((direction == "right"))
                {
                    currentCol++;
                }


                if ((direction == "down") && (currentRow == sizeOfMatrix - spin))
                {
                    direction = "left";
                }
                else if ((direction == "down"))
                {
                    currentRow++;
                }


                if ((direction == "left") && (currentCol == spin - 1))
                {
                    direction = "up";
                }
                else if ((direction == "left"))
                {
                    currentCol--;
                }


                if ((direction == "up") && (currentRow == spin))
                {
                    direction = "right";
                    currentCol++;
                    spin++;
                }
                else if ((direction == "up"))
                {
                    currentRow--;
                }


                counter++;
            }

            //print matrix
            for (int i = 0; i < sizeOfMatrix; i++)
            {
                for (int j = 0; j < sizeOfMatrix; j++)
                {
                    Console.Write((j == sizeOfMatrix - 1) ? "{0}" : "{0} ", (matrix[i, j]));
                }
                Console.WriteLine();
            }



        }
    }
}
