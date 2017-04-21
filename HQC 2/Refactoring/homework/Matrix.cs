namespace Matrix
{
    using System;

    public class MatrixManager
    {
        private static int[] directionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
        private static int[] directionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };

        private int size;
        private int[,] matrix;

        public MatrixManager(int[,] emptyMatrix)
            : this(emptyMatrix.GetLength(0))
        {

        }

        public MatrixManager(int matrixSize, int startFillNumber = 1)
        {
            this.size = matrixSize;
            this.matrix = new int[matrixSize, matrixSize];

            this.Initiate(startFillNumber);
        }

        public int FillNumber { get; set; }

        private int CurrentRow { get; set; }

        private int CurrentCol { get; set; }

        private int CurrentDirectionX { get; set; }

        private int CurrentDirectionY { get; set; }

        private void Initiate(int startFillNumber)
        {
            this.FillNumber = startFillNumber;

            this.CurrentRow = 0;
            this.CurrentCol = 0;

            this.CurrentDirectionX = directionsX[0];
            this.CurrentDirectionY = directionsY[0];
        }

        private void ChangeDirection()
        {
            int newDirectionIndex = 0;
            for (int i = 0; i < directionsX.Length; i++)
            {
                if (directionsX[i] == this.CurrentDirectionX && directionsY[i] == this.CurrentDirectionY)
                {
                    newDirectionIndex = i;
                    break;
                }
            }

            this.CurrentDirectionX = directionsX[(newDirectionIndex + 1) % directionsX.Length];
            this.CurrentDirectionY = directionsY[(newDirectionIndex + 1) % directionsY.Length];
        }

        private bool IsSafeDirection()
        {
            if (this.CurrentRow + this.CurrentDirectionX == this.size ||
                this.CurrentCol + this.CurrentDirectionY == this.size ||
                this.matrix[this.CurrentRow + this.CurrentDirectionX, this.CurrentCol + this.CurrentDirectionY] != 0)
            {
                return false;
            }

            return true;
        }

        private void FindNextSafeCell()
        {
            for (int i = 0; i < this.size; i++)
            {
                for (int j = 0; j < this.size; j++)
                {
                    if (this.matrix[i, j] == 0)
                    {
                        this.CurrentRow = i;
                        this.CurrentCol = j;
                        return;
                    }
                }
            }
        }

        public void Fill()
        {

        }

        public void Print()
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write("{0,3}", this.matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        public static void Main(string[] args)
        {
            //Console.WriteLine( "Enter a positive number " );
            //string input = Console.ReadLine(  );
            //int n = 0;
            //while ( !int.TryParse( input, out n ) || n < 0 || n > 100 )
            //{
            //    Console.WriteLine( "You haven't entered a correct positive number" );
            //    input = Console.ReadLine(  );
            //}

            int size = 5;
            int[,] matrix = new int[size, size];

            int numberCounter = 1;
            int currentRow = 0;
            int currentCol = 0;

            int currentDirectionX = 1;
            int currentDirectionY = 1;

            while (true)
            {
                matrix[currentRow, currentCol] = numberCounter;

                if (!Check(matrix, currentRow, currentCol))
                {
                    break;
                }

                while ((currentRow + currentDirectionX >= size ||
                    currentRow + currentDirectionX < 0 ||
                    currentCol + currentDirectionY >= size ||
                    currentCol + currentDirectionY < 0 ||
                    matrix[currentRow + currentDirectionX, currentCol + currentDirectionY] != 0))
                {
                    ChangeDirection(ref currentDirectionX, ref currentDirectionY);
                }

                currentRow += currentDirectionX;
                currentCol += currentDirectionY;
                numberCounter++;
            }

            for (int p = 0; p < size; p++)
            {
                for (int q = 0; q < size; q++)
                {
                    Console.Write("{0,3}", matrix[p, q]);
                }

                Console.WriteLine();
            }

            //FindCell(matrica, out i, out j);

            //if (i != 0 && j != 0)
            //{
            //    dx = 1; dy = 1;

            //    while (true)
            //    {
            //        matrica[i, j] = k;
            //        if (!Check(matrica, i, j))
            //        {
            //            break;
            //        }

            //        while ((i + dx >= n || i + dx < 0 || j + dy >= n || j + dy < 0 || matrica[i + dx, j + dy] != 0))
            //        {
            //            Change(ref dx, ref dy);
            //        }

            //        i += dx;
            //        j += dy;
            //        k++;
            //    }
            //}

            //for (int pp = 0; pp < n; pp++)
            //{
            //    for (int qq = 0; qq < n; qq++)
            //    {
            //        Console.Write("{0,3}", matrica[pp, qq]);
            //    }

            //    Console.WriteLine();
            //}
        }
    }
}
