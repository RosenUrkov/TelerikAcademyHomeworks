namespace Matrix
{
    using System;

    public class MatrixManager
    {
        private static int[] directionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
        private static int[] directionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };

        private int currentRow;
        private int currentCol;

        private int currentDirectionX;
        private int currentDirectionY;

        public MatrixManager()
        {
            this.Initiate();
        }

        public void FillMatrix(int[,] matrix)
        {
            this.CheckMatrix(matrix);

            this.Initiate();
            int currentFillNumber = 0;
            int endNumber = matrix.GetLength(0) * matrix.GetLength(1);

            int counter = 0;
            while (counter < endNumber)
            {
                counter++;
                currentFillNumber++;

                matrix[this.currentRow, this.currentCol] = currentFillNumber;

                for (int i = 0; i <= directionsX.Length; i++)
                {
                    if (this.IsSafeDirection(matrix))
                    {
                        break;
                    }

                    this.ChangeDirection();
                }

                if (!this.IsSafeDirection(matrix))
                {
                    this.FindNextSafeCell(matrix);
                    continue;
                }

                this.currentRow += this.currentDirectionX;
                this.currentCol += this.currentDirectionY;
            }
        }

        public void PrintMatrix(int[,] matrix, IPrinter printer)
        {
            this.CheckMatrix(matrix);
            if (printer == null)
            {
                throw new ArgumentException("Printer must not be null.");
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    printer.Write("{0,3}", matrix[row, col]);
                }

                printer.WriteLine();
            }
        }

        private void Initiate()
        {
            this.currentRow = 0;
            this.currentCol = 0;

            this.currentDirectionX = directionsX[0];
            this.currentDirectionY = directionsY[0];
        }

        private void CheckMatrix(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) != matrix.GetLength(1))
            {
                throw new ArgumentException("The matrix shoud not be correct squared 2 dimensional array.");
            }
        }

        private void ChangeDirection()
        {
            int newDirectionIndex = 0;
            for (int i = 0; i < directionsX.Length; i++)
            {
                if (directionsX[i] == this.currentDirectionX && directionsY[i] == this.currentDirectionY)
                {
                    newDirectionIndex = i;
                    break;
                }
            }

            this.currentDirectionX = directionsX[(newDirectionIndex + 1) % directionsX.Length];
            this.currentDirectionY = directionsY[(newDirectionIndex + 1) % directionsY.Length];
        }

        private bool IsSafeDirection(int[,] matrix)
        {
            if (this.currentRow + this.currentDirectionX >= matrix.GetLength(0) ||
                this.currentRow + this.currentDirectionX < 0 ||
                this.currentCol + this.currentDirectionY >= matrix.GetLength(1) ||
                this.currentCol + this.currentDirectionY < 0 ||
                matrix[this.currentRow + this.currentDirectionX, this.currentCol + this.currentDirectionY] != 0)
            {
                return false;
            }

            return true;
        }

        private void FindNextSafeCell(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 0)
                    {
                        this.currentRow = row;
                        this.currentCol = col;
                        return;
                    }
                }
            }
        }
    }
}
