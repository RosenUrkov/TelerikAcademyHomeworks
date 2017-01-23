namespace Matrix
{
    using System;
    public class MainClass
    {
        public static void Main(string[] args)
        {
            //Set any numeric type to the matrix and input your rows and cols, but be careful
            //some of the operators below will not work if both matrixes are not squared and same size
            var firstMatrix = new Matrix<int>(3, 3);
            var secondMatrix = new Matrix<int>(3, 3);            

            //You can fill them with the standard 3(row number) lines and 3(col number) numbers in each line separated by spaces
            Matrix<int>.FillMatrix(firstMatrix);
            Console.WriteLine();            
            Matrix<int>.FillMatrix(secondMatrix);
            Console.WriteLine();

            //Get ready for the exception in 3.. 2.. 1..
            Console.WriteLine(firstMatrix + secondMatrix);
            Console.WriteLine(firstMatrix - secondMatrix);
            Console.WriteLine(firstMatrix * secondMatrix);
        }
    }
}
