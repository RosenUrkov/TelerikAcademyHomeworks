namespace Matrix
{
    using System;
    using System.Linq;
    using System.Text;

    public class Matrix<T> where T : IComparable,IConvertible
    {
        private T[,] matrix;
        private readonly int rows;
        private readonly int cols;

        public Matrix(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            matrix = new T[rows, cols];
            if ((typeof(T) == typeof(string)) || (typeof(T) == typeof(bool)))
            {
                throw new ArgumentException("The matrix must be numeric type.");
            }
        }

        private void IndexValidation(int row, int col)
        {
            if (row < 0 || col < 0 || row >= this.rows || col >= this.cols)
            {
                throw new IndexOutOfRangeException("Index must not be a negative number or bigger than matrixs dimensions.");
            }
        }

        public static void FillMatrix(Matrix<T> matrix)
        {
            for (int row = 0; row < matrix.Rows; row++)
            {
                string[] numbers = Console.ReadLine().Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries).ToArray();
                T[] numbersInCols = new T[numbers.Length];                         
                for (int col = 0; col < matrix.Cols; col++)
                {
                    numbersInCols[col] = (T)Convert.ChangeType(numbers[col], typeof(T));
                    matrix[row, col] = numbersInCols[col];
                }
            }
        }

        public T this[int row, int col]
        {
            get
            {
                /* return the specified index here */
                IndexValidation(row, col);

                return this.matrix[row, col];
            }
            set
            {
                /* set the specified index to value here */
                IndexValidation(row, col);

                this.matrix[row, col] = value;
            }
        }

        public int Rows
        {
            get
            {
                return this.rows;
            }
        }
        public int Cols
        {
            get
            {
                return this.cols;
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Cols; col++)
                {
                    builder.Append(matrix[row, col] + " ");
                }
                builder.Append("\r\n");
            }
            return builder.ToString();

        }



        public static Matrix<T> operator +(Matrix<T> first, Matrix<T> second)
        {
            if (first.Rows != second.Rows || first.Cols != second.Cols)
            {
                throw new InvalidOperationException("First matrix rows and cols must be equal to second matrix rows and cols.");
            }

            var result = new Matrix<T>(first.Rows, first.Cols);
            for (int row = 0; row < first.Rows; row++)
            {
                for (int col = 0; col < first.Cols; col++)
                {
                    result[row, col] = (dynamic)first[row, col] + second[row, col];
                }
            }

            return result;

        }

        public static Matrix<T> operator -(Matrix<T> first, Matrix<T> second)
        {
            if (first.Rows != second.Rows || first.Cols != second.Cols)
            {
                throw new InvalidOperationException("First matrix rows and cols must be equal to second matrix rows and cols.");
            }

            var result = new Matrix<T>(first.Rows, first.Cols);
            for (int row = 0; row < first.Rows; row++)
            {
                for (int col = 0; col < first.Cols; col++)
                {
                    result[row, col] = (dynamic)first[row, col] - second[row, col];
                }
            }

            return result;

        }

        public static Matrix<T> operator *(Matrix<T> first, Matrix<T> second)
        {
            if (first.Rows != second.Cols || first.Cols!=second.Rows)
            {
                throw new InvalidOperationException("One matrix rows must be equal to other matrix cols.");
            }

            var result = new Matrix<T>(first.Rows, second.Cols);
            //result matrix cells
            for (int row = 0; row < first.Rows; row++)
            {
                for (int col = 0; col < second.Cols; col++)
                {
                    //now get the value of each cell in the result matrix                    
                    dynamic resultCell = 0;
                    for (int temp = 0; temp < first.Cols; temp++)
                    {
                        resultCell += (dynamic)first[row, temp] * second[temp, col];
                    }
                    result[row, col] = resultCell;
                }
            }

            return result;

        }

        public static bool operator true(Matrix<T> matrix)
        {
            //dynamic zero = 0;
            bool noZeroElements = false;
            for (int row = 0; row < matrix.Rows; row++)
            {
                for (int col = 0; col < matrix.Cols; col++)
                {
                    if ((dynamic)matrix[row, col] != 0)
                    {
                        noZeroElements = true;
                        break;
                    }
                }

            }
            return noZeroElements;
        }

        public static bool operator false(Matrix<T> matrix)
        {
            //dynamic zero = 0;
            bool noZeroElements = false;
            for (int row = 0; row < matrix.Rows; row++)
            {
                for (int col = 0; col < matrix.Cols; col++)
                {
                    if ((dynamic)matrix[row, col] != 0)
                    {
                        noZeroElements = true;
                        break;
                    }
                }

            }
            return noZeroElements;
        }

    }
}
